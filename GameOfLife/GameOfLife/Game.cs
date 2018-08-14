using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        public Grid CurrentGrid { get; }
        private readonly DeadEvolutionRules DeadEvolutionRules;
        private readonly LiveEvolutionRules LiveEvolutionRules;


        public Game(Grid currentGrid)
        {
            CurrentGrid = currentGrid;
            DeadEvolutionRules = new DeadEvolutionRules();
            LiveEvolutionRules = new LiveEvolutionRules();
//            SetInitialStateOfGrid();
//            Evolve();
        }

        public void SetInitialStateOfGrid(List<Cell> livingCells)
        {
            livingCells.ForEach(cell => CurrentGrid.AddCell(cell));
        }

        public void Evolve()
        {
//            while (true)
//            {
                IterateGrid();
//            }
        }

        private void IterateGrid()
        {
            var livingCells = CurrentGrid.GetLivingCells().ToList();
            var listOfAllNeighboursForLivingCells = new List<IEnumerable<Cell>>();

            foreach (var cell in livingCells)
            {
                var numberOfNeighboursOfCell = CurrentGrid.GetNumberOfLivingNeighboursOfCell(cell);
                var livingNeighbouringCellsofCell = CurrentGrid.GetLivingNeighbouringCellsofCell(cell);
                listOfAllNeighboursForLivingCells.Add(livingNeighbouringCellsofCell);

                if (LiveEvolutionRules.GetCellsThatShouldLive(livingNeighbouringCellsofCell, listOfAllNeighboursForLivingCells))
                {
                    if (!livingCells.Contains(cell))
                    {
                        CurrentGrid.AddCell(cell);
                    }
                }
                if (DeadEvolutionRules.CellDies(livingNeighbouringCellsofCell))
                {
                    CurrentGrid.RemoveCell(cell);
                }
            }
        }
    }
}