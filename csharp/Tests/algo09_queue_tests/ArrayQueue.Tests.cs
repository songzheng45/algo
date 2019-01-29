using System;
using algo09_queue;
using Xunit;

namespace algo09_queue_tests
{
    public class ArrayQueueTests
    {
        [Fact]
        public void Enqueue_Get_Count_When_Only_Enqueue()
        {
            var queue = new ArrayQueue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);
        }

        [Fact]
        public void Enqueue_Get_Count_When_Enqueue_And_Dequeue()
        {
            var queue = new ArrayQueue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);

            Assert.Equal(5, queue.Count);
        }

        [Fact]
        public void Enqueue_When_Full()
        {
            var queue = new ArrayQueue<int>(4);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Exception ex = Assert.Throws<InvalidOperationException>(() => queue.Enqueue(5));

            Assert.IsType<InvalidOperationException>(ex);
        }

        [Fact]
        public void Enqueue_After_Dequeue_When_Full()
        {
            var queue = new ArrayQueue<int>(4);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Exception ex = Assert.Throws<InvalidOperationException>(() => queue.Enqueue(100));

            Assert.IsType<InvalidOperationException>(ex);
        }

        [Fact]
        public void Dequeue_Throw_InvalidOperationException_When_Empty()
        {
            var queue = new ArrayQueue<int>(4);

            Exception ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());

            Assert.IsType<InvalidOperationException>(ex);
        }

        [Fact]
        public void Dequeue_OK_When_Not_Empty()
        {
            var queue = new ArrayQueue<int>(4);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            int item = queue.Dequeue();

            Assert.Equal(1, item);
        }
    }
}