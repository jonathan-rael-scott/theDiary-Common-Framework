using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Web.Mvc.Hosting.Models;

namespace System.Web.Mvc.Hosting
{
    /// <summary>
    /// A <see cref="DbContext"/> instance represents a combination of the Unit Of Work and Repository
    /// patterns such that it can be used to query from a database and group together
    /// changes that will then be written back to the store as a unit. <see cref="DbContext"/>
    /// is conceptually similar to ObjectContext.
    /// </summary>
    public class HostedApplicationDbContext 
        : DbContext
    {
        #region Constructors
        /// <summary>
        /// Constructs a new context instance using conventions to create the name of the database to which a connection will be made. 
        /// The by-convention name is the full name (namespace + class name) of the derived context class.
        /// See the class remarks for how this is used to create a connection.
        /// </summary>
        public HostedApplicationDbContext()
            : base()
        {

        }
        
        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection
        /// string for the database to which a connection will be made.  See the class
        /// remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public HostedApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// Constructs a new context instance using conventions to create the name of
        /// the database to which a connection will be made, and initializes it from
        /// the given model.  The by-convention name is the full name (namespace + class
        /// name) of the derived context class.  See the class remarks for how this is
        /// used to create a connection.
        /// </summary>
        /// <param name="model">The model that will back this context.</param>
        public HostedApplicationDbContext(System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(model)
        {
        }

        /// <summary>
        /// Constructs a new context instance using the existing connection to connect 
        /// to a database. The connection will not be disposed when the context is disposed.
        /// </summary>
        /// <param name="existingConnection">An existing connection to use for the new context.</param>
        /// <param name="contextOwnsConnection">If set to true the connection is disposed when the context is disposed, otherwise
        /// the caller must dispose the connection.</param>
        public HostedApplicationDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        /// <summary>
        /// Constructs a new context instance around an existing <see cref="ObjectContext"/>. An existing
        /// <see cref="ObjectContext"/> to wrap with the new context.  If set to true the <see cref="ObjectContext"/>
        /// is disposed when the <see cref="DbContext"/> is disposed, otherwise the caller must dispose
        /// the connection.
        /// </summary>
        /// <param name="objectContext">An existing <see cref="ObjectContext"/> to wrap with the new context.</param>
        /// <param name="dbContextOwnsObjectContext">If set to true the <see cref="ObjectContext"/> is disposed when the <see cref="DbContext"/> is disposed,
        /// otherwise the caller must dispose the connection.</param>
        public HostedApplicationDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection
        /// string for the database to which a connection will be made, and initializes
        /// it from the given model.  See the class remarks for how this is used to create
        /// a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        /// <param name="model">The model that will back this context.</param>
        public HostedApplicationDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        /// <summary>
        /// Constructs a new context instance using the existing connection to connect to a database, and initializes it from the given model. 
        /// The connection will not be disposed when the context is disposed. 
        /// An existing connection to use for the new context. The model that will back this context. 
        /// If set to true the connection is disposed when the context is disposed, otherwise the caller must dispose the connection.
        /// </summary>
        /// <param name="existingConnection">An existing connection to use for the new context.</param>
        /// <param name="model">The model that will back this context.</param>
        /// <param name="contextOwnsConnection">If set to <c>True</c> the connection is disposed when the context is disposed, otherwise the caller must dispose the connection.</param>
        public HostedApplicationDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
        #endregion

        #region Public Properties
        public DbSet<UserProfile> UserProfiles { get; set; }
        #endregion
    }
}