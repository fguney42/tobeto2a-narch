using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Fuel : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<Model> Models { set; get; }
    public Fuel(ICollection<Model> models)
    {
        Models = models;
    }
    public Fuel()
    {
        Models = Array.Empty<Model>();
    }
    public Fuel(string name)
    {
        Name = name;
    }
}
