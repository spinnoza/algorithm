using System;
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

            var node = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            node.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            PrintLinkList(node);
            var rNode  = ReverseLinkedList(node);
            PrintLinkList(rNode);


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
