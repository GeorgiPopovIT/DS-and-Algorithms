namespace _05._Quick_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            QuickSort(input,0,input.Length - 1);
            Console.WriteLine(string.Join(" ", input));
        }

        private static void QuickSort(int[] input, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (input[left] > input[pivot] &&
                    input[right] < input[pivot])
                {
                    Swap(input, left, right);
                }

                if (input[left] <= input[pivot])
                {
                    left += 1;
                }

                if (input[right] >= input[pivot])
                {
                    right -= 1;
                }
            }

            Swap(input, pivot, right);

            QuickSort(input, start, right - 1);
            QuickSort(input, right + 1, end);
        }


        private static void Swap(int[] input, int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
