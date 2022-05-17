using System;

namespace Task4._1
{
    public class MatrixTracker<T>
    {
        private Matrix<T> _matrix;
        private int counter = -1;
        private bool isUndoCalled = false;
        private (int position , T item)[] previousValue = new (int, T)[10];

        public MatrixTracker(Matrix<T> matrix)
        {
            _matrix = matrix;
            _matrix.ElementChanged += OnMatrixElementChanged;
        }

        private void OnMatrixElementChanged(object matrix, ElementChangedEventArgs<T> e)
        {
            if (isUndoCalled)
            {
                previousValue[counter] = (default, default);
                isUndoCalled = false;
                counter--;
            }
            else
            {
                previousValue[++counter] = (e.Position, e.PreviousItem);
            }
        }

        public void Undo()
        {
            if(counter != -1)
            {
                isUndoCalled = true;
                _matrix[previousValue[counter].position, previousValue[counter].position] = previousValue[counter].item;
            }
            else
            {
                throw new InvalidOperationException("Matrix was never changed or all your changes were undone");
            }
        }
    }
}
