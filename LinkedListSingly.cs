using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class LinkedListSingly<T>
    {
        // private fields for head and count
        private LinkedListNode<T> head;
        private int count = 0;      // Initialize count to 0 for new list

        // Count provides access to the number of elements in the list
        public int Count { get => count; set => count = value; }

        internal class LinkedListNode<T>
        {
            // Fields         
            internal T Value;                    // data in node
            internal LinkedListNode<T> Next;    // .next address reference

            internal LinkedListNode(T value)
            {
                Value = value;
            } // constructor for node

        } // nested class LinkedListNode

        // Adds elements to the end of the linked list
        public void Add(T value)
        {
            // Create a new node to hold our data
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            // If the list is empty, assign the new node to head
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                // Create a node to keep track of the current node
                LinkedListNode<T> current = head;

                // Iterate through linked list until we are at the last link in the list
                while (current.Next != null)
                {
                    current = current.Next;
                }

                // At the end of the list, add the new node
                current.Next = newNode;
            }

            // increment the count to reflect the added element
            count++;
        } // Add

        // Removes elements by their values
        internal bool Remove(T value)
        {
            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // If the head is the value
            if (current.Value.Equals(value))
            {
                // if there is a node after the head, update reference so that the next node is the new head
                if (current.Next != null)
                {
                    head = current.Next;
                }
                // if there is no node following, set the head to null
                else
                {
                    head = null;
                }

                // Decrement count to reflect removed element
                Count--;
                return true;
            }

            while (current != null)
            {
                // If the next node matches the value to be removed 
                if (current.Next.Value.Equals(value))
                {
                    // If there is a following node, set it to be the next node
                    if (current.Next.Next != null)
                    {
                        current.Next = current.Next.Next;
                        // decrement the count
                        Count--;
                        return true;
                    }
                    else // else runs if the node to be removed is the last one 
                    {
                        current.Next = null;
                        Count--;
                        return true;
                    }
                }
                // iterate through the list
                current = current.Next;
            }
            // return fall if no element is removed
            return false;
        } // Remove

        // Displays all elements in the linked list
        internal void Display()
        {
            // Create a reference to the head
            LinkedListNode<T> current = head;

            // while loop checks if current is not null
            while (current != null)
            {
                Console.Write(current.Value + " ");
                // set current to the next mode
                current = current.Next;
            }
            Console.WriteLine(); // Moves to next line after displaying the items in list
        } // Display

        // Indexer Override - accesses elements by index
        public T this[int index]
        {
            get
            {
                // Validate the index
                ValidateRange(index);

                // Transverse to the node at the specified index
                LinkedListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Value;
            }
        } // Indexer Override

        // Inserts an element at a specified index
        internal void InsertAtIndex(int index, T value)
        {
            ValidateRange(index);

            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // Create a new node with the input value
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            // Track the current index
            int currentIndex = 0;

            // Iterate through linked list 
            while (current != null)
            {
                // If index is 0, assign the head to be the next node and the
                // new node to be the head
                if (currentIndex == 0 && index == 0)
                {
                    newNode.Next = current;
                    head = newNode;

                    // increment the count
                    Count++;
                    return;
                }

                // At the node before the specified index,
                // assign the  current node's next reference to the new node's Next reference.
                // Assign the new node to the current node's next reference.
                else if (currentIndex == index - 1)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;

                    // increment the count
                    Count++;
                    return;
                }

                // iterate through the linked list
                current = current.Next;

                // increment the currentIndex tracker
                currentIndex++;
            }
        } // InsertAtIndex

        // Inserts an element at the beginning of the list
        internal void InsertAtFront(T value)
        {
            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // Create a new node with the input value
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            newNode.Next = current;
            head = newNode;

            // increment the count
            Count++;
            return;
        } // InsertAtFront

        // Inserts an element at the end of the list
        internal void InsertAtEnd(T value)
        {
            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // Create a new node with the input value
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            // If there is no head, assign the new node to the head and return
            if (current == null)
            {
                head = newNode;

                // increment the count
                Count++;
                return;
            }

            // Iterate through linked list 
            while (current != null)
            {
                // At the last node, assign the new node to the current node's next reference and return
                if (current.Next == null)
                {
                    current.Next = newNode;

                    // increment the count
                    Count++;
                    return;
                }

                // iterate through the linked list
                current = current.Next;
            }
        } // InsertAtEnd

        // Removes an element at a specified index
        internal T RemoveAtIndex(int index)
        {
            ValidateRange(index);

            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // Temporary placeholder for the value at the removed node
            T temp;

            // Track the current index
            int currentIndex = 0;

            // Iterate through linked list 
            while (current != null)
            {
                // If index is 0, assign the next node to be the head
                if (currentIndex == 0 && index == 0)
                {
                    temp = current.Value;
                    head = current.Next;

                    // decrement the count
                    Count--;

                    // return the value of the removed node
                    return temp;
                }

                // At the node before the specified index, assign the data in the node at the index
                // to temp. Then change the reference for the next node to the node after the next node.
                // Return the value from the removed node
                else if (currentIndex == index - 1)
                {
                    temp = current.Next.Value;
                    current.Next = current.Next.Next;

                    // decrement the count
                    Count--;

                    // return the value of the removed node
                    return temp;
                }

                // iterate through the linked list
                current = current.Next;

                // increment the currentIndex tracker
                currentIndex++;
            }

            // If index is not properly removed, returns default
            return default(T);
        } // RemoveAtIndex

        // Removes an element at the beginning of the list
        internal T RemoveAtFront()
        {
            if (head == null)
            {
                // return default if there is no node in head
                return default(T);
            }

            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // Create a temporary placeholder for the value at the removed node
            T temp;

            // If the next node is not null, assign the head reference to it
            if (current.Next != null)
            {
                temp = current.Value;
                head = current.Next;

                // decrement the count
                Count--;

                // return the value of the removed node
                return temp;
            }
            // If the next node is null, assign null to the head reference
            //else if (current != null)
            else if (current != null)
            {
                temp = current.Value;
                head = null;

                // decrement the count
                Count--;

                // return the value of the removed node
                return temp;
            }

            // return default if there is no node in head
            return default(T);
        } // RemoveAtFront

        // Removes an element at the end of the list
        internal T RemoveAtEnd()
        {
            // Create a node to keep track of the current node
            LinkedListNode<T> current = head;

            // Create a temporary placeholder for the value at the removed node
            T temp;

            // If there is only one node, store its value in temp and assign null to head.
            if (count == 1)
            {
                temp = current.Value;
                head = null;

                // decrement the count
                Count--;

                // return the value of the removed node
                return temp;
            }

            // Iterate through linked list 
            while (current != null)
            {
                // At the second to last node, assign the data in the last node
                // to temp. Then change the reference for the next node to null.
                // Return the value from the removed node.
                if (current.Next.Next == null)
                {
                    temp = current.Next.Value;
                    current.Next = null;

                    // decrement the count
                    Count--;

                    // return the value of the removed node
                    return temp;
                }

                // iterate through the linked list
                current = current.Next;
            }

            // If no node is removed, such as when list is empty, return default
            return default(T);

        } // RemoveAtEnd

        // Removes all elements from the linked list
        internal void Clear()
        {
            // runs as long as there is an element in the linked list
            while (head != null)
            {
                // if there is an element after the head, make it the new head
                if (head.Next != null) head = head.Next;

                // if the head is the only element, make the head null
                else head = null;

                // decrement the count to reflect removed element
                Count--;
            }
        } // Clear

        //Check if the specified index is within the valid range(0 to count)
        internal void ValidateRange(int index)
        {
            // If the index is negative or the index is above our count 
            // throw an exception
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
