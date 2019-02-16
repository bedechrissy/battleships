using BattleShips.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BattleShipTests.Models
{
    /// <summary>
    /// Test class for the creation of a boat
    /// </summary>
    [TestClass]
    public class BoatTests
    {
        #region Private Fields

        /// <summary>
        /// The boat name argument
        /// </summary>
        private string _boatNameArgument;

        /// <summary>
        /// The boat length
        /// </summary>
        private int _boatLengthArgument;

        /// <summary>
        /// The type of boat
        /// </summary>
        private BoatType _boatTypeArgument;

        /// <summary>
        /// The created boat
        /// </summary>
        private Boat _createdBoat;

        #endregion

        #region Tests

        /// <summary>
        // Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Boat_WhenNameArgumentIsNull_ExpectNullException()
        {
            // Arrange
            _boatLengthArgument = 5;
            _boatNameArgument = null;
            _boatTypeArgument = BoatType.Destroyer;

            // Act
            try
            {
                var result = new Boat(_boatNameArgument, _boatTypeArgument, _boatLengthArgument);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                throw;
            }
        }

        /// <summary>
        // Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Boat_WhenNameArgumentIsWhiteSpace_ExpectArgumentException()
        {
            // Arrange
            _boatLengthArgument = 5;
            _boatNameArgument = "  ";
            _boatTypeArgument = BoatType.Destroyer;

            // Act
            try
            {
                var result = new Boat(_boatNameArgument, _boatTypeArgument, _boatLengthArgument);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                throw;
            }
        }

        /// <summary>
        // Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Boat_WhenLengthArgumentIsLessThanOne_ExpectArgumentException()
        {
            // Arrange
            _boatLengthArgument = -5;
            _boatNameArgument = "Rick Ascii";
            _boatTypeArgument = BoatType.Destroyer;

            // Act
            try
            {
                var result = new Boat(_boatNameArgument, _boatTypeArgument, _boatLengthArgument);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
                throw;
            }
        }

        /// <summary>
        // Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void Boat_WhenargumentsAreValidExpectBoatToBeCreatedSuccesfully()
        {
            // Arrange

            var createdBoat =

            _boatLengthArgument = 4;
            _boatNameArgument = "Rick Ascii";
            _boatTypeArgument = BoatType.Destroyer;

            // Act
            var result = new Boat(_boatNameArgument, _boatTypeArgument, _boatLengthArgument);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Boat));
            Assert.AreEqual(_boatNameArgument, result.Name);
            Assert.AreEqual(_boatLengthArgument, result.Length);
            Assert.AreEqual(_boatTypeArgument, result.Type);
        }

        #endregion
    }
}
