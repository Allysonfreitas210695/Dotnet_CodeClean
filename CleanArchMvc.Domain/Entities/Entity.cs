using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime Created { get; protected set; } = DateTime.Now;
        public DateTime Updated { get;  set; } = DateTime.Now;
    }
}