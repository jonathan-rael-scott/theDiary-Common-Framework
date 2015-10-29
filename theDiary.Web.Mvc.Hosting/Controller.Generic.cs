using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Hosting;

namespace System.Web.Mvc
{
    /// <summary>
    /// Provides methods that respond to HTTP requests that are made to an ASP.NET MVC Web site.
    /// </summary>
    /// <typeparam name="T">The DbContext <see cref="Type"/>.</typeparam>
    public class Controller<T>
        : Controller
        where T : DbContext, new()
    {
        #region Private Declarations
        private T context;
        private readonly object syncObject = new object();
        private int defaultPageSize = 10;
        #endregion

        #region Protected Read-Only Properties
        /// <summary>
        /// Gets or sets the default number of items visible when implementing a View with paging.
        /// </summary>
        public int DefaultPageSize
        {
            get
            {
                return this.defaultPageSize;
            }
            set
            {
                this.defaultPageSize = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="Context"/> relating to the <see cref="T:Controller"/>.
        /// </summary>
        protected T Context
        {
            get
            {
                lock (this.syncObject)
                {
                    if (this.context == null)
                        this.context = System.Activator.CreateInstance<T>();

                    return this.context;
                }
            }
        }
        #endregion

        #region Protected Methods & Functions
        protected override void Dispose(bool disposing)
        {
            this.Context.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}
