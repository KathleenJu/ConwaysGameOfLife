using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        public Grid CurrentGrid { get; }
        private DeadEvolutionRules DeadEvolutionRules;
        private LiveEvolutionRules LiveEvolutionRules;
        
        
        public Game(Grid currentGrid)
        {
            CurrentGrid = currentGrid;
            DeadEvolutionRules = new DeadEvolutionRules();
            LiveEvolutionRules = new LiveEvolutionRules();
        }

        public void SetInitialStateOfGrid(List<Cell> livingCells)
        {
            livingCells.ForEach(cell => CurrentGrid.AddCell(cell));
        }

        public void Evolve()
        {
            
        }
    }
}