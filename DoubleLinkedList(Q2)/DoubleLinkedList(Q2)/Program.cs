using System;

namespace DoubleLinkedList_Q2_
{
    public class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int value)
        {
            data = value;
            next = null;
            prev = null;
        }
    }

    public class DoubleLinkedList
    {
        public static Node head;
        public static Node tail;

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddFirst(int value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node newHead = new Node(value);
                newHead.next = head;
                head.prev = newHead;
                head = newHead;
            }
        }

        public void AddLast(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                tail = head;
            }
            else
            {
                Node newTail = new Node(value);
                tail.next = newTail;
                newTail.prev = tail;
                tail = newTail;
            }
        }

        public void Display()
        {
            int count = 0;
            Node currentTail = tail;
            Console.WriteLine("Data entered on the list are:");

            while (currentTail != null)
            {
                Console.Write("node number {0}:", ++count);
                Console.WriteLine(currentTail.data);
                currentTail = currentTail.prev;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DoubleLinkedList newlist = new DoubleLinkedList();
            Console.WriteLine("enter number of nodes");
            int nodes = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < nodes; i++)
            {
                Console.Write("enter input {0}:", i + 1);
                int input = Convert.ToInt32(Console.ReadLine());
                newlist.AddLast(input);
            }
            newlist.Display();
        }
    }
}
