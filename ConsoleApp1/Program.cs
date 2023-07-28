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
                HeapSort(arr1);
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


            // var heapTest = new Heap01();
            // heapTest.TestFunc();


            Console.ReadKey();
        }

        // 堆排序 额外空间复杂度O(1)
        public static void HeapSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            // O(N*logN)
            //		for (int i = 0; i < arr.length; i++) { // O(N)
            //			heapInsert(arr, i); // O(logN)
            //		}

            //优化方法,在构建大根堆时 时间复杂度变为O(N)
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Heapify(arr, i, arr.Length);
            }
            int heapSize = arr.Length;
            Swap(arr, 0, --heapSize);
            // O(N*logN)
            while (heapSize > 0)
            { // O(N)
                Heapify(arr, 0, heapSize); // O(logN)
                Swap(arr, 0, --heapSize); // O(1)
            }
        }

        // arr[index]位置的数，能否往下移动
        public static void Heapify(int[] arr, int index, int heapSize)
        {
            int left = index * 2 + 1; // 左孩子的下标
            while (left < heapSize)
            { // 下方还有孩子的时候
                // 两个孩子中，谁的值大，把下标给largest
                // 1）只有左孩子，left -> largest
                // 2) 同时有左孩子和右孩子，右孩子的值<= 左孩子的值，left -> largest
                // 3) 同时有左孩子和右孩子并且右孩子的值> 左孩子的值， right -> largest
                int largest = left + 1 < heapSize && arr[left + 1] > arr[left] ? left + 1 : left;
                // 父和较大的孩子之间，谁的值大，把下标给largest
                largest = arr[largest] > arr[index] ? largest : index;
                if (largest == index)
                {
                    break;
                }
                Swap(arr, largest, index);
                index = largest;
                left = index * 2 + 1;
            }
        }


        /// <summary>
        /// 数组两个元素交换
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        /// <summary>
        /// 荷兰国旗问题,以arr[R]做区分值
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns>等于arr[R]的第一个索引和等于arr[R]的最后一个索引</returns>
        public static int[] NetherlandsFlag(int[] arr, int L, int R)
        {
            if (L > R)
            {
                return new int[] { -1, -1 };
            }
            if (L == R)
            {
                return new int[] { L, R };
            }
            int less = L - 1; // < 区 右边界
            int more = R;     // > 区 左边界
            int index = L;
            while (index < more)
            {
                if (arr[index] == arr[R])
                {
                    index++;
                }
                else if (arr[index] < arr[R])
                {
                    Swap(arr, index++, ++less);
                }
                else
                { // >
                    Swap(arr, index, --more);
                }
            }
            Swap(arr, more, R);
            return new int[] { less + 1, more };
        }

        /// <summary>
        /// 快排
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort3(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            Process3(arr, 0, arr.Length- 1);
        }


        public static void Process3(int[] arr, int L, int R)
        {
            if (L >= R)
            {
                return;
            }
            //随机从数组中取一个值与最后一个值做交换
           // Swap(arr, L + (int)(new Random().NextDouble() * (R - L + 1)), R);


            int[] equalArea = NetherlandsFlag(arr, L, R);
            Process3(arr, L, equalArea[0] - 1);
            Process3(arr, equalArea[1] + 1, R);
        }

        /// <summary>
        /// 归并排序(递归)
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort1(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            Process(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// 归并排序(遍历)
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort2(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }

            var mergeSize = 1;
            var N = arr.Length;

            while (mergeSize<=N)
            {
                //左组
                var L = 0;

                while (L<N)
                {
                    var M = L + mergeSize - 1;

                    if (M >= N)
                    {
                        break;
                    }

                    //右组
                    //var rightBegin = M + 1;
                    var R = Math.Min(M + mergeSize, N - 1);

                    Merge(arr, L, M, R);

                    L = R+1;

                }

                if (mergeSize> N/2)
                {
                    break;
                }

                mergeSize <<= 1;
            }
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

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            // 0 ~ N-1
            // 1~n-1
            // 2
            for (int i = 0; i < arr.Length - 1; i++)
            { // i ~ N-1
                // 最小值在哪个位置上  i～n-1
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                { // i ~ N-1 上找最小值的下标 
                    minIndex = arr[j] < arr[minIndex] ? j : minIndex;
                }
                Swap(arr, i, minIndex);
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            // 0~0 有序的
            // 0~i 想有序
            for (int i = 1; i < arr.Length; i++)
            { // 0 ~ i 做到有序
                for (int j = i - 1; j >= 0 && arr[j] > arr[j + 1]; j--)
                {
                    Swap(arr, j, j + 1);
                }
            }
        }
    }
}
