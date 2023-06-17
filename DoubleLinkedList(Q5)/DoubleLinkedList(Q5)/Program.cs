using System;

namespace DoubleLinkedList_Q5_
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
        public static int count = 0;

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
            count++;
        }

        public void AddByPosition(int value, int position)
        {
            int currentPostion = 0;
            Node newNode = new Node(value);
            Node currentHead = head;
            if (head == null)
            {
                head = new Node(value);
                tail = head;
            }
            else if (position == 1)
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            else if (position == count)
            {
                tail.next = newNode;
                newNode.prev = tail;
                newNode.next = null;
                tail = newNode;
            }
            else
            {
                while (currentHead != null)
                {
                    if (currentPostion + 2 == position)
                    {
                        newNode.next = currentHead.next;
                        currentHead.next.prev = newNode;
                        currentHead.next = newNode;
                        newNode.prev = currentHead;
                        break;
                    }
                    currentPostion++;
                    currentHead = currentHead.next;
                }
            }
            count++;
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
            count++;
        }

        public void Display()
        {
            int countDisplay = 0;
            Node currentHead = head;
            Console.WriteLine("Data entered on the list are:");

            while (currentHead != null)
            {
                Console.Write("node number {0}:", ++countDisplay);
                Console.WriteLine(currentHead.data);
                currentHead = currentHead.next;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int input;
            DoubleLinkedList newlist = new DoubleLinkedList();
        start:
            Console.WriteLine("Input the number of nodes (3 or more):");
            int nodes = Convert.ToInt32(Console.ReadLine());
            if (nodes < 3)
            {
                Console.WriteLine("Enter 3 or more.");
                goto start;
            }
            for (int i = 0; i < nodes; i++)
            {
                Console.Write("Enter input {0}:", i + 1);
                input = Convert.ToInt32(Console.ReadLine());
                newlist.AddLast(input);
            }
            newlist.Display();
        start1:
            Console.Write("Input the position (1 to {0}) to insert a new node:", DoubleLinkedList.count);
            int position = Convert.ToInt32(Console.ReadLine());
            if (position < 1 || position > DoubleLinkedList.count)
            {
                goto start1;
            }
            Console.Write("Enter input:");
            input = Convert.ToInt32(Console.ReadLine());

            newlist.AddByPosition(input, position);

            newlist.Display();
        }
    }
}
