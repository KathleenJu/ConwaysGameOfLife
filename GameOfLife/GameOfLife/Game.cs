using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        public Grid Grid { get; }
        private readonly DeadEvolutionRules DeadEvolutionRules;
        private readonly LiveEvolutionRules LiveEvolutionRules;


        public Game(Grid grid)
        {
            Grid = grid;
            DeadEvolutionRules = new DeadEvolutionRules();
            LiveEvolutionRules = new LiveEvolutionRules();
//            SetInitialStateOfGrid();
//            Evolve();
        }

        public void SetInitialStateOfGrid(List<Cell> livingCells)
        {
            livingCells.ForEach(cell => Grid.AddCell(cell));
        }

        public void Evolve()
        {
            var allDeadNeighboursOfLiveCell = new List<IEnumerable<Cell>>();
            foreach (var cell in Grid.GetLivingCells())
            {
                allDeadNeighboursOfLiveCell.Add(Grid.GetDeadNeighboursOfLivingCell(cell));
            }
            var cellsThatShouldLive = LiveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCell);
            
            var allLiveNeighboursOfLiveCell = new List<IEnumerable<Cell>>();
            foreach (var cell in Grid.GetLivingCells())
            {
                allLiveNeighboursOfLiveCell.Add(Grid.GetLiveNeighboursOfLivingCell(cell));
            }
            var cellsThatShouldDie = DeadEvolutionRules.GetLiveCellsThatShouldDie(Grid.GetLivingCells());

            cellsThatShouldLive.ForEach(cell =>
            {
                Grid.AddCell(cell);
            });
            
            cellsThatShouldDie.ForEach(cell =>
            {
                Grid.RemoveCell(cell);
            });
        }

        private void IterateGrid()
        {
        }
    }
}