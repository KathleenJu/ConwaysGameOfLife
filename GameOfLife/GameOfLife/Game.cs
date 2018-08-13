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
            IterateGrid();
        }

        private void IterateGrid()
        {
            var livingCells = CurrentGrid.GetLivingCells().ToImmutableList();
            foreach (var cell in livingCells)
            {
                var numberOfNeighboursOfCell = CurrentGrid.GetNumberOfLivingNeighboursOfCell( cell);

                if (LiveEvolutionRules.CellLives(numberOfNeighboursOfCell))
                {
                    CurrentGrid.AddCell(cell);
                }

                if (DeadEvolutionRules.CellDies(numberOfNeighboursOfCell))
                {
                    CurrentGrid.RemoveCell(cell);
                }
            }
        }
    }
}