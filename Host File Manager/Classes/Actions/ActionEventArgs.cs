using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public class ActionEventArgs
        : EventArgs
    {
        public ActionEventArgs(IClientAction action)
            : base()
        {
            this.Action = action;
        }

        public IClientAction Action { get; protected set; }

    }
    public class ActionEventArgs<T>
        : ActionEventArgs
    {
        public ActionEventArgs(IClientAction action)
            : base(action)
        {
        }

        public ActionEventArgs(IClientAction action, T state)
            : base(action)
        {
            this.State = state;
        }

        public T State { get; private set; }
    }
}
