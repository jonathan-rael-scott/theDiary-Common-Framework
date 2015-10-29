using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity.Migrations
{
    public class UnifiedContextSqlGenerator
        : SqlServerMigrationSqlGenerator
    {
        #region Public Override Methods & Functions
        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            var operations = UnifiedContextSqlGenerator.FilterMigrationOperations(migrationOperations);
            return base.Generate(operations, providerManifestToken);
        }
        #endregion

        #region Protected Override Methods & Functions
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            string schema, objectName;
            this.GetNameParts(createTableOperation.Name, out schema, out objectName);
            using (var writer = Writer())
            {
                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}')\r\nBEGIN", schema, objectName);
                writer.Indent++;
                writer.Write("CREATE TABLE ");
                writer.Write(this.Name(createTableOperation.Name));
                writer.Write(" ( ");
                int i = 0;
                foreach (var column in createTableOperation.Columns)
                {
                    this.AddColumnDefinition(column, writer);
                    writer.WriteLine("{0}", i != createTableOperation.Columns.Count - 1 ? "," : string.Empty);
                    i++;
                }
                writer.Write(" ) ");
                writer.Indent--;
                writer.Write("\r\nEND");

                this.Statement(writer);
            }
        }

        /*protected override void Generate(AlterColumnOperation alterColumnOperation)
        {
            string schema, objectName;
            this.GetNameParts(alterColumnOperation.Table, out schema, out objectName);
            using (var writer = Writer())
            {
                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_TYPE = 'Primary Key' AND TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{2}')\r\nBEGIN", alterColumnOperation.Table);
                writer.Indent++;
                writer.Write("ALTER TABLE ");
                writer.Write(this.Name(alterColumnOperation.Table));
                writer.Write(" ALTER COLUMN ");
                this.AddColumnDefinition(alterColumnOperation.Column, writer);
                writer.Indent--;
                writer.Write("\r\nEND");

                this.Statement(writer);
            }
        }

        protected override void Generate(DropTableOperation dropTableOperation)
        {
            string schema, objectName;
            this.GetNameParts(dropTableOperation.Name, out schema, out objectName);
            using (var writer = Writer())
            {
                writer.WriteLine("IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}')\r\nBEGIN", schema, objectName);
                writer.Indent++;
                writer.WriteLine("DROP TABLE ");
                writer.Write(this.Name(dropTableOperation.Name));
                writer.Indent--;
                writer.Write("\r\nEND");
            }
        }

        protected override void Generate(RenameColumnOperation renameColumnOperation)
        {
            string schema, objectName;
            this.GetNameParts(renameColumnOperation.Table, out schema, out objectName);
            using (var writer = Writer())
            {
                writer.WriteLine("IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = '{0}' AND TABLE_SCHEMA = '{1}' AND TABLE_NAME = '{2}')\r\nBEGIN", renameColumnOperation.Name, schema, objectName);
                writer.Indent++;
                writer.Write("EXEC sys.sp_rename @objname = N'");
                writer.Write(this.Name(renameColumnOperation.Table));
                writer.Write(".");
                writer.Write(string.Format("{0}', @newname = '{1}', @objtype = 'COLUMN'", renameColumnOperation.Name, renameColumnOperation.NewName));
                writer.Indent--;
                writer.Write("\r\nEND");

                this.Statement(writer);
            }
        }

        protected override void Generate(DropColumnOperation dropColumnOperation)
        {
            base.Generate(dropColumnOperation);
            string schema, objectName;
            this.GetNameParts(dropColumnOperation.Table, out schema, out objectName);
            using (var writer = Writer())
            {
                writer.WriteLine("IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = '{0}' AND TABLE_SCHEMA = '{1}' AND TABLE_NAME = '{2}')\r\nBEGIN", dropColumnOperation.Name, schema, objectName);
                writer.Indent++;
                writer.Write("ALTER TABLE ");
                writer.Write(this.Name(dropColumnOperation.Table));
                writer.Write(" DROP COLUMN ");
                writer.Write(this.Quote(dropColumnOperation.Name));
                writer.Indent--;
                writer.Write("\r\nEND");

                this.Statement(writer);
            }
        }
        */
        protected override void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation)
        {
            string schema, objectName;
            this.GetNameParts(addPrimaryKeyOperation.Table, out schema, out objectName);
            using (var writer = Writer())
            {
                //writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_TYPE = 'Primary Key' AND TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}')\r\nBEGIN", schema, objectName);
                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}')\r\nBEGIN", schema, objectName);
                writer.Indent++;
                writer.Write("ALTER TABLE ");
                writer.Write(this.Name(addPrimaryKeyOperation.Table));
                writer.Write(" ADD CONSTRAINT ");
                writer.Write(this.Quote(addPrimaryKeyOperation.Name));
                writer.Write(string.Format(" PRIMARY KEY ({0})", addPrimaryKeyOperation.Columns.Concat(",")));
                writer.Indent--;
                writer.Write("\r\nEND");

                this.Statement(writer);
            }
        }

        protected override void Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            using (var writer = Writer())
            {
                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_NAME = '{0}')\r\nBEGIN", addForeignKeyOperation.Name);
                writer.Indent++;

                writer.Write("ALTER TABLE ");
                writer.Write(Name(addForeignKeyOperation.DependentTable));
                writer.Write(" ADD CONSTRAINT ");
                writer.Write(Quote(addForeignKeyOperation.Name));
                writer.Write(" FOREIGN KEY (");
                writer.Write(string.Join(", ", addForeignKeyOperation.DependentColumns.Select(Quote)));
                writer.Write(") REFERENCES ");
                writer.Write(Name(addForeignKeyOperation.PrincipalTable));
                writer.Write(" (");
                writer.Write(string.Join(", ", addForeignKeyOperation.PrincipalColumns.Select(Quote)));
                writer.Write(")");
                if (addForeignKeyOperation.CascadeDelete)
                    writer.Write(" ON DELETE CASCADE");

                writer.Indent--;
                writer.Write("\r\nEND");

                Statement(writer);
            }
        }

        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            string tableName, tableSchema;
            this.GetNameParts(addColumnOperation.Table, out tableSchema, out tableName);
            using (var writer = Writer())
            {
                var column = addColumnOperation.Column;

                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}' AND COLUMN_NAME = '{0}' AND TABLE_SCHEMA = '{2}')\r\nBEGIN", column.Name, tableName, tableSchema);
                writer.Indent++;
                writer.Write("ALTER TABLE ");
                writer.Write(Name(addColumnOperation.Table));
                writer.Write(" ADD ");

                this.AddColumnDefinition(column, writer);

                //if (((column.IsNullable.HasValue && !column.IsNullable.Value) && ((column.DefaultValue == null) && string.IsNullOrWhiteSpace(column.DefaultValueSql))) && ((!column.IsIdentity && !column.IsTimestamp) && (!column.StoreType.Equals("rowversion", StringComparison.OrdinalIgnoreCase) && !column.StoreType.Equals("timestamp", StringComparison.OrdinalIgnoreCase))))
                //{
                //    writer.Write(" DEFAULT ");
                //    if (column.Type == PrimitiveTypeKind.DateTime)
                //    {
                //        writer.Write(this.Generate(DateTime.Parse("1900-01-01 00:00:00")));
                //    }
                //    else
                //    {
                //        writer.Write(this.Generate((dynamic)column.ClrDefaultValue));
                //    }
                //}
                writer.Indent--;
                writer.Write("\r\nEND");

                Statement(writer);
            }
        }

        protected override void Generate(CreateIndexOperation createIndexOperation)
        {
            string tableName, tableSchema;
            this.GetNameParts(createIndexOperation.Table, out tableSchema, out tableName);
            using (var writer = Writer())
            {

                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name = '{0}' and object_id = OBJECT_ID('{1}'))\r\nBEGIN", createIndexOperation.Name, this.Name(createIndexOperation.Table));
                writer.Indent++;
                writer.Write("CREATE INDEX ");
                writer.Write(Name(createIndexOperation.Name));
                writer.Write(" ON ");
                writer.Write(Name(createIndexOperation.Table));
                writer.Write(" ( ");
                int i = 0;
                foreach (var column in createIndexOperation.Columns)
                {
                    writer.Write(column);
                    if (i < createIndexOperation.Columns.Count - 1)
                        writer.Write(", ");
                    i++;
                }
                writer.Write(" )");
                //if (((column.IsNullable.HasValue && !column.IsNullable.Value) && ((column.DefaultValue == null) && string.IsNullOrWhiteSpace(column.DefaultValueSql))) && ((!column.IsIdentity && !column.IsTimestamp) && (!column.StoreType.Equals("rowversion", StringComparison.OrdinalIgnoreCase) && !column.StoreType.Equals("timestamp", StringComparison.OrdinalIgnoreCase))))
                //{
                //    writer.Write(" DEFAULT ");
                //    if (column.Type == PrimitiveTypeKind.DateTime)
                //    {
                //        writer.Write(this.Generate(DateTime.Parse("1900-01-01 00:00:00")));
                //    }
                //    else
                //    {
                //        writer.Write(this.Generate((dynamic)column.ClrDefaultValue));
                //    }
                //}
                writer.Indent--;
                writer.Write("\r\nEND");

                Statement(writer);
            }
        }

        #endregion

        #region Private Methods & Functions
        private void GetNameParts(string schemaQualifiedName, out string schema, out string objectName)
        {
            string[] nameParts = this.GetNameParts(schemaQualifiedName);
            schema = nameParts[0];
            objectName = nameParts[1];
        }

        private string[] GetNameParts(string schemaQualifiedName)
        {
            string[] returnValue = schemaQualifiedName.Split('.');
            if (returnValue.Length == 1)
                return new string[] { "dbo", schemaQualifiedName };
            return returnValue;
        }

        private void AddColumnDefinition(ColumnModel column, IndentedTextWriter writer)
        {
            string nullable = column.IsNullable.GetValueOrDefault() ? "NULL" : "NOT NULL";
            string defaultValue = column.DefaultValue.IsNull() ? string.Empty : string.Format("DEFAULT({0})", this.Generate((column.Type == PrimitiveTypeKind.DateTime) ? DateTime.Parse("1900-01-01 00:00:00") : (dynamic)column.ClrDefaultValue));

            string identity = column.IsIdentity ? "IDENTITY(1,1)" : string.Empty;
            string dataType = this.GetDataType(column);

            writer.Write(string.Format("[{0}] {1} {2} {3} {4}", column.Name, dataType, nullable, defaultValue, identity).Trim());
        }

        private string GetDataType(ColumnModel column)
        {
            switch (column.Type)
            {
                case Metadata.Edm.PrimitiveTypeKind.Boolean:
                    return "BIT";
                case Metadata.Edm.PrimitiveTypeKind.Byte:
                    return "TINYINT";
                case Metadata.Edm.PrimitiveTypeKind.DateTime:
                    return "DATETIME";
                case Metadata.Edm.PrimitiveTypeKind.Decimal:
                    if (!column.Precision.HasValue)
                        return "DECIMAL";
                    return string.Format("DECIMAL({0},{1})", column.Precision.HasValue ? column.Precision.Value : 18, column.Scale.HasValue ? column.Scale.Value : 0);
                case Metadata.Edm.PrimitiveTypeKind.Double:
                    return "DOUBLE";
                case Metadata.Edm.PrimitiveTypeKind.Guid:
                    return "UNIQUEIDENTIFIER";
                case Metadata.Edm.PrimitiveTypeKind.Int16:
                    return "SMALLINT";
                case Metadata.Edm.PrimitiveTypeKind.Int32:
                    return "INT";
                case Metadata.Edm.PrimitiveTypeKind.Int64:
                    return "BIGINT";
                case Metadata.Edm.PrimitiveTypeKind.Single:
                    return "FLOAT";
                case Metadata.Edm.PrimitiveTypeKind.String:
                    return string.Format("{0}{1}CHAR{2}", this.GetUnicodeValue(column), this.GetVarLengthValue(column), this.GetMaxLengthValue(column));
                case Metadata.Edm.PrimitiveTypeKind.Geometry:
                    return "GEOMETRY";
                case Metadata.Edm.PrimitiveTypeKind.Time:
                    return "TIME";
                case Metadata.Edm.PrimitiveTypeKind.DateTimeOffset:
                    return "DATETIMEOFFSET";
                case Metadata.Edm.PrimitiveTypeKind.Binary:
                    return string.Format("{0}BINARY{1}", GetVarLengthValue(column), GetMaxLengthValue(column));
                default:
                    return "SQL_VARIANT";
            }
        }

        private string GetUnicodeValue(ColumnModel column)
        {
            if (column.IsUnicode.GetValueOrDefault())
                return "N";
            return string.Empty;
        }

        private string GetVarLengthValue(ColumnModel column)
        {
            if (!column.IsFixedLength.GetValueOrDefault())
                return "VAR";
            return string.Empty;
        }

        private string GetMaxLengthValue(ColumnModel column)
        {
            if (column.MaxLength.HasValue)
                return string.Format("({0})", column.MaxLength.Value);
            return column.IsFixedLength.GetValueOrDefault() ? string.Empty : "(MAX)";
        }


        #endregion

        private static IEnumerable<MigrationOperation> ReplaceAddTableOperation(IEnumerable<MigrationOperation> operations)
        {
            foreach (var operation in operations)
            {
                var tableOperation = operation as CreateTableOperation;
                if (tableOperation != null)
                {
                    var nonKeyColumns = tableOperation.Columns.Where(c => !tableOperation.PrimaryKey.Columns.Contains(c.Name)).ToList();

                    nonKeyColumns.ForEachAsParallel(column => tableOperation.Columns.Remove(column));

                    yield return tableOperation;
                    yield return tableOperation.PrimaryKey;
                    foreach (var column in nonKeyColumns)
                        yield return new AddColumnOperation(tableOperation.Name, column);
                }
                else
                {
                    yield return operation;
                }
            }
        }

        private static IEnumerable<MigrationOperation> FilterMigrationOperations(IEnumerable<MigrationOperation> operations)
        {
            var dropTable = operations.OfType<DropTableOperation>().ToList();
            var dropColumns = operations.WhereIn<DropColumnOperation>(dropTable, (op, op2) => op2.Name == op.Table);
            var dropForeignKey = operations.WhereIn<DropForeignKeyOperation>(dropTable, (op, op2) => op2.Name == op.DependentTable || op2.Name == op.PrincipalTable);
            var dropIndex = operations.WhereIn<DropIndexOperation>(dropForeignKey, (op, op2) => op2.DependentTable == op.Table && op.Columns.ItemsEqual(op2.DependentColumns as object));
            var dropPrimaryKey = operations.WhereIn<DropPrimaryKeyOperation>(dropTable, (op, op2) => op2.Name == op.Table);

            var createTable = operations.WhereIn<CreateTableOperation>(dropTable, (op, op2) => op2.Name == op.Name);
            var addColumn = operations.WhereIn<AddColumnOperation>(dropColumns, (op, op2) => op2.Name == op.Column.Name && op2.Table == op.Table);
            var addForeignKey = operations.WhereIn<AddForeignKeyOperation>(dropForeignKey, (op, op2) => op2.Name == op.Name && op2.DependentTable == op.DependentTable && op2.PrincipalTable == op.PrincipalTable);
            var createIndex = operations.WhereIn<CreateIndexOperation>(dropIndex, (op, op2) => op.Table == op2.Table && op.Columns.ItemsEqual(op2.Columns as object));
            var addPrimaryKey = operations.WhereIn<AddPrimaryKeyOperation>(dropPrimaryKey, (op, op2) => op.Table == op2.Table && op.Columns.ItemsEqual(op2.Columns as object));

            var exceptions = new IEnumerable<MigrationOperation>[] {  
                dropTable,  
                dropColumns,  
                dropForeignKey,  
                dropIndex,  
                dropPrimaryKey,  
 
                createTable,  
                addPrimaryKey,
                addColumn,  
                addForeignKey,  
                createIndex                
            };

            var filteredOperations = operations.Except(exceptions.SelectMany(o => o));

            return UnifiedContextSqlGenerator.ReplaceAddTableOperation(filteredOperations).ToList();
        }
    }
}
