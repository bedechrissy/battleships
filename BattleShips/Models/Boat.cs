using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    /// <summary>
    /// The boat model
    /// </summary>
    public class Boat
    {
        /// <summary>
        /// Constructor
        /// Initialises a new Boat with expected properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="length"></param>
        public Boat(string name, BoatType type, int length)
        {
            Condition.Requires(name).IsNotNullOrWhiteSpace();
            Condition.Requires(length).IsGreaterOrEqual(1);

            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Length = length;
            Hits = 0;
        }

        /// <summary>
        /// The Id of the created boat
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the boat
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The type of boat
        /// </summary>
        public BoatType Type { get; private set; }

        /// <summary>
        /// The boat length
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// The number of times the boat has been hit
        /// </summary>
        public int Hits { get; set; }

    }
}
