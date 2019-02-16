using BattleShips.Helpers;
using BattleShips.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BattleShipTests
{
    /// <summary>
    /// Tests relating to the Randomizer
    /// </summary>
    [TestClass]
    public class ProgramTests_RandomizerTests
    {
        #region Private Fields

        /// <summary>
        /// The grid argument passed when selecting a random grid cell
        /// </summary>
        Grid _gridArgument { get; set; }

        #endregion

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void SelectRandomAlignment_WhenCalled_ExpectAnAlignmentToBeReturned()
        {
            // Act
            var result = Randomizer.SelectRandomAlignment();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Alignment));
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void SelectRandomArrayInices_WhenCalled_ExpectTupleToBeReturned()
        {
            // Arrange 
            _gridArgument = new Grid(new Random().Next(10), new Random().Next(10));

            // Act
            var result = Randomizer.SelectRandomCell(_gridArgument);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Indices));
        }

        #endregion
    }
}
