using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public int Count => list.Count;

        public void Add(T value)
        {
            list.Add(value);
        }

        public T Remove()
        {
            T element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;

        }
    }
}
