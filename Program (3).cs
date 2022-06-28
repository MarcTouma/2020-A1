/* 
*   Assignment 1
*   Names: Marc Touma, Ben Collins
*   Student numbers : 0674328, 0672261
*   Date 10/17/2021
*/
using System;
using System.Collections;
using Stack;
using List;
namespace List
{
    // Common interface for ALL linear data structures

    public interface IContainer<T>
    {
        void MakeEmpty();  // Reset an instance to empty
        bool Empty();      // Test if an instance is empty 
        int Size();        // Return the number of items in an instance
    }

    //-----------------------------------------------------------------------------

    public interface IList<T> : IContainer<T>
    {
        void Insert(T item, int p);    // Place item at position p in the list
        void Remove(int p);            // Remove item at position p from the list
        T Retrieve(int p);             // Retrieve item at position p in the list
    }

    //-----------------------------------------------------------------------------

    // Common generic Node class for all singly linked lists

    public class Node<T>
    {
        public T Item { get; set; }     // Read/write property
        public Node<T> Next { get; set; }     // Read/write property

        // Parameterless Constructor
        // Creates a single node initialized to default data members
        // Time complexity:  O(1)

        public Node()
        {
            Next = null;
        }

        // Constructor
        // Creates a single node initialized to the two parameters
        // Time complexity:  O(1)

        public Node(T item, Node<T> next = null)
        {
            Item = item;
            Next = next;
        }
    }

    //-----------------------------------------------------------------------------

    // List
    // Implementation:  Singly linked list

    public class List<T> : IList<T>
    {
        // Data members

        private Node<T> head;          // Reference to the head of the list
        private int count;             // Number of items in the list

        // Constructor
        // Creates an empty list with a header node
        // Time complexity: O(1)

        public List()
        {
            head = new Node<T>();
            count = 0;
        }

        // Insert
        // Inserts item at position p in the list
        // (Worst case) time complexity: O(n)

        public void Insert(T item, int p)
        {
            int i;
            Node<T> curr = head;

            if (p >= 1 && p <= count + 1)         // Is p correct?
            {
                for (i = 1; i <= p - 1; i++)      // Move to penultimate node
                    curr = curr.Next;

                curr.Next = new Node<T>(item, curr.Next);
                count++;
            }
            // else do nothing
        }

        // Remove
        // Removes item at position p in the list
        // Time complexity: O(n)

        public void Remove(int p)
        {
            int i;
            Node<T> curr = head;

            if (p >= 1 && p <= count)             // Is p correct?
            {
                for (i = 1; i <= p - 1; i++)      // Move to penultimate node
                    curr = curr.Next;

                curr.Next = curr.Next.Next;       // Reference around the removed item
                count--;
            }
            // else do nothing
        }

        // Retrieve
        // Retrieves the item at position p
        // Time complexity: O(n)

        public T Retrieve(int p)
        {
            int i;
            Node<T> curr = head;

            if (p >= 1 && p <= count)
            {
                for (i = 1; i <= p; i++)
                    curr = curr.Next;

                return curr.Item;
            }
            else
                return default(T);
        }

        // MakeEmpty
        // Resets list to empty
        // Time complexity: O(1)

        public void MakeEmpty()
        {
            head.Next = null;
            count = 0;
        }

        // Empty
        // Returns true if the list is empty; false otherwise
        // Time complexity: O(1)

        public bool Empty()
        {
            return count == 0;
        }

        // Size
        // Returns the number of items in the list
        // Time complexity: O(1)

        public int Size()
        {
            return count;
        }

        // Print
        // Outputs the list to console
        // Time complexity: O(1)

