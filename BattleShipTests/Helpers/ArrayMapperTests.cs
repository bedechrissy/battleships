using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips.Models;
using System;
using BattleShips.Helpers;

namespace BattleShipTests
{
    /// <summary>
    /// Tests relating to the Array Mapper
    /// </summary>
    [TestClass]
    public class ProgramTests_ArrayMapperTests
    {
        #region Private Fields

        /// <summary>
        /// The array indices argument
        /// </summary>
        private Indices _arrayIndicesArgument { get; set; }

        /// <summary>
        /// The grid coordinates to be mapped
        /// </summary>
        private GridCoords _gridCoordsArgument { get; set; }


        /// <summary>
        /// The array indices response
        /// </summary>
        private Indices _arrayIndicesResponse { get; set; }

        /// <summary>
        /// The grid coordinates response
        /// </summary>
        private GridCoords _gridCoordsResponse { get; set; }

        #endregion

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void GetArrayIndicesForCoords_WhenArgumentsAreValid_ExpectSuccessfulMapping()
        {
            // Arrange
            _gridCoordsArgument = new GridCoords(5, "D");
            _arrayIndicesResponse = new Indices(4, 3);

            // Act
            var result = ArrayMapper.GetArrayIndicesForCoords(_gridCoordsArgument);

            // Assert
            Assert.AreEqual(this._arrayIndicesResponse.X, result.X);
            Assert.AreEqual(this._arrayIndicesResponse.Y, result.Y);
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetArrayIndicesForCoords_WhenCoordsArgumentIsNull_ExpectArgumentNullException()
        {
            // Arrange
            _gridCoordsArgument = null;

            // Act
            try
            {
               var result = ArrayMapper.GetArrayIndicesForCoords(_gridCoordsArgument);

            } catch(Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                throw;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetArrayIndicesForCoords_WhenTheXCoordIsInvalid_ExpectArgumentException()
        {
            // Arrange
            _gridCoordsArgument = new GridCoords(-1, "E");

            // Act
            try
            {
                var result = ArrayMapper.GetArrayIndicesForCoords(_gridCoordsArgument);

            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
                throw;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetArrayIndicesForCoords_WhenTheYCoordIsInvalid_ExpectArgumentException()
        {
            // Arrange
            _gridCoordsArgument = new GridCoords(7, "CHOW");

            // Act
            try
            {
                var result = ArrayMapper.GetArrayIndicesForCoords(_gridCoordsArgument);

            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                throw;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void GetCoordsForArrayIndices_WhenArgumentsAreValid_ExpectSuccessMapping()
        {
            // Arrange
            _arrayIndicesArgument = new Indices(6, 3);
            _gridCoordsResponse = new GridCoords(7, "D");

            // Act
            var result = ArrayMapper.GetCoordsForArrayIndices(_arrayIndicesArgument);

            // Assert
            Assert.IsInstanceOfType(result, typeof(GridCoords));
            Assert.AreEqual(this._gridCoordsResponse.X, result.X);
            Assert.AreEqual(this._gridCoordsResponse.Y, result.Y);
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetCoordsForArrayIndices_WhenIndicesAreInvalid_ExpectArgumentException()
        {
            // Arrange
            _arrayIndicesArgument = null;

            // Act
            try
            {
                var result = ArrayMapper.GetCoordsForArrayIndices(_arrayIndicesArgument);

            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                throw;
            }
        }

        #endregion
    }
}
