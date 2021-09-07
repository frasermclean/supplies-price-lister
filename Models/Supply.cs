using System;
using System.Diagnostics.CodeAnalysis;

namespace SuppliesPriceLister.Models
{
    public interface ISupply
    {
        /// <summary>
        /// Unique identifier of supply.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Descriptive name of the supply.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Price in AUD
        /// </summary>
        public float Price { get; }

        /// <summary>
        /// Unit of measurement for the supply.
        /// </summary>
        public string UnitOfMeasurement { get; }
    }

    public abstract class Supply : ISupply, IEquatable<Supply>, IComparable<Supply>
    {
        public abstract string Id { get; set; }
        public abstract string Description { get; set; }
        public abstract float Price { get; set; }
        public abstract string UnitOfMeasurement { get; set; }

        public int CompareTo([AllowNull] Supply other)
        {
            throw new NotImplementedException();
        }

        public bool Equals([AllowNull] Supply other)
        {
            throw new NotImplementedException();
        }
    }
}
