namespace PowerList.Test
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Models;

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

        [Fact]
        public void AddAtBottomShouldAddNewItemAtTheBottomOfTheCollection()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act
            powerList.AddAtBottom(2);
            powerList.AddAtBottom(34);

            // Assert
            Assert.Equal(2, powerList.Count);
            Assert.Equal(34, powerList[0]);
        }

        [Fact]
        public void AddRangeShouldAddRangeOfItemsAtTheCollection()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act
            powerList.AddRange(new List<int> { 1, 2, 3, 4 });

            // Assert
            Assert.Equal(4, powerList.Count);
        }

        [Fact]
        public void InsertShouldAddItemAtTheGivenIndex()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act
            powerList.Add(123);
            powerList.Insert(0, 12);

            // Assert
            Assert.Equal(2, powerList.Count);
            Assert.Equal(12, powerList[0]);
        }

        [Fact]
        public void InsertShouldThrowExceptionWhenIndexIsInvalid()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => powerList.Insert(1, 12));
        }

        [Fact]
        public void ClearShouldRemoveAllItemInTheCollectionAndShouldHaveCountZero()
        {
            // Arrange
            var powerList = new PowerList<int>();
            powerList.Add(23);

            // Act
            powerList.Clear();

            // Assert
            Assert.Empty(powerList);
            Assert.Equal(0, powerList.Count);
        }

        [Fact]
        public void ReverseShouldReverseAllItemsInTheCollection()
        {
            // Arrange
            var powerList = new PowerList<int> { 1, 2, 3, 4, 5 };

            // Act
            powerList.Reverse();

            // Assert
            Assert.Equal(1, powerList[4]);
            Assert.Equal(5, powerList[0]);
            Assert.Equal(5, powerList.Count);
        }

        [Fact]
        public void ReverseShouldDoNothingWhenCollectionHaveOneItem()
        {
            // Arrange
            var powerList = new PowerList<int> { 1 };

            // Act
            powerList.Reverse();

            // Assert
            Assert.Equal(1, powerList[0]);
            Assert.Equal(1, powerList.Count);
        }

        [Fact]
        public void RemoveFirstShouldRemoveItemAtTheFirstIndexAndShouldReturnIt()
        {
            // Arrange
            var powerList = new PowerList<int> { 1, 2, 3 };

            // Act
            var removedItem = powerList.RemoveFirst();

            // Assert
            Assert.Equal(2, powerList[0]);
            Assert.Equal(1, removedItem);
            Assert.Equal(2, powerList.Count);
        }

        [Fact]
        public void RemoveFirstShouldThrowExceptionWhenCollectionIsEmpty()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => powerList.RemoveFirst());
        }

        [Fact]
        public void RemoveLastShouldRemoveItemAtTheLastIndexAndShouldReturnIt()
        {
            // Arrange
            var powerList = new PowerList<int> { 1, 2, 3 };

            // Act
            var removedItem = powerList.RemoveLast();

            // Assert
            Assert.Equal(1, powerList[0]);
            Assert.Equal(3, removedItem);
            Assert.Equal(2, powerList.Count);
        }

        [Fact]
        public void RemoveLastShouldThrowExceptionWhenCollectionIsEmpty()
        {
            // Arrange
            var powerList = new PowerList<int>();

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => powerList.RemoveLast());
        }

        [Fact]
        public void SortShouldSortAllItemsInTheCollectionWithoutComparison()
        {
            // Arrange
            var powerList = new PowerList<int> { 2, 5, 1 };

            // Act
            powerList.Sort();

            // Assert
            Assert.Equal(3, powerList.Count);
            Assert.Equal(1, powerList[0]);
            Assert.Equal(2, powerList[1]);
            Assert.Equal(5, powerList[2]);
        }

        [Fact]
        public void SortShouldReturnMethodWhenCollectionHaveOneOrLessThanOneItems()
        {
            // Arrange
            var powerList = new PowerList<int> { 2 };

            // Act
            powerList.Sort();

            // Assert
            Assert.Equal(1, powerList.Count);
            Assert.Equal(2, powerList[0]);
        }

        [Fact]
        public void SortShouldSortAllPersonByAgeWithComparison()
        {
            // Arrange
            var powerList = new PowerList<Person>();
            powerList.AddRange(new[]
            {
                new Person("Ahmed", 24),
                new Person("vasko", 21),
                new Person("Ivan", 33),
            });

            // Act
            powerList.Sort((a, b) => a.Age.CompareTo(b.Age));

            // Assert
            Assert.Equal(3, powerList.Count);
            Assert.Equal(21, powerList[0].Age);
            Assert.Equal(24, powerList[1].Age);
            Assert.Equal(33, powerList[2].Age);
        }

        [Fact]
        public void SortShouldSortAllPersonByNameAscendingWithComparison()
        {
            // Arrange
            var powerList = new PowerList<Person>();
            powerList.AddRange(new[]
            {
                new Person("Ahmed", 24),
                new Person("vasko", 21),
                new Person("Ivan", 33),
            });

            // Act
            powerList.Sort((a, b) => String.Compare(a.Name, b.Name, StringComparison.Ordinal));

            // Assert
            Assert.Equal(3, powerList.Count);
            Assert.Equal("Ahmed", powerList[0].Name);
            Assert.Equal("Ivan", powerList[1].Name);
            Assert.Equal("vasko", powerList[2].Name);
        }

        [Fact]
        public void SortShouldSortAllPersonByNameDescendingWithComparison()
        {
            // Arrange
            var powerList = new PowerList<Person>();
            powerList.AddRange(new[]
            {
                new Person("Ahmed", 24),
                new Person("vasko", 21),
                new Person("Ivan", 33),
            });

            // Act
            powerList.Sort((a, b) => String.Compare(b.Name, a.Name, StringComparison.Ordinal));

            // Assert
            Assert.Equal(3, powerList.Count);
            Assert.Equal("vasko", powerList[0].Name);
            Assert.Equal("Ivan", powerList[1].Name);
            Assert.Equal("Ahmed", powerList[2].Name);
        }
    }
}
