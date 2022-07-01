namespace _06._Merge_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            var sorted = MergeSort(input);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] input)
        {
            if (input.Length <=1)
            {

            }
        }

        private static void Swap(int[] input, int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
