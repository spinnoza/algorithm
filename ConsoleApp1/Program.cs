using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {

      
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                var arr = GenerateRandomArray(10, 100);
                Console.WriteLine(ArrayToString(arr));
                Console.WriteLine("================================");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 打印数组
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 生成随机整数数组
        /// </summary>
        /// <param name="maxSize"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
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
