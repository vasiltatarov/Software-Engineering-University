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
    }
}
