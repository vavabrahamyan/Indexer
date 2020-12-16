using System;

namespace Indexer
{
    public class KeyedArray
    {
        private string[] _keys;

        private object[] _arrayElements;

        public KeyedArray(int size)
        {
            _keys = new string[size];
            _arrayElements = new object[size];
        }

        private int Find(string targetKey)
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (String.Compare(_keys[i], targetKey) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindEmpty()
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i] == null)
                {
                    return i;
                }
            }

            throw new Exception("Array is full");
        }

        public object this[string key]
        {
            set
            {
                int index = Find(key);
                if (index < 0)
                {
                    index = FindEmpty();
                    _keys[index] = key;
                }

                _arrayElements[index] = value;
            }

            get
            {
                int index = Find(key);
                if (index < 0)
                {
                    return null;
                }
                return _arrayElements[index];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KeyedArray ma = new KeyedArray(100);

            ma["Bart"] = 8;
            ma["Lisa"] = 10;
            ma["Maggie"] = 2;

            Console.WriteLine("Let's find Lisa's age");
            int age = (int)ma["Lisa"];
            Console.WriteLine("Lisa is {0}", age);

            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }
}
