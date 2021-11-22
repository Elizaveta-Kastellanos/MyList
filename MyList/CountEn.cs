using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyList
{
    public class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int pos = -1;

        public StackEnumerator(T[] array)
        {
            this.array = array;
        }

        public T Current
        {
            get
            {
                return array[pos];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            pos++;
            return pos > array.Length;
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}
