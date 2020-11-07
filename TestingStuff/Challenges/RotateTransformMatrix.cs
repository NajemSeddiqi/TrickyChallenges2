using System;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    public class RotateTransformMatrix : IChallenge
    {
        public static int[,] RotateTransform(int[,] arr, int num)
        {
            return num < 0 ? RotateCounterClockWise(arr, (num) * (-1)) : RotateClockWise(arr, num);
        }

        private static int[,] RotateClockWise(int[,] source, int num)
        {
            int[,] target = null;
            while (num != 0)
            {
                target = new int[source.GetLength(0), source.GetLength(0)];
                var n = source.GetLength(0);
                for (var i = 0; i < n; ++i)
                for (var j = 0; j < n; ++j)
                    target[i, j] = source[n - j - 1, i];

                source = target;
                num--;
            }

            return target;
        }

        private static int[,] RotateCounterClockWise(int[,] source, int num)
        {
            int[,] target = null;
            while (num > 0)
            {
                target = new int[source.GetLength(0), source.GetLength(0)];
                var n = source.GetLength(0);
                for (int i = 0, y = n - 1; i < n; i++, y--)
                for (int j = 0, x = 0; j < n; j++, x++)
                    target[i, j] = source[x, y];

                source = target;
                num--;
            }

            return target;
        }

        public void Show()
        {
            RotateTransform(new[,]
            {
                {4, 3, 1, 2},
                {2, 1, 3, 4},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            }, -2);
        }
    }
}