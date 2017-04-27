using System.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;

namespace TriggeredAnimation
{
    public class EasyValue 
    {
        private FixedSizedQueue<float> values;
        public EasyValue(int Limit) 
        {
            values = new FixedSizedQueue<float>(Limit);
        }

        public void Set(float value) {
            values.Enqueue(value);
        }

        public float Get()
        {
            return values.Sum() / values.Limit;
        }
    }

    public class FixedSizedQueue<T> : IOrderedEnumerable<T>
    {
       private ConcurrentQueue<T> q = new ConcurrentQueue<T>();

        public FixedSizedQueue(int Limit)
        {
            this.Limit = Limit;
        }

        public int Limit { get; set; }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (this)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return q.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return q.GetEnumerator();
        }
    }
}
