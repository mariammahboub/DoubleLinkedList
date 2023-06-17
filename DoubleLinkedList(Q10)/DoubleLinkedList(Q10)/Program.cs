using System;

namespace DoubleLinkedList_10_
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

        public void AddMiddle(int value, double position)
        {
            int currentPosition = 0;
            Node newNode = new Node(value);
            Node currentHead = head;

            if (head == null)
            {
                head = new Node(value);
                tail = head;
            }
            else
            {
                while (currentHead != null)
                {
                    if (currentPosition == position - 2)
                    {
                        newNode.next = currentHead.next;
                        currentHead.next.prev = newNode;
                        currentHead.next = newNode;
                        newNode.prev = currentHead;
                        break;
                    }
                    currentPosition++;
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
            Console.WriteLine("Data entered in the list are:");

            while (currentHead != null)
            {
                Console.Write("Node number {0}: ", ++countDisplay);
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
                Console.Write("Enter input {0}: ", i + 1);
                input = Convert.ToInt32(Console.ReadLine());
                newlist.AddLast(input);
            }

            newlist.Display();

            Console.Write("Input the position (2 to {0}) to insert a new node: ", DoubleLinkedList.count - 1);
            double position = Math.Round(.25 + DoubleLinkedList.count / 2.0);
            Console.Write(position + "\n");
            Console.WriteLine("Input the number: ");

            input = Convert.ToInt32(Console.ReadLine());
            newlist.AddMiddle(input, position);

            newlist.Display();
        }
    }
}
