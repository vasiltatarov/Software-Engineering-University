using System;

namespace PowerList.Test
{
    using Xunit;

    public class PowerListTests
    {
        [Fact]
        public void CountShouldReturnZeroWhenInitializeCollection()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act

            // Assert
            Assert.Equal(0, powerList.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        [InlineData(99)]
        public void AddShouldAddNewItemsAndIncreaseCountSuccessfully(int itemsCount)
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act
            for (int i = 1; i <= itemsCount; i++)
            {
                powerList.Add(i);
            }

            // Assert
            Assert.Equal(itemsCount, powerList.Count);
        }

        [Fact]
        public void GetByIndexShouldReturnItemSuccessfullyWhenIndexIsValid()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(777);

            // Act
            var item = powerList[0];

            // Assert
            Assert.Equal(777, item);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(99)]
        public void GetByIndexShouldReturnExceptionWhenIndexIsInvalid(int index)
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(777);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => powerList[index]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(99)]
        public void SetByIndexShouldReturnExceptionWhenIndexIsInvalid(int index)
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => powerList[index]);
        }

        [Fact]
        public void SetByIndexShouldSetItemSuccessfullyWhenIndexIsValid()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(988);

            // Act
            powerList[0] = 777;
            var item = powerList[0];

            // Assert
            Assert.Equal(777, item);
        }

        [Fact]
        public void ContainsShouldReturnTrueWhenItemExist()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(988);
            powerList.Add(1);
            powerList.Add(34);

            // Act
            var isExist = powerList.Contains(34);

            // Assert
            Assert.True(isExist);
        }

        [Fact]
        public void ContainsShouldReturnFalseWhenItemNotExist()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(988);
            powerList.Add(1);
            powerList.Add(34);

            // Act
            var isExist = powerList.Contains(55);

            // Assert
            Assert.False(isExist);
        }

        [Fact]
        public void IndexOfShouldReturnMinusZeroWhenItemNotExist()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(23);

            // Act
            var index = powerList.IndexOf(55);

            // Assert
            Assert.Equal(-1, index);
        }

        [Fact]
        public void IndexOfShouldReturnCorrectIndexWhenItemExist()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(23);
            powerList.Add(12);

            // Act
            var index = powerList.IndexOf(12);

            // Assert
            Assert.Equal(1, index);
        }

        [Fact]
        public void RemoveShouldReturnFalseWhenItemNotExist()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act
            var isRemoved = powerList.Remove(12);

            // Assert
            Assert.False(isRemoved);
        }

        [Fact]
        public void RemoveShouldReturnTrueWhenItemExistAndAlsoShouldReduceCount()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(12);
            powerList.Add(23);

            // Act
            var isRemoved = powerList.Remove(23);

            // Assert
            Assert.True(isRemoved);
            Assert.Equal(1, powerList.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(99)]
        public void RemoveAtShouldThrowExceptionWhenIndexIsInvalid(int index)
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => powerList.RemoveAt(index));
        }

        [Fact]
        public void RemoveAtShouldRemoveItemOfTheGivenIndexSuccessfully()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(12);
            powerList.Add(23);

            // Act
            powerList.RemoveAt(1);

            // Assert
            Assert.Equal(1, powerList.Count);
        }
    }
}
