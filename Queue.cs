using System;
using System.Collections.Generic;
namespace queue
{
    class aQueue
    {
        int[] _queue;
      
        int _currIndex = 0;
        public aQueue(int size)
        {
            this._queue = new int[size];
           
        }
        private bool CanEnqueue()
        {
            if (_queue.Length == _currIndex+1)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        } 
        private bool CanDequeue()
        {
            if (_currIndex <= 0)
                return false;
            
            else
            {
                return true;
            }
            
        }
        public void Enqueue(int toAdd)
        {
            if (CanEnqueue())
            {
                _queue[_currIndex] = toAdd;
                _currIndex++;
            }
            else
            {
                throw new Exception("Cannot Add Anymore to the queue");
            }
           
        }
        public int Dequeue()
        {
            if (CanDequeue())
            {
                int firstAdded = _queue[0];
                
                for (int i = 0; i < _queue.Length -2; i++)
                {

                    _queue[i] = _queue[i + 1];
                   

                    
                }
                
                this._currIndex--;
                return firstAdded;
            }
            else
            {
                throw new Exception("Nothing left in Queue");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            aQueue myQueue = new aQueue(10);
            int toAddInput;
            while (userInput!= "exit")
            {
                Console.WriteLine("type add, retrieve, or exit to quit.");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "add")
                {
                    Console.WriteLine("what would you like to add?");
                    toAddInput = int.Parse(Console.ReadLine());
                    myQueue.Enqueue(toAddInput);
                }
                else if (userInput == "retrieve")
                {
                    Console.WriteLine(myQueue.Dequeue());
                }
                else if (userInput == "exit")
                {
                    break;
                }
                else
                {
                    continue;
                }
                
            }
        }
    }
}
