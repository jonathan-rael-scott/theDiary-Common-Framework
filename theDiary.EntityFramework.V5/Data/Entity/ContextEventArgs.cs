using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public class ContextEventArgs
        : ContextEventArgs<DbContext>
    {
        public ContextEventArgs(DbContext context)
            : base(context)
        {
            this.Context = context;
        }
    }

    public class ContextEventArgs<TContext>
        : EventArgs
        where TContext : DbContext
    {
        public ContextEventArgs(TContext context)
            : base()
        {
            this.Context = context;
        }

        public TContext Context { get; protected set; }
    }
}
