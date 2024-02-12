using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class Queue<T>
    {
        // private fields to track the front rear and count of elements
        private QueueNode<T> front;
        private QueueNode<T> rear;
        private int count;

        // Constructor to initialize an empty queue
        public Queue()
        {
            front = null;
            rear = null;
            count = 0;
        } // Queue constructor


        // Public property to access the count of elements.
        public int Count
        {
            get { return count; }
        } // Count

        // Nested class QueueNode representing elements in the queue
        internal class QueueNode<T>
        {
            internal T Value { get; set; }    // Data stored in the node
            internal QueueNode<T> Next { get; set; }      // Reference to next node
            internal QueueNode<T> Previous { get; set; }  // Reference to previous node

            // constructor for queue nodes - sets value to given value
            // and next and previous references to null
            internal QueueNode(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            } // QueueNode constructor

        } // class QueueNode

        /// <summary>
        /// Adds element to rear of queue
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            // Create a new node with the given value
            QueueNode<T> newNode = new QueueNode<T>(value);

            // If the queue is empty, set the new node to be both the front and the rear.
            // Otherwise add the new node to the rear and update references
            if (front == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                newNode.Previous = rear;
                rear.Next = newNode;
                rear = newNode;
            }

            // increment the count
            count++;
        } // Enqueue

        /// <summary>
        /// removes element at front and returns its value
        /// </summary>
        /// <returns> T </returns>
        public T Dequeue()
        {
            // If front is already null, return default
            if (front == null) return default;

            // assign value to be removed from front to temporary variable
            T temp = front.Value;

            // if the second node is empty, reset front and rear to null
            if (front.Next == null)
            {
                front = null;
                rear = null;
            }
            // if the second node is not null, update references so it becomes the front
            else if (front.Next != null)
            {
                front = front.Next;
                front.Previous = null;
            }

            // decrement the count
            count--;

            // return the value that was removed
            return temp;
        } // Dequeue

        /// <summary>
        /// returns the value of the front element without removing it
        /// </summary>
        /// <returns> T </returns>
        public T Peek()
        {
            // If front is already null, return default
            if (front == null) return default;

            // return the value of the front element
            return front.Value;
        } // Peek


        /// <summary>
        /// Empties the queue
        /// </summary>
        public void Clear()
        {
            // loop runs until queue is empty
            while (front != null)
            {
                // if the second node is empty, reset front and rear to null
                if (front.Next == null)
                {
                    front = null;
                    rear = null;
                }

                // otherwise update references so second node becomes the front
                else
                {
                    front = front.Next;
                    front.Previous = null;
                }

                // decrement the count to reflect removed node
                count--;
            }
        } // Clear


    } // class Queue
}
