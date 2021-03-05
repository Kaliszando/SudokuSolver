using System;
using System.Runtime.InteropServices;
using SudokuSolverApp.model;

namespace SudokuSolverApp.controller
{
    public class SudokuSolver
    {
        private SudokuGrid Puzzle;

        public SudokuSolver(SudokuGrid baseGrid) => Puzzle = baseGrid.Clone() as SudokuGrid;

        public bool ValidatePlace(int r, int c, int desiredValue)
        {
            for (int i = 0; i < SudokuGrid.GridSize; i++)
            {
                // check horizontal
                if (Puzzle[r, i] == desiredValue) return false;
                // check vertical
                if (Puzzle[i, c] == desiredValue) return false;
            }

            // check internal square
            int r0 = (r / 3) * 3;
            int c0 = (c / 3) * 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Puzzle[i + r0, j + c0] == desiredValue) return false;
                }
            }
            return true;
        }

        public void Solve()
        {
            for (int i = 0; i < SudokuGrid.GridSize; i++)
            {
                for (int j = 0; j < SudokuGrid.GridSize; j++)
                {
                    if (Puzzle[i, j] == 0)
                    {
                        for (int val = 1; val < 10; val++)
                        {
                            if (ValidatePlace(i, j, val))
                            {
                                Puzzle[i, j] = val;
                                Solve();
                                if (IsFilled()) return;
                                Puzzle[i, j] = 0;
                            }
                        }
                        return;
                    }
                }
            }
        }

        private bool IsFilled()
        {
            for (int i = 0; i < SudokuGrid.GridSize; i++)
            {
                for (int j = 0; j < SudokuGrid.GridSize; j++)
                {
                    if (Puzzle[i, j] == 0) return false;
                }
            }
            return true;
        }
        
        public override string ToString()
        {
            return Puzzle.ToString();
        }
    }
}