        public void Print()
        {
            Node<T> curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Item + " ");
            }
            Console.WriteLine();
        }
    }
}

    namespace Stack
    {
        // Common interface for ALL linear data structures

        public interface IContainer<T>
        {
            void MakeEmpty();  // Reset an instance to empty
            bool Empty();      // Test if an instance is empty 
            int Size();        // Return the number of items in an instance
        }

        //-------------------------------------------------------------------------

        public interface IStack<T> : IContainer<T>
        {
            void Push(T item); // Place an item on the top of a stack
            void Pop();        // Remove the top item of a stack
            T Top();           // Return the top item of a stack
        }

        //-------------------------------------------------------------------------

        // Common generic Node class for all singly linked lists

        public class Node<T>
        {
            public T Item { get; set; }     // Read/write property
            public Node<T> Next { get; set; }     // Read/write property

            // Parameterless constructor

            public Node()
            {
                Next = null;
            }

            // Constructor
            // Creates a single node set to the parameters

            public Node(T item, Node<T> next)
            {
                Item = item;
                Next = next;
            }
        }

        //-----------------------------------------------------------------------------

        // Stack
        // Behavior: Last-In, First-Out (LIFO)
        // Implementation: Singly linked list

        public class Stack<T> : IStack<T>
        {
            private Node<T> top;    // Reference to the top item
            private int count;      // Number of items in a stack

            // Time complexity of all methods: O(1)

            // Constructor
            // Create an empty stack

            public Stack()
            {
                MakeEmpty();
            }

            // Push
            // Inserts an item at the top of the stack

            public void Push(T item)
            {
                top = new Node<T>(item, top);
                count++;
            }

            // Pop
            // Removes the top item from the stack
            // If the stack is empty then nothing is done

            public void Pop()
            {
                if (!Empty())
                {
                    top = top.Next;
                    count--;
                }
            }

            // Top
            // Retrieves the item from the top of the stack
            // Returns default(T) if the stack is empty

            public T Top()
            {
                if (!Empty())
                    return top.Item;
                else
                    return default(T);
            }

            // MakeEmpty
            // Resets the stack to empty

            public void MakeEmpty()
            {
                top = null;
                count = 0;
            }

            // Empty
            // Returns true if the stack is empty; false otherwise

            public bool Empty()
            {
                return count == 0;
            }

            // Size
            // Returns the number of items in the stack

            public int Size()
            {
                return count;
            }
        }
    }


        namespace Browsing
        {
            public class Tab 
            {
                // Make 2 stacks to store forward and backward pages
                private Stack<string> S1; // The current Web Page is stored at the top of S1
                private Stack<string> S2;
                string DfaultHome = "www.google.com";
                

                public Tab()
                {
                    Stack<string> s1 = new Stack<string>();
                    Stack<string> s2 = new Stack<string>(); 
                    S1=s1;
                    S2=s2;   
                    s1.Push(DfaultHome);                
                }

                // Method to move to a new and specific webpage
                public void MoveTo(string x)
                {
                    S1.Push(x);
                    // Rids the stack of forward pages
                    S2.MakeEmpty();
                }
                
                public void BackTo()
                {
                    if (S1.Size() != 1)
                    {
                        S2.Push(S1.Top()); //pushes the current webpage onto the second stack
                        S1.Pop(); // then pops it off the first stack
                    }
                }

                public void ForwardTo()
                {
                    if (S2.Empty() == false)
                    {
                        S1.Push(S2.Top()); // pushes the webpage from the top of the second stack onto the first stack
                        S2.Pop(); // then pops it off the second stack
                    }
                }

                public string CurrentWebPage()
                {
                    return S1.Top(); // returns the webpage on top of the first stack. which would be the current web page
                }



            }


            class Browser : Tab
            {
                private List<Tab> T;
                private int currentTab=0;
                private int NumTabsOpen;
                public Browser()
                {
                    T = new List<Tab>(); //creates a new List of type Tab
                    NumTabsOpen=0;             // initialises count to 0
                    Start();             // calls the start method to start the first tab.
                }
                public void PrintBrowser()
                {
                    for (int i = 0; i < NumTabsOpen; i++)
                    {
                        Console.Write(i + ", ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine(NumTabsOpen);
                    Console.WriteLine(MyTab().ToString());
                    Console.WriteLine("Tab: " + currentTab + " " + CurrentWebPage());
                }
                public void MoveWeb(string input) //method for visiting web pages
                {
                    MoveTo(input);                // passes input to MoveTo method in tab class to change the website.

                }
                public void Forward() // Method for going Forward to the website after going back.
                {
                    ForwardTo();      // Calls the ForwardTo method from the Tab class
                }
                public void Back() // Method for returning to the previous website
                {
                    BackTo();     // calls BackTo method from Tab class
                }
                public void Start()
                {
                    Tab x = new Tab();           // creates a new Tab x
                    T.Insert(x, NumTabsOpen + 1);      // inserts x in list T at count+1
                    currentTab=T.Size();
                    NumTabsOpen++;                     // increases the count by 1   
                }
                public void Move(int tab)           
                {
                    if (tab >= 0 && tab < NumTabsOpen) // makes sure that the tab you want to move to is greater than or equal 
                        currentTab = tab;               // to 0 but less than Numtabs open. then sets current tab to 
                    else
                    {
                        Console.WriteLine("Error");
                    }
                                    
                }
                public Tab MyTab()
                {
                    return T.Retrieve(currentTab);
                }
                public void Close(int tab)
                {
                    if (tab > 0 && tab < NumTabsOpen)
                    {
                        T.Remove(tab);
                        NumTabsOpen = NumTabsOpen - 1;
                        currentTab=tab+1;
                    }
                    else
                        Console.WriteLine("Error");
                

                }
            }
        }
namespace LinkedListBrowsing
{
    class Node
     {
        public string WebPage { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
    class Tab 
    {
        private Node currWebPage;
        string DfaultHome = "www.google.com";

        public Tab()
        {
            currWebPage = new Node();
            currWebPage.WebPage = DfaultHome;
            int count=0;
            count++;
        }
        
        public void MoveTo(string x)
                {
                    Node A= new Node();
                    currWebPage.Next= A;
                    A.Prev=currWebPage;
                    currWebPage = A;
                    currWebPage.WebPage = x;
                }
        public void BackTo()
                {
                    if (currWebPage.Prev != null)
                    {
                        currWebPage = currWebPage.Prev;
                    }
                }
        public void ForwardTo()
                {
                    if (currWebPage.Next != null)
                    {
                        currWebPage=currWebPage.Next;
                    }
                }
        public string CurrentWebPage()
                {
                    return currWebPage.WebPage;
                }



    }
    class Browser : Tab
            {
                private List<Tab> T;
                private int currentTab=0;
                private int NumTabsOpen;
                public Browser()
                {
                    T = new List<Tab>(); //creates a new List of type Tab
                    NumTabsOpen=0;             // initialises count to 0
                    Start();             // calls the start method to start the first tab.

                }
                public void PrintBrowser()
                {
                    for (int i = 0; i < NumTabsOpen; i++)
                    {
                        Console.Write(i + ", ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine(NumTabsOpen);
                    Console.WriteLine(T.Retrieve(currentTab));
                    Console.WriteLine("Tab: " + currentTab + " " + CurrentWebPage());
                }
                public void MoveWeb(string input) //method for visiting web pages
                {
                    MoveTo(input);                // passes input to MoveTo method in tab class to change the website.

                }
                public void Forward() // Method for going Forward to the website after going back.
                {
                    ForwardTo();      // Calls the ForwardTo method from the Tab class
                }
                public void Back() // Method for returning to the previous website
                {
                    BackTo();     // calls BackTo method from Tab class
                }
                public void Start()
                {
                    Tab x = new Tab();           // creates a new Tab x
                    T.Insert(x, NumTabsOpen + 1);      // inserts x in list T at count+1
                    currentTab=T.Size();
                    NumTabsOpen++;                     // increases the count by 1   
                }
                public void Move(int tab)           // 
                {
                    if (tab > 0 && tab < NumTabsOpen)
                    {
                        currentTab = tab;
                        Console.WriteLine(T.Retrieve(currentTab));
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }  
                    


                }
                public Tab MyTab()
                {
                    return T.Retrieve(currentTab);
                }
                public void Close(int tab)
                {
                    if (tab > 0 && tab < NumTabsOpen)
                    {
                        currentTab=tab+1;
                        T.Remove(tab);
                        NumTabsOpen = NumTabsOpen - 1;
                    }
                    else
                        Console.WriteLine("Error");
                

                }
            }

}
