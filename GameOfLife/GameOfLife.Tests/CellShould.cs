using Xunit;

namespace GameOfLife.Tests
{
    public class CellShould
    {
        [Fact]
        public void ReturnTrueIfCellsHaveEqualValuOfRowAndColumn()
        {
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 1);
            var isEqual = cell1.Equals(cell2);

            Assert.True(isEqual);
        }

        [Fact]
        public void ReturnFalseIfCellsHaveEqualValueOfRowOnly()
        {
            var cell1 = new Cell(1, 0);
            var cell2 = new Cell(1, 1);
            var isEqual = cell1.Equals(cell2);

            Assert.False(isEqual);
        }

        [Fact]
        public void ReturnFalseIfCellsHaveEqualValueOfColumnOnly()
        {
            var cell1 = new Cell(0, 1);
            var cell2 = new Cell(1, 1);
            var isEqual = cell1.Equals(cell2);

            Assert.False(isEqual);
        }
    }
}