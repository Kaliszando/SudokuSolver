using System;
using NUnit.Framework;
using SudokuSolverApp.controller;
using SudokuSolverApp.model;

namespace SudokuSolverTests.Tests
{
    [TestFixture]
    public class SudokuSolverTest
    {
        private static readonly int[,] RawTable = 
        {
            {1, 2, 8, 0, 6, 9, 0, 5, 0},
            {0, 0, 0, 0, 0, 7, 9, 1, 0},
            {9, 4, 0, 0, 1, 5, 2, 6, 7},
            {7, 0, 0, 5, 8, 0, 0, 3, 0},
            {5, 1, 9, 3, 2, 0, 0, 0, 6},
            {0, 8, 6, 1, 7, 0, 5, 4, 0},
            {2, 0, 0, 0, 5, 8, 0, 0, 0},
            {8, 9, 0, 0, 0, 0, 6, 2, 0},
            {0, 0, 7, 0, 9, 0, 0, 8, 0}
        };
        private static readonly SudokuGrid TestGrid = new SudokuGrid(RawTable);

        [Test]
        public void ConstructorTest_PassTestGrid_ClonedGridIntoSudokuSolver()
        {
            SudokuSolver solver = new SudokuSolver(TestGrid);
            
            Assert.False(solver.ValidatePlace(0, 6, 1));
            Assert.False(solver.ValidatePlace(0, 6, 2));
            
            // only 3 and 4 are valid in cell (0,6)
            Assert.True(solver.ValidatePlace(0, 6, 3));
            Assert.True(solver.ValidatePlace(0, 6, 4));
            
            Assert.False(solver.ValidatePlace(0, 6, 5));
            Assert.False(solver.ValidatePlace(0, 6, 6));
            Assert.False(solver.ValidatePlace(0, 6, 7));
            Assert.False(solver.ValidatePlace(0, 6, 8));
            Assert.False(solver.ValidatePlace(0, 6, 9));
        }
        
    }
}
