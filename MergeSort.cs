using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ouaiouai
{
    public static class MergeSort
    {
        public static void Sort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                Sort(array, start, middle);
                Sort(array, middle + 1, end);
                Merge(array, start, middle, end);
            }
        }

        private static void Merge<T>(T[] array, int start, int middle, int end) where T : IComparable<T>
        {
            T[] left = new T[middle - start + 1];
            T[] right = new T[end - middle];

            Array.Copy(array, start, left, 0, middle - start + 1);
            Array.Copy(array, middle + 1, right, 0, end - middle);

            int i = 0;
            int j = 0;
            int k = start;

            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }

}
