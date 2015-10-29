using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public delegate TOut ActionStateEventHandler<T, TOut>(object sender, ActionEventArgs<T> e);

    public delegate void ActionStateEventHandler<T>(object sender, ActionEventArgs<T> e);

    public delegate void ActionEventHandler(object sender, ActionEventArgs e);
}
