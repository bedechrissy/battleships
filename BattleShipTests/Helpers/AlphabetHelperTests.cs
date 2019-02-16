using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips.Helpers;

namespace BattleShipTests
{
    /// <summary>
    /// Tests relating to the BattleShips program
    /// </summary>
    [TestClass]
    public class ProgramTests_AlphabetHelperTests
    {
        #region Private Fields

        /// <summary>
        /// Represents the returned alphabet character in string format
        /// </summary>
        private string _returnedLetter;

        /// <summary>
        /// Represents the returned numeric position for a given alphabet character
        /// </summary>
        private int _returnedPosition;

        #endregion

        #region Tests

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetLetterFromAlphabetPosition_WhenPositionIsLessThanOne_ExpectArgumentOutOfRangeExcpetion()
        {
            // Act
            try
            {
                var result = AlphabetHelper.GetLetterFromAlphabetPosition(-1);

            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
                throw ex;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetLetterFromAlphabetPosition_WhenPositionIsGreaterThanTwentySix_ExpectArgumentOutOfRangeExcpetion()
        {
            // Act
            try
            {
                var result = AlphabetHelper.GetLetterFromAlphabetPosition(27);

            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
                throw ex;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void GetLetterFromAlphabetPosition_WhenValidPositionProvided_ExpectCorrectLetterToBeReturned()
        {
            // Arrange
            _returnedLetter = "C";

            // Act
            var result = AlphabetHelper.GetLetterFromAlphabetPosition(3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_returnedLetter, result);
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void GetAlphabetPositionOfLetter_WhenLetterIsEmpty_ExpectFormatException()
        {
            // Act
            try
            {
                var result = AlphabetHelper.GetAlphabetPositionOfLetter(String.Empty);

            }
            catch (FormatException ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(FormatException));
                throw ex;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetAlphabetPositionOfLetter_WhenLetterIsNull_ExpectArgumentNullException()
        {
            // Act
            try
            {
                var result = AlphabetHelper.GetAlphabetPositionOfLetter(null);

            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                throw ex;
            }
        }
        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void GetAlphabetPositionOfLetter_WhenLetterIsWhiteSpace_ExpectArgumentException()
        {
            // Act
            try
            {
                var result = AlphabetHelper.GetAlphabetPositionOfLetter("  ");
            }
            catch (FormatException ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(FormatException));
                throw ex;
            }
        }

        /// <summary>
        /// Tests the operation under the specified circumstances
        /// </summary>
        [TestMethod]
        public void GetAlphabetPositionOfLetter_WhenValidLetterProvided_ExpectCorrectPositionToBeReturned()
        {
            // Arrange
            _returnedPosition = 18;

            // Act
            var result = AlphabetHelper.GetAlphabetPositionOfLetter("R");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_returnedPosition, result);
        }
        #endregion
    }
}
