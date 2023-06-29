using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {

        public static string ExtractNumber(string input)
        {
            string pattern = @"(?<=\D|^)\d{6}(?=\D|$)|(?<=\D|^)\d{7}(?=\D|$)";
            Match match = Regex.Match(input, pattern);
            return match.Success ? match.Value : null;
        }
        static void Main(string[] args)
        {

            //Console.WriteLine(ExtractNumber("抚州市第一医院;#;#"));

            for (int i = 0; i < 10; i++)
            {
                var arr = GenerateRandomArray(10, 100);
                Console.WriteLine(ArrayToString(arr));
                Console.WriteLine("================================");
            }
            Console.ReadKey();
        }

        public static string ArrayToString(int[] arr)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i!=0)
                {
                    sb.Append(",");
                }

                sb.Append(arr[i]);
            }
            return sb.ToString();
        }

        public static int[] GenerateRandomArray(int maxSize, int maxValue)
        {
            var random = new Random();
            int[] arr = new int[(int)((maxSize + 1) * random.NextDouble())];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (int)((maxValue + 1) * random.NextDouble()) - (int)(maxValue * random.NextDouble());

            }

            return arr;
        }
    }
}
