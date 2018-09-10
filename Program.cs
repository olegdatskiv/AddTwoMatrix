using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrixFirst = new Matrix();
            Matrix matrixSecond = new Matrix();

            MatrixAdder.CountTimeParallelAddition(matrixFirst, matrixSecond,4);
            MatrixAdder.CountTimeSimpleAddition(matrixFirst, matrixSecond); 
        }
    }
}
