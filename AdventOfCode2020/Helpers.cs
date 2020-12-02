using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    internal static class Helpers
    {
        internal static int[] FindSum(int[] arr, int[] data, int start, int end, int index, int r, int target)
        {
            if (index == r)
            {
                if (data.Sum() == target)
                {
                    return data;
                }
                return null;
            }

            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                var d = FindSum(arr, data, i + 1, end, index + 1, r, target);
                if (d != null)
                {
                    return d;
                }
            }
            return null;
        }

    }
}
