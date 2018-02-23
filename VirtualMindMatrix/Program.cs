using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMindMatrix
{
    class Program
    {
        //Cristian Giagante (cristiangiagante@hotmail.com)
        /*
         We want to find 1's square in a binary matrix.
         There's only ONE square.
        */
        static void Main(string[] args)
        {
            var matrix = new int[,]
            {
                { 0,0,0,0,0 },
                { 0,0,0,0,0 },
                { 0,0,1,1,0 },
                { 0,0,1,1,0 },
                { 0,0,0,0,0 }
            };
            FindSquareSize(matrix);
        }

        public static int FindSquareSize(int[,] matrix)
        {
            var columnReference = matrix.Rank - 1;
            var rowReference = columnReference - 1;
            StringBuilder matrixRow = new StringBuilder();
            List<string> stringRows = new List<string>();

            for (int i = 0; i <= matrix.GetLength(rowReference) - 1; i++)
            {
                for (int j = 0; j <= matrix.GetLength(columnReference) - 1; j++)
                {
                    matrixRow.Append(matrix[i, j]);
                }
                stringRows.Add(matrixRow.ToString());
                matrixRow.Clear();
            }
            matrixRow = null;
            for (int i = 0; i <= stringRows.Count - 1; i++) 
            {
                if (!stringRows[i].Contains("1"))
                {
                    stringRows.Remove(stringRows[i]);
                    i--;
                }
            }
            if (stringRows.Count.Equals(1))
            {
                return 1;
            }
            else
            {
                var squareCharsCounter = 0;
                bool matchPrevious = false;
                for (int i = 0; i <= stringRows.Count - 1; i++)
                {
                    if (stringRows.Count-1>=i+1 && !stringRows[i].Equals(stringRows[i + 1]))
                    {
                        if (matchPrevious)
                            i++;
                        stringRows.Remove(stringRows[i]);
                        i-=2;
                    }
                    else
                    {
                        matchPrevious = true;
                        squareCharsCounter += stringRows[i].Count(x => x == '1');
                    }
                    
                }
                return squareCharsCounter;
            }
        }
    }
}
