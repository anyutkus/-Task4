using System;
using System.Collections.Generic;

namespace Task4._1
{
    public class Matrix<T>
    {
        private T[] _elements;
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public int Size
        {
            get => _elements.Length;
        }

        public Matrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Less than 0", nameof(size));
            }
            _elements = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                if ((i < 0) || (i >= Size) || (j < 0) || (j >= Size))
                {
                    throw new IndexOutOfRangeException("i or j is not correct");
                }
                return i == j ? _elements[i] : default;
            }
            set
            {
                if ((i < 0) || (i >= Size) || (j < 0) || (j >= Size))
                {
                    throw new IndexOutOfRangeException("i or j is not correct");
                }

                if (i == j)
                { 
                    var previousValue = _elements[i];
                    _elements[i] = value;

                    OnElementChanged(this, new ElementChangedEventArgs<T>(i, previousValue, _elements[i]));
                }
            }
        }

        protected virtual void OnElementChanged(object matrix, ElementChangedEventArgs<T> e)
        {
            if (Comparer<T>.Default.Compare(e.PreviousItem, e.NewItem) != 0)
            {
                ElementChanged?.Invoke(matrix, e);
            }
        }

        public override string ToString()
        {
            string str = "";
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (i != j)
                    {
                        str += $"{default(T),5:D}";
                    }
                    else
                    {
                        str += $"{_elements[i],5:D}";
                    }
                }
                str += "\n";
            }

            return str;
        }
    }
}
