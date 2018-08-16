﻿using System.Collections.Generic;
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
            var allLiveNeighboursOfLiveCell = new List<IEnumerable<Cell>>();
            
            IterateGrid(allDeadNeighboursOfLiveCell, allLiveNeighboursOfLiveCell);
            
            var cellsThatShouldLive = LiveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCell);
            var cellsThatShouldDie = DeadEvolutionRules.GetLiveCellsThatShouldDie(allLiveNeighboursOfLiveCell, Grid.GetLivingCells());

            UpdateGrid(cellsThatShouldLive, cellsThatShouldDie);
        }

        private void IterateGrid(List<IEnumerable<Cell>> allDeadNeighboursOfLiveCell, List<IEnumerable<Cell>> allLiveNeighboursOfLiveCell)
        {
            foreach (var cell in Grid.GetLivingCells())
            {
                allDeadNeighboursOfLiveCell.Add(Grid.GetDeadNeighboursOfLivingCell(cell));
                allLiveNeighboursOfLiveCell.Add(Grid.GetLiveNeighboursOfLivingCell(cell));
            }
        }

        private void UpdateGrid(List<Cell> cellsThatShouldLive, List<Cell> cellsThatShouldDie)
        {
            cellsThatShouldLive.ForEach(cell => { Grid.AddCell(cell); });
            cellsThatShouldDie.ForEach(cell => { Grid.RemoveCell(cell); });
        }
    }
}