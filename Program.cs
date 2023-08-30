using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    internal class Program
    {
        //Merge Sort
        //1.Divide the collection into smaller subsets, till we have 1 element in each sub set
        //2. recursively sort and merge the subsets 
        //3. Divide and conquer
        static void Main(string[] args)
        {
                       
            int[] nums = { 2, 5, 7, 3, 5, 9, 44, 27 };
            int[] soertedarry = MergeSort(nums);
            
            foreach (int num in soertedarry)
            { 
            Console.WriteLine(num);
            }
        }


        static void executeSort(int[] nums)
        {

            var sortedNumbers = MergeSort(nums);
        
        for (int i=0; i< sortedNumbers.Length; i++) 
            {
                nums[i] = sortedNumbers[i];
            
            }
                
                }
        static int[] MergeSort(int[] nums)
        {
            if (nums.Length <= 1) return nums; //Base case

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 > 0)
                {
                    left.Add(nums[i]);
                }
                else
                {

                    right.Add(nums[i]);
                }

                left = MergeSort(left.ToArray()).ToList();
                right = MergeSort(right.ToArray()).ToList();
            }

            return Merge(left, right);
        }


        static int[] Merge(List<int> left, List<int> right)
        {

            var result = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                    MoveToResult(left, result);

                else
                {
                    MoveToResult(right, result);
                }

            }

            while (left.Count > 0)
                {
                MoveToResult(left, result);
            }

            while (right.Count > 0)
            {
                MoveToResult(right, result);
            }
        return result.ToArray();
        }

        private static bool NotEmpty(List<int> list)
        {
            return list.Count > 0;
        }

        private static void MoveToResult(List<int> list, List<int> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }
    }



}


