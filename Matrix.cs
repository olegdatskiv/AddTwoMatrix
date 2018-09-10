using System.Threading;
using System;

namespace AddMatrix
{
    class Matrix
    {
        public int[,] Elements { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Matrix()
        {
            Height = Width = 10000;

            Random rnd = new Random();

            Elements = new int[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Elements[i, j] = rnd.Next(1000);
                }
            }
        }

        public Matrix(int[,] matrix)
        {
            if (matrix != null)
                Elements = matrix;
        }

        public void AddMatrix(Matrix matrix)
        {
            if (matrix == null)
                return;
            if (Height != matrix.Height || Width != matrix.Width)
                return;
            

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Elements[i, j] += matrix.Elements[i, j];
                }
            }
            
        }

        public void AddMatrixParallel(Matrix matrix,int numberOfThreads)
        {
            if (matrix == null)
                return;
            if (Height != matrix.Height || Width != matrix.Width)
                return;

            numberOfThreads = Math.Min(numberOfThreads, this.Height);

            Thread[] threads = new Thread[numberOfThreads];

            double height = this.Height;

            int step = (int)Math.Ceiling(height/ numberOfThreads);

            for (int i = 0; i < numberOfThreads; i++)
            {

                int firstCoeficient = (Height / numberOfThreads) * i;
                int lastCoeficient = (Height / numberOfThreads) * (i + 1);

                threads[i] = new Thread(() =>
                {
                    if (i == (numberOfThreads - 1))
                        lastCoeficient = Height;

                    for (int j = firstCoeficient; j < lastCoeficient; j++)
                    {
                        for (int k = 0; k < this.Width ; k++)
                        {
                            Elements[j, k] += matrix.Elements[j, k];
                        }
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
    }
}
