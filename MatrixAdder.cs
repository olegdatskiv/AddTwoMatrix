using System.Diagnostics;
using System;

namespace AddMatrix
{
    class MatrixAdder
    {
        public static void CountTimeSimpleAddition(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix == null)
                return;
            if (secondMatrix == null)
                return;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            firstMatrix.AddMatrix(secondMatrix);
            stopwatch.Stop();

            string retVal = $"Simple addition took {stopwatch.ElapsedMilliseconds} miliseconds.";

            //for (int i = 0; i < firstMatrix.Height; i++)
            //{
            //    for (int j = 0; j < firstMatrix.Width; j++)
            //    {
            //        Console.Write("{0} ", firstMatrix.Elements[i, j]);
            //    }
            //    Console.Write("\n");
            //}
            Console.Write("\n");
            Console.WriteLine(retVal);
            Console.Write("\n");
        }


        public static void CountTimeParallelAddition(Matrix firstMatrix, Matrix secondMatrix,int numberOfThreads)
        {
            if (firstMatrix == null)
                firstMatrix = new Matrix();
            if (secondMatrix == null)
                secondMatrix = new Matrix();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            firstMatrix.AddMatrixParallel(secondMatrix,numberOfThreads);
            stopwatch.Stop();

            string retVal = $"Parallel addition took {stopwatch.ElapsedMilliseconds} miliseconds.";

            //for (int i = 0; i < firstMatrix.Height; i++)
            //{
            //    for (int j = 0; j < firstMatrix.Width; j++)
            //    {
            //        Console.Write("{0} ", firstMatrix.Elements[i, j]);
            //    }
            //    Console.Write("\n");
            //}

            Console.Write("\n");
            Console.WriteLine(retVal);
            Console.Write("\n");
        }
    }
}
