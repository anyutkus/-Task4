using System;
using MatrixClass;
using ElementChangedArgs;

namespace MatrixExtention
{
    public class MatrixTracker<T>
    {
        private Matrix<T> _matrix;
        private (int i, T item) lastChangedElement = (-1, default);

        public MatrixTracker(Matrix<T> matrix)
        {
            _matrix = matrix;
            _matrix.ElementChanged += OnMatrixElementChanged;
        }

        private void OnMatrixElementChanged(object matrix, ElementChangedEventArgs<T> e)
        {
            lastChangedElement = (e.Position, e.PreviousItem);
        }

        public void Undo()
        {
            if(lastChangedElement.i != -1)
            {
                _matrix[lastChangedElement.i, lastChangedElement.i] = lastChangedElement.item;
            }
            else
            {
                throw new InvalidOperationException("Matrix was never changed");
            }
        }
    }
}
