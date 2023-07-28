using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Heap01
    {
        public class MyMaxHeap
        {
            private int[] _heap;
            private readonly int _limit;
            private int _heapSize;

            public MyMaxHeap(int limit)
            {
                _heap = new int[limit];
                this._limit = limit;
                _heapSize = 0;
            }

            public bool IsEmpty()
            {
                return _heapSize == 0;
            }

            public bool IsFull()
            {
                return _heapSize == _limit;
            }

            public void Push(int value)
            {
                if (_heapSize == _limit)
                {
                    throw new Exception("heap is full");
                }
                _heap[_heapSize] = value;
                // value  heapSize
                HeapInsert(_heap, _heapSize++);
            }

            // 用户此时，让你返回最大值，并且在大根堆中，把最大值删掉
            // 剩下的数，依然保持大根堆组织
            public int Pop()
            {
                int ans = _heap[0];
                Swap(_heap, 0, --_heapSize);
                Heapify(_heap, 0, _heapSize);
                return ans;
            }

            private void HeapInsert(int[] arr, int index)
            {
                // arr[index]
                // arr[index] 不比 arr[index父]大了 ， 停
                // index = 0;
                while (arr[index] > arr[(index - 1) / 2])
                {
                    Swap(arr, index, (index - 1) / 2);
                    index = (index - 1) / 2;
                }
            }

            // 从index位置，往下看，不断的下沉，
            // 停：我的孩子都不再比我大；已经没孩子了
            private void Heapify(int[] arr, int index, int heapSize)
            {
                int left = index * 2 + 1;
                while (left < heapSize)
                {
                    // 左右两个孩子中，谁大，谁把自己的下标给largest
                    // 右  ->  1) 有右孩子   && 2）右孩子的值比左孩子大才行
                    // 否则，左
                    int largest = left + 1 < heapSize && arr[left + 1] > arr[left] ? left + 1 : left;
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

            private void Swap(int[] arr, int i, int j)
            {
                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }

        }

        public class RightMaxHeap
        {
            private int[] _arr;
            private readonly int _limit;
            private int _size;

            public RightMaxHeap(int limit)
            {
                _arr= new int[limit];
                this._limit= limit;
                _size = 0;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public bool IsFull()
            {
                return _size == _limit;
            }

            public void Push(int value)
            {
                if (_size == _limit)
                {
                    throw new Exception("heap is full");
                }
                _arr[_size++] = value;
            }

            public int Pop()
            {
                int maxIndex = 0;
                for (int i = 1; i < _size; i++)
                {
                    if (_arr[i] > _arr[maxIndex])
                    {
                        maxIndex = i;
                    }
                }
                int ans = _arr[maxIndex];
                _arr[maxIndex] = _arr[--_size];
                return ans;
            }

        }


        public void TestFunc()
        {
            int value = 1000;
            int limit = 100;
            int testTimes = 1000000;
            var random = new Random();
            for (int i = 0; i < testTimes; i++)
            {
                int curLimit = (int)(random.NextDouble() * limit) + 1;
                MyMaxHeap my = new MyMaxHeap(curLimit);
                RightMaxHeap test = new RightMaxHeap(curLimit);
                int curOpTimes = (int)(random.NextDouble() * limit);
                for (int j = 0; j < curOpTimes; j++)
                {
                    if (my.IsEmpty() != test.IsEmpty())
                    {
                        //System.out.println("Oops!");
                        Console.WriteLine("Oops!");
                    }
                    if (my.IsFull() != test.IsFull())
                    {
                        //System.out.println("Oops!");
                        Console.WriteLine("Oops!");
                    }
                    if (my.IsEmpty())
                    {
                        int curValue = (int)(random.NextDouble() * value);
                        my.Push(curValue);
                        test.Push(curValue);
                    }
                    else if (my.IsFull())
                    {
                        if (my.Pop() != test.Pop())
                        {
                            Console.WriteLine("Oops!");
                        }
                    }
                    else
                    {
                        if (random.NextDouble() < 0.5)
                        {
                            int curValue = (int)(random.NextDouble() * value);
                            my.Push(curValue);
                            test.Push(curValue);
                        }
                        else
                        {
                            if (my.Pop() != test.Pop())
                            {
                                // System.out.println("Oops!");
                                Console.WriteLine("Oops!");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("finish!");
            //Console.ReadKey();

        }
    }
}
