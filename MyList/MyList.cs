using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyList
{
    class MyList<T> : IList<T>, IEnumerable
    {
        private T[] _mas;
        private int _size;
        private int _capasity;

        
       
        public MyList()
        {
            _mas = new T[0];
            _size = 0;
            _capasity = 0;
        }

        public MyList(int capasity)
        {
            _mas = new T[capasity];
            _size = 0;
            _capasity = capasity;
        }

        public MyList(T[] collection)
        {
            _mas = new T[collection.Length];
            _size = collection.Length;
            _capasity = collection.Length;
            for (int i = 0; i < collection.Length; i++)
            {
                _mas[i] = collection[i];
            }

        }

        public int Count => _size;
        public int Capasity => _capasity;



        public T this[int index]
        { get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                }
                return _mas[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                }
                _mas[index] = value;
            }

        }




        public bool IsReadOnly => false;

        public object Capacity { get; internal set; }

        public void Add(T item)
        {
            if (Count < Capasity)
            {
                _mas[Count] = item;
                _size++;
            }
            else
            {
                T[] tmp = new T[(int)(_capasity * 1.1 + 4)];
                for (int i = 0; i < Count; i++)
                {
                    tmp[i] = _mas[i];
                }
                tmp[_size] = item ;

                _mas = tmp;
                _size++;
                _capasity = tmp.Length;
            }
        }

        public void Clear()
        {
            _size = 0;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;
        

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_size>Capasity)
            {
                array.CopyTo(_mas, arrayIndex);
            }
            else
            {
                T[] tmp = new T[Capasity + array.Length];
                
                for (int i = 0; i < Count; i++)
                {
                    tmp[i] = _mas[i];
                }
                _size++;
                _capasity = tmp.Length;
                array.CopyTo(_mas, arrayIndex);

            }
            

        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(_mas);                        //(_mas.GetEnumerator() as IEnumerator<T>);
        }

        public int IndexOf(T item)
        {
            int pos = -1;
            for(int i=0;i<_size;i++)

            {
                if (_mas[i].Equals(item))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public int LastIndexOf(T item)
        {
            int pos = -1;
            for (int i = _size; i >= 0; i--)
            {
                if (_mas[i].Equals(item))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");
            }
            if (Count < Capasity)
            {
                for (int i = Count - 1; i > index; i--)
                {
                    _mas[i] = _mas[i - 1];
                }
                _mas[index] = item;
            }
            if (Count > Capasity)
                {
                    T[] tmp = new T[(int)(_capasity * 1.1 + 4)];
                    for (int i = 0; i < _size; i++)
                    {
                        tmp[i] = _mas[i];
                    }
                    tmp[_size] = item;
                    _mas = tmp;
                    _size++;
                    _capasity = tmp.Length;
                }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_mas[i].Equals(item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        _mas[j] = _mas[j + 1];
                    }
                    _size--;
                    return true;
                }
            }
            return false;

        }
        

        public void RemoveAt(int index)
        {
            if (index <= 0 && index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");
            }
            if (Count < Capasity)
                for (int i = index; i < Count - 1; i++)
                {
                    _mas[i] = _mas[i + 1];
                }
                  _size--; 
        }

       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _mas.GetEnumerator();
        }
        public int[] ToArray()
        {
            int[] mas = new int[_mas.Length];
            _mas.CopyTo(mas, 0);
            return mas;
        }

        public int BinarySearch(T item)
        {
            int left = 0;
            int right = _size;
            int middle = -1;
           
                while (left != middle)
                {
                    middle = (left + right) / 2;
                    if (item.Equals(_mas[middle]))
                    {
                        return middle;
                    }
                    else if ((int)item < (int)_mas[middle])
                    {
                        right = middle - 1;
                    }
                    else
                        left = middle + 1;
                }
            
            return -1;

        }
    }
}
