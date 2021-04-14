using System;
using System.Collections.Generic;
using System.Text;

namespace retoP2.list
{
    public class ArrayList<H> : List<H>
    {
        public static Object[] array;
        public static int size;
        public ArrayList()
        {
            array = new Object[2];
        }

        public void add(H data)
        {
            if (size >= array.Length)
            {
                Object[] arrayN = new Object[array.Length + 2];
                Array.Copy(array, 0, arrayN, 0, array.Length);
                array = arrayN;
            }
            array[size] = data;
            size++;
        }

        public H get(int index)
        {
            return (H)array[index];
        }

        public void delete(int index)
        {
            if (index < 0 && index >= size)
                return;
            int currentIndex;
            for (currentIndex = index + 1; currentIndex < size; currentIndex++)
            {
                array[currentIndex - 1] = array[currentIndex];
            }
            size--;
        }
        public int getSize()
        {
            return size;
        }
        public Iterator<H> getIterator()
        {
            return new ForwardIterator();
        }
        public void insert(H data, Position position, Iterator<H> it) { }

        public Iterator<H> getReverseIterator()
        {
            return new ReverseIterator();
        }

        public class ForwardIterator : Iterator<H>
        {
            private int currentIndex;
            public bool hasNext()
            {
                return currentIndex < size;
            }
            public H next()
            {
                return (H)array[currentIndex++];
            }
        }
        public class ReverseIterator : Iterator<H>
        {
            private int currentIndex;
            public ReverseIterator()
            {
                currentIndex = size - 1;
            }
            public bool hasNext()
            {
                return currentIndex > 0;
            }
            public H next()
            {
                H data = (H)array[currentIndex];
                currentIndex--;
                return data;
            }
        }


    }
}
