﻿using System.Collections.Immutable;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Services.AuthService;

public class AuthManager : IAuthService
{
    
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper<Guid, int> _tokenHelper;
    private readonly TokenOptions _tokenOptions;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private IUserService _userService;

    public AuthManager(
        IUserOperationClaimRepository userOperationClaimRepository,
        IRefreshTokenRepository refreshTokenRepository,
        ITokenHelper<Guid, int> tokenHelper,
        IConfiguration configuration,
        IMapper mapper,
    IUserService userService)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        _userService = userService;
        _mapper = mapper;
        const string tokenOptionsConfigurationSection = "TokenOptions";
        _tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimRepository.GetOperationClaimsByUserIdAsync(user.Id);
        AccessToken accessToken = _tokenHelper.CreateToken(
            user,
            operationClaims.Select(op => (NArchitecture.Core.Security.Entities.OperationClaim<int>)op).ToImmutableList()
        );
        return accessToken;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task DeleteOldRefreshTokens(Guid userId)
    {
        List<RefreshToken> refreshTokens = await _refreshTokenRepository.GetOldRefreshTokensAsync(
            userId,
            _tokenOptions.RefreshTokenTTL
        );
        await _refreshTokenRepository.DeleteRangeAsync(refreshTokens);
    }

    public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
    {
        RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(predicate: r => r.Token == token);
        return refreshToken;
    }

    public async Task RevokeRefreshToken(
        RefreshToken refreshToken,
        string ipAddress,
        string? reason = null,
        string? replacedByToken = null
    )
    {
        refreshToken.RevokedDate = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;
        refreshToken.ReasonRevoked = reason;
        refreshToken.ReplacedByToken = replacedByToken;
        await _refreshTokenRepository.UpdateAsync(refreshToken);
    }

    public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
    {
        NArchitecture.Core.Security.Entities.RefreshToken<Guid> newCoreRefreshToken = _tokenHelper.CreateRefreshToken(
            user,
            ipAddress
        );
        RefreshToken newRefreshToken = _mapper.Map<RefreshToken>(newCoreRefreshToken);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
    {
        RefreshToken? childToken = await _refreshTokenRepository.GetAsync(predicate: r =>
            r.Token == refreshToken.ReplacedByToken
        );

        if (childToken?.RevokedDate != null && childToken.ExpiresDate <= DateTime.UtcNow)
            await RevokeRefreshToken(childToken, ipAddress, reason);
        else
            await RevokeDescendantRefreshTokens(refreshToken: childToken!, ipAddress, reason);
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        NArchitecture.Core.Security.Entities.RefreshToken<Guid> coreRefreshToken = _tokenHelper.CreateRefreshToken(
            user,
            ipAddress
        );
        RefreshToken refreshToken = _mapper.Map<RefreshToken>(coreRefreshToken);
        return Task.FromResult(refreshToken);
    }

    public async Task<User> Register(UserForRegisterDto request)
    {
        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt // define
        );
        User newUser =
            new()
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
        User createdUser = await _userService.AddAsync(newUser);

        return createdUser;
    }
}
