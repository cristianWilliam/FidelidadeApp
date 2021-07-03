using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FidelidadeApp.Core.Models
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; protected set; }

        protected Entity()
        {
        }

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}
