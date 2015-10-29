using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity.Migrations
{
    public class UnifiedMigrationConfiguration
        : UnifiedMigrationConfiguration<DbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnifiedMigrationConfiguration"/> class.
        /// </summary>
        public UnifiedMigrationConfiguration()
            : base()
        {
        }

        public UnifiedMigrationConfiguration(string schema)
            : base(schema)
        {
        }
    }

    public class UnifiedMigrationConfiguration<TContext>
        : DbMigrationsConfiguration<TContext>
        where TContext : DbContext
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UnifiedMigrationConfiguration"/> class.
        /// </summary>
        public UnifiedMigrationConfiguration()
            : this("dbo")
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            this.SetSqlGenerator("System.Data.SqlClient", new UnifiedContextSqlGenerator());
        }

        public UnifiedMigrationConfiguration(string schema)
            : base()
        {
            if (schema.IsNullEmptyOrWhiteSpace())
                throw new ArgumentNullException("schema");

            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.Schema = schema;
            this.SetSqlGenerator("System.Data.SqlClient", new UnifiedContextSqlGenerator());
        }
        #endregion

        #region Private Declarations
        private string schema;
        #endregion

        #region Public Read-Only Properties
        public string Schema
        {
            get
            {
                return this.schema;
            }
            protected set
            {
                if (value.IsNullEmptyOrWhiteSpace())
                    throw new ArgumentNullException("value");

                this.schema = value;
            }
        }
        #endregion

        #region Public Event Declarations
        public event EventHandler<ContextEventArgs<TContext>> SeedingFinished;
        #endregion

        #region Protected Virtual Methods
        protected new virtual void Seed(TContext context)
        {
            if (this.SeedingFinished != null)
                this.SeedingFinished(this, new ContextEventArgs<TContext>(context));
        }
        #endregion
    }
}
