using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrieTree
    {
        public class Node1
        {
            public int _pass;
            public int _end;
            public Node1[] _nexts;

            public Node1()
            {
                _pass = 0;
                _end = 0;
                _nexts = new Node1[26];
            }
        }

        public class Trie1
        {
            private Node1 _root;

            public Trie1()
            {
                _root = new Node1();
            }

            public void Insert(string word)
            {
                if (word == null)
                {
                    return;
                }
                char[] chs = word.ToCharArray();
                Node1 node = _root;
                node._pass++;
                int index = 0;
                for (int i = 0; i < chs.Length; i++)
                { // 从左往右遍历字符
                    index = chs[i] - 'a'; // 由字符，对应成走向哪条路
                    if (node._nexts[index] == null)
                    {
                        node._nexts[index] = new Node1();
                    }
                    node = node._nexts[index];
                    node._pass++;
                }
                node._end++;
            }

            public void Delete(string word)
            {
                if (Search(word) != 0)
                {
                    char[] chs = word.ToCharArray();
                    Node1 node = _root;
                    node._pass--;
                    int index = 0;
                    for (int i = 0; i < chs.Length; i++)
                    {
                        index = chs[i] - 'a';
                        if (--node._nexts[index]._pass == 0)
                        {
                            node._nexts[index] = null;
                            return;
                        }
                        node = node._nexts[index];
                    }
                    node._end--;
                }
            }

            // word这个单词之前加入过几次
            public int Search(string word)
            {
                if (word == null)
                {
                    return 0;
                }
                char[] chs = word.ToCharArray();
                Node1 node = _root;
                int index = 0;
                for (int i = 0; i < chs.Length; i++)
                {
                    index = chs[i] - 'a';
                    if (node._nexts[index] == null)
                    {
                        return 0;
                    }
                    node = node._nexts[index];
                }
                return node._end;
            }

            // 所有加入的字符串中，有几个是以pre这个字符串作为前缀的
            public int PrefixNumber(string pre)
            {
                if (pre == null)
                {
                    return 0;
                }
                char[] chs = pre.ToCharArray();
                Node1 node = _root;
                int index = 0;
                for (int i = 0; i < chs.Length; i++)
                {
                    index = chs[i] - 'a';
                    if (node._nexts[index] == null)
                    {
                        return 0;
                    }
                    node = node._nexts[index];
                }
                return node._pass;
            }
        }
    }
}
