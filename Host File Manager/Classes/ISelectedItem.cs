using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public interface ISelectedItem<T>
    {
        T SelectedItem { get; }
    }
    
    public interface ISelectedItemContainer<T>
        : ISelectedItem<T>
    {
        /// <summary>
        /// The event that is raised when the <value>SelectedItem</value> has changed.
        /// </summary>
        event SelectedItemChangedEventHandler<T> SelectedItemChanged;
    }

    public delegate void SelectedItemChangedEventHandler<T>(object sender, ItemEventArgs<T> e);
    
    public class ItemEventArgs<T>
        : EventArgs,
        ISelectedItem<T>
    {
        public ItemEventArgs()
            : base()
        {
        }

        public ItemEventArgs(T item)
            : this()
        {
            this.SelectedItem = item;
        }
        public T SelectedItem { get; private set; }
    }
}
