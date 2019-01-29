using System;

namespace algo09_queue
{
    public class ArrayQueue<T>
    {
        private readonly T[] _data;

        private int _head = 0;
        private int _tail = 0;
        private readonly int _capacity = 0;

        public ArrayQueue(int capacity)
        {
            _data = new T[capacity];
            _capacity = capacity;
        }

        /// <summary>
        /// 队列中元素个数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="InvalidOperationException">队列已满时抛出异常</exception>
        /// <remarks>入队时如果末尾已经没有空间，则进行数据搬移</remarks>
        public void Enqueue(T item)
        {
            if (_tail == _capacity)
            {
                if (_head == 0) throw new InvalidOperationException("Queue full.");

                for (int idx = _head; idx < _tail; idx++)
                {
                    _data[idx - _head] = _data[idx];
                }

                _tail -= _head;
                _head = 0;
            }

            _data[_tail] = item;
            _tail++;
            Count++;
        }

        public T Dequeue()
        {
            if (_head == _tail) throw new InvalidOperationException("Queue empty.");

            T item = _data[_head];
            _head++;
            Count--;
            return item;
        }
    }
}