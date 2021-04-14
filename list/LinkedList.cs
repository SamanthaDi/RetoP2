using System;
using System.Collections.Generic;
using System.Text;


namespace retoP2.list
{
    public enum Position
    {
        BEFORE,
        AFTER
    }

    public class LinkedList<G> : List<G>
    {

        public class Node<T>
        {
            public T data;
            public Node<T> previous;
            public Node<T> next;

            public Node(T dataB)
            {
                data = dataB;
            }
        }

        private static Node<G> head;
        private static Node<G> tail;
        private int size;

        private static int listsCount = 0;

        public LinkedList() { listsCount++; }
     
        public static int getListsCount() { return listsCount; }

        public class ForwardIterator : Iterator<G>
        {
            private Node<G> currentNode;
            public ForwardIterator()
            {
                this.currentNode = head;
            }
            public ForwardIterator(ForwardIterator iterator)
            {
                currentNode = iterator.currentNode;
            }
            public bool hasNext()
            {
                return currentNode != null;
            }
            public G next()
            {
                G data = currentNode.data;
                currentNode = currentNode.next;
                return data;
            }
            public Node<G> getCurrentNode()
            {  // modificador de acceso se llama -> package-private
                return currentNode;
            }
        }

        public class ReverseIterator : Iterator<G>
        {

            private Node<G> currentNode;

            public ReverseIterator()
            {
                this.currentNode = tail;
            }

            public bool hasNext()
            {
                return currentNode != null;
            }

            public G next()
            {
                G data = currentNode.data;

                currentNode = currentNode.previous;

                return data;
            }
        }

        public void add(G data)
        {
            Node<G> node = new Node<G>(data);
            node.previous = tail;
            if(tail != null) { tail.next = node; }
            if(head == null) { head = node; }
            tail = node;
            size++;
        }

        public G get(int index)
        {
            Node<G> currentNode = head;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                currentNode = currentNode.next;
                currentIndex++;
            }

            return currentNode.data;
        }

        public void delete(int index)
        {
            Node<G> currentNode = head;
            int currentIndex = 0;

            if (index < 0 || index >= size)
            {
                return;
            }

            size--;

            if (size == 0)
            {
                head = null;
                tail = null;
                return;
            }

            if (index == 0)
            {
                head = head.next;
                head.previous = null;
            }

            if (index == size)
            {
                tail = tail.previous;
                tail.next = null;
            }

            if (index > 0 && index < size)
            {
                while (currentIndex < index)
                {
                    currentNode = currentNode.next;
                    currentIndex++;
                }
                currentNode.previous.next = currentNode.next;
                currentNode.next.previous = currentNode.previous;
            }


        }

        public Iterator<G> getIterator()
        {
            return new ForwardIterator();
        }

        public void insert(G data, Position position, Iterator<G> it)
        {

            Node<G> newNode = new Node<G>(data);
            Node<G> currentNode = ((ForwardIterator)it).getCurrentNode();

            if (position == Position.AFTER)
            {
                newNode.next = currentNode.next;
                newNode.previous = currentNode;
                currentNode.next = newNode;
                if (newNode.next != null)
                {
                    newNode.next.previous = newNode;
                }
                else
                {
                    tail = newNode;
                }
            }
            else if (position == Position.BEFORE)
            {
                newNode.previous = currentNode.previous;
                newNode.next = currentNode;
                currentNode.previous = newNode;
                if (newNode.previous != null)
                {
                    newNode.previous.next = newNode;
                }
                else
                {
                    head = newNode;
                }
            }
            else
            {
                System.Console.WriteLine("No conozco el valor de posision");
            }
            size++;
        }
        public int getSize()
        {
            return size;
        }

        public ReverseIterator getReverseIterator()
        {
            return new ReverseIterator();
        }

        Iterator<G> List<G>.getReverseIterator()
        {
            throw new NotImplementedException();
        }

        public bool hasNext()
        {
            throw new System.NotImplementedException();
        }
    }

}
