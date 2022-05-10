using System;

namespace ElementChangedArgs
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int Position { get; }
        public T PreviousItem { get; }
        public T NewItem { get; }

        public ElementChangedEventArgs(int p, T previousItem, T newItem)
        {
            (Position, PreviousItem, NewItem) = (p, previousItem, newItem);
        }
    }
}
