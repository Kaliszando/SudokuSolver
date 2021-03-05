using System;
using NUnit.Framework;
using SudokuSolverApp.model;

namespace SudokuSolverTests.Tests
{
    [TestFixture]
    public class SudokuGridTest
    {
        private static readonly int[,] RawTable = 
        {
            {1, 2, 8, 4, 6, 9, 0, 5, 0},
            {0, 0, 0, 0, 0, 7, 9, 1, 0},
            {9, 4, 0, 0, 1, 5, 2, 6, 7},
            {7, 0, 0, 5, 8, 0, 0, 3, 0},
            {5, 1, 9, 3, 2, 0, 0, 0, 6},
            {0, 8, 6, 1, 7, 0, 5, 4, 0},
            {2, 0, 0, 0, 5, 8, 0, 0, 0},
            {8, 9, 0, 0, 0, 0, 6, 2, 0},
            {0, 0, 7, 0, 9, 0, 0, 8, 0}
        };
        private static readonly SudokuGrid TestGrid0 = new SudokuGrid();
        private static readonly SudokuGrid TestGrid = new SudokuGrid(RawTable);

        [Test]
        public void ConstructorTest_DefaultConstructor_CreateEmptySudokuGrid()
        {
            for (int i = 0; i < SudokuGrid.GridSize; i++)
            {
                for (int j = 0; j < SudokuGrid.GridSize; j++)
                {
                    Assert.AreEqual(0, TestGrid0[i, j]);
                }
            }
            Console.WriteLine(TestGrid0);
        }

        [Test]
        public void ConstructorTest_Pass2DArray_CreateSudokuGridFromArray()
        {
            for (int i = 0; i < SudokuGrid.GridSize; i++)
            {
                for (int j = 0; j < SudokuGrid.GridSize; j++)
                {
                    Assert.AreEqual(RawTable[i, j], TestGrid[i, j]);
                }
            }
            Console.WriteLine(TestGrid);
        }

        [Test]
        public void MultiIndexerTest_ChangeCellMultipleTimes_ChangeSuccessful()
        {
            SudokuGrid clonedGrid = TestGrid.Clone() as SudokuGrid;
            
            Assert.AreEqual(TestGrid, clonedGrid);

            clonedGrid[5, 5] = 2;
            Assert.AreEqual(2, clonedGrid[5, 5]);
            Assert.AreNotEqual(TestGrid, clonedGrid);
            
            clonedGrid[5, 5] = 3;
            Assert.AreEqual(3, clonedGrid[5, 5]);
            Assert.AreNotEqual(TestGrid, clonedGrid);
            
            clonedGrid[5, 5] = TestGrid[5, 5];
            Assert.AreEqual(TestGrid[5, 5], clonedGrid[5, 5]);
            Assert.AreEqual(TestGrid, clonedGrid);
        }

        [Test]
        public void CloneTest_MakeFewClones_AllClonesHaveTheSameValue()
        {
            SudokuGrid clone1 = TestGrid.Clone() as SudokuGrid;
            SudokuGrid clone2 = clone1.Clone() as SudokuGrid;
            SudokuGrid clone3 = clone2.Clone() as SudokuGrid;

           Assert.AreEqual(TestGrid, clone1);
           Assert.AreEqual(TestGrid, clone2);
           Assert.AreEqual(TestGrid, clone3);
           
           Assert.AreNotEqual((object) null, clone1);
           Assert.AreNotEqual(TestGrid0, clone2);
        }

        [Test]
        public void GetHashCode_TwoGridsWithTheSameValue_SameHashCode()
        {
            SudokuGrid clone1 = TestGrid.Clone() as SudokuGrid;
            SudokuGrid clone2 = TestGrid.Clone() as SudokuGrid;
            
            Assert.AreEqual(TestGrid, clone1);
            Assert.AreEqual(TestGrid, clone2);
            Assert.AreEqual(clone1, clone2);
            clone1[0, 0] = 9;
            Assert.AreNotEqual(clone1, clone2);
        }
    }
}