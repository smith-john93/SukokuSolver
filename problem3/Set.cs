using System;
using System.Collections.Generic;
using System.Text;

namespace problem3
{
    public class Set
    {
        int setCount = 0;
        public Set()
        {

        }

        public void findSubsets(int[] array, int arraySize, List<int> intList, int goal)
        { 
            if (goal == 0)
            {
                setCount++;
                return;
            }

            if (arraySize == 0)
                return;

            findSubsets(array, arraySize - 1, intList, goal);
            List<int> tempList = new List<int>(intList);
            tempList.Add(array[arraySize - 1]);
            findSubsets(array, arraySize - 1, tempList, goal - array[arraySize - 1]);
        }

        public void run(int[] arr, int n, int sum)
        {
            List<int> v = new List<int>();
            findSubsets(arr, n, v, sum);
            Console.WriteLine($"Total number of subsets: {setCount}");
        }
    }
}
