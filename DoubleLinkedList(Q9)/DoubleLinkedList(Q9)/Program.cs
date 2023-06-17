using System;

namespace DoubleLinkedList_Q9_
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
            ++count;
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
            ++count;
        }

        public void Delete(int position)
        {
            int currentPosition = 2;
            Node currentHead = head;

            if (head == null)
            {
                Console.WriteLine("The list is empty.");
            }
            else if (position == 1 && count > 1)
            {
                head = head.next;
            }
            else if (position == 1 && count == 1)
            {
                head = null;
            }
            else if (count == position)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                while (currentHead != null)
                {
                    if (currentPosition == position)
                    {
                        currentHead.next = currentHead.next.next;
                        currentHead.next.next.prev = currentHead;
                    }
                    currentPosition++;
                    currentHead = currentHead.next;
                }
            }
            --count;
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
            Console.WriteLine("Enter the number of nodes:");
            int nodes = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < nodes; i++)
            {
                Console.Write("Enter input {0}: ", i + 1);
                input = Convert.ToInt32(Console.ReadLine());
                newlist.AddLast(input);
            }

            newlist.Display();

        start1:
            Console.Write("Input the position (1 to {0}) to delete a node: ", DoubleLinkedList.count);
            int position = Convert.ToInt32(Console.ReadLine());

            if (position < 1 || position > DoubleLinkedList.count)
            {
                goto start1;
            }

            Console.WriteLine("After deletion, the new list is:");
            newlist.Delete(position);

            newlist.Display();
        }
    }
}
