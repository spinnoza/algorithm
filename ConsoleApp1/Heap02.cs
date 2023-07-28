using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Heap02
    {
        // 堆
        public class MyHeap<T>
        {
            private List<T> _heap;
            private Dictionary<T, int> _indexMap;
            private int _heapSize;
            private Comparer<T> _comparator;

            public MyHeap(Comparer<T> com)
            {
                _heap = new List<T>();
                _indexMap = new Dictionary<T, int>();
                _heapSize = 0;
                _comparator = com;
            }

            public bool IsEmpty()
            {
                return _heapSize == 0;
            }

            public int Size()
            {
                return _heapSize;
            }

            public bool Contains(T key)
            {
                return _indexMap.ContainsKey(key);
            }

            public void Push(T value)
            {
                _heap.Add(value);
                _indexMap.Add(value, _heapSize);
                HeapInsert(_heapSize++);
            }

            public T Pop()
            {
                T ans = _heap[0];
                int end = _heapSize - 1;
                Swap(0, end);
                _heap.RemoveAt(end);
                _indexMap.Remove(ans);
                Heapify(0, --_heapSize);
                return ans;
            }

            public void Resign(T value)
            {
                int valueIndex = _indexMap[value];
                HeapInsert(valueIndex);
                Heapify(valueIndex, _heapSize);
            }

            private void HeapInsert(int index)
            {
                while (_comparator.Compare(_heap[index], _heap[(index - 1) / 2]) < 0)
                {
                    Swap(index, (index - 1) / 2);
                    index = (index - 1) / 2;
                }
            }

            private void Heapify(int index, int heapSize)
            {
                //左孩子
                int left = index * 2 + 1;
                while (left < heapSize)
                {

                    int minimal = left + 1 < heapSize && (_comparator.Compare(_heap[left+1], _heap[left]) < 0)
                        ? left + 1
                        : left;
                    minimal = _comparator.Compare(_heap[minimal], _heap[index]) < 0 ? minimal : index;
                    if (minimal == index)
                    {
                        break;
                    }
                    Swap(minimal, index);
                    index = minimal;
                    left = index * 2 + 1;
                }
            }

            private void Swap(int i, int j)
            {
                
                T o1 = _heap[i];
                T o2 = _heap[j];
                _heap[i]= o2;
                _heap[j] = o1;
                if (_indexMap.ContainsKey(o1))
                {
                    _indexMap.Remove(o1);
                    _indexMap.Add(o1, j);

                }

                if (_indexMap.ContainsKey(o2))
                {
                    _indexMap.Remove(o2);
                    _indexMap.Add(o2, i);
                }

            }

        }
    }
}
