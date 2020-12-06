using System;
using System.Collections.Generic;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    public static class Helpers
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

        internal static string Except(this IEnumerable<string> inputs)
        {
            var temp = inputs.FirstOrDefault().ToCharArray();
            foreach (var item in inputs.Skip(1))
            {
                temp = temp.Except(item).ToArray();
            }
            return new string(temp);
        }

        internal static string Concat(this IEnumerable<string> inputs)
        {
            var temp = inputs.FirstOrDefault().ToCharArray();
            foreach (var item in inputs.Skip(1))
            {
                temp = temp.Concat(item).ToArray();
            }
            return new string(temp);
        }
        internal static string Intersect(this IEnumerable<string> inputs)
        {
            var temp = inputs.FirstOrDefault().ToCharArray();
            foreach (var item in inputs.Skip(1))
            {
                temp = temp.Intersect(item).ToArray();
            }
            return new string(temp);
        }
        internal static string Union(this IEnumerable<string> inputs)
        {
            var temp = inputs.FirstOrDefault().ToCharArray();
            foreach (var item in inputs.Skip(1))
            {
                temp = temp.Union(item).ToArray();
            }
            return new string(temp);
        }
    }
}
