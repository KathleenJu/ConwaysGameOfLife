namespace GameOfLife
{
    public class Cell
    {
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(Cell cell)
        {
            return cell.Row == Row && cell.Column == Column;
        }
    }
}