using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {

      
        static void Main(string[] args)
        {

            // for (int i = 0; i < 10; i++)
            // {
            //     var arr = GenerateRandomArray(10, 100);
            //     Console.WriteLine(ArrayToString(arr));
            //     Console.WriteLine("================================");
            // }
            //
            // var node = new Node(1);
            // var node2 = new Node(2);
            // var node3 = new Node(3);
            // var node4 = new Node(4);
            // node.Next = node2;
            // node2.Next = node3;
            // node3.Next = node4;
            // PrintLinkList(node);
            // var rNode  = ReverseLinkedList(node);
            // PrintLinkList(rNode);


            int testTime = 500000;
            int maxSize = 100;
            int maxValue = 100;
            bool succeed = true;
            for (int i = 0; i < testTime; i++)
            {
                int[] arr1 = GenerateRandomArray(maxSize, maxValue);
                int[] arr2 = CopyArray(arr1);
                MergeSort1(arr1);
                Array.Sort(arr2);
                if (!IsEqual(arr1, arr2))
                {
                    succeed = false;
                    ArrayToString(arr1);
                    ArrayToString(arr2);
                    break;
                }
            }
            Console.WriteLine(succeed ? "Nice!" : "Oops!");


            Console.ReadKey();
        }

        public static void MergeSort1(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            Process(arr, 0, arr.Length - 1);
        }

        public static void Process(int[] arr, int L, int R)
        {
            if (L<R)
            {
                var M = L+ ((R-L)>>1);
                Process(arr, L, M);
                Process(arr, M + 1, R);
                Merge(arr, L, M, R);
            }
        }

        public static void Merge(int[] arr, int L, int M, int R)
        {
            var help = new int[R-L+1];
            var i = 0;
            var LIndex = L;
            var RIndex = M+1;

            while (LIndex<=M&&RIndex<=R)
            {
                help[i++] = arr[LIndex] <= arr[RIndex]? arr[LIndex++] : arr[RIndex++];
            }

            if (LIndex<=M)
            {
                while (LIndex<=M)
                {
                    help[i++] = arr[LIndex++];
                }
            }

            if (RIndex<=R)
            {
                while (RIndex<=R)
                {
                    help[i++] = arr[RIndex++];
                }
            }

            // var k = 0;
            // for (int j = L; j < R; j++)
            // {
            //     arr[j]= help[k++]; 
            // }

            for (int j = 0; j < help.Length; j++)
            {
                arr[L+j] = help[j];
            }


        }

        /// <summary>
        /// 比较2个数组是否相等
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static bool IsEqual(int[] arr1, int[] arr2)
        {
            if ((arr1 == null && arr2 != null) || (arr1 != null && arr2 == null))
            {
                return false;
            }
            if (arr1 == null && arr2 == null)
            {
                return true;
            }
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
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
        /// <summary>
        /// copy 数组
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] CopyArray(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }
            return res;
        }

        /// <summary>
        /// 打印单项链表
        /// </summary>
        /// <param name="head"></param>
        public static void PrintLinkList(Node head)
        {
            if (head==null)
            {
                return;
            }

            do
            {
                Console.WriteLine(head.Value);
                head = head.Next;
            } while (head!=null);
        }

        /// <summary>
        /// 反转单项链表,返回新头
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Node ReverseLinkedList(Node head)
        {
            if (head==null||head.Next==null)
            {
                return head;
            }

            Node pre = null;

            while (head!=null)
            {
                var next = head.Next;
                head.Next = pre;
                pre = head;
                head = next;
            }

            return pre;
            
        }
    }
}
