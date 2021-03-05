using System;
using System.IO;

namespace SudokuSolverApp.model
{
    public class SudokuGrid : ICloneable, IEquatable<SudokuGrid>
    {
        public const int GridSize = 9;
        public const int InternalGridSize = 3;
        private int[,] Grid = 
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        // constructors
        public SudokuGrid() {}

        public SudokuGrid(int[,] passedGrid) => Grid = (int[,]) passedGrid.Clone();

        
        // to string method
        public override String ToString()
        {
            String gridString = "";
            for (var r = 0; r < GridSize; r++)
            {
                for (var c = 0; c < GridSize; c++)
                {
                    gridString += Grid[r, c] + " ";
                }
                gridString += "\n";
            }
            return gridString;
        }

        // clone method using IClonable
        public object Clone()
        {
            return new SudokuGrid(Grid);
        }
        
        // multidimensional indexer
        public int this[int index1, int index2]
        {
            get
            {
                return Grid[index1, index2];
            }
            set
            {
                Grid[index1, index2] = value;
            }
        }

        public override int GetHashCode()
        {
            return (Grid != null ? this.ToString().GetHashCode() : 0);
        }
        
        public bool Equals(SudokuGrid other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.GetType() != other.GetType()) return false;
            return other.GetHashCode() == this.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SudokuGrid);
        }
    }
}