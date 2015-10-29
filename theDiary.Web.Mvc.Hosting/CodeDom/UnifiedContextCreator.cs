using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.EntityFramework.V5
{
    public class UnifiedContextCreator
    { 
         #region Constructors
        public UnifiedContextCreator()
            : base()
        {
            this.classSource = new System.StringBuilder(UnifiedContextCreator.GetTemplate("UnifiedContext"));
            this.dbSets = new Dictionary<Type, string>();
            this.namespaces = new List<string>();

            this.referencedAssemblies = new List<string>();
            this.AddAssemblyReference(typeof(UnifiedContextCreator).Assembly);
        }
        #endregion

        #region Protected Constant Declarations
        protected const string RootNamespace = "theDiary.Web.Mvc.DynamicContext";
        #endregion

        #region Private Declarations
        private List<string> referencedAssemblies;
        private List<string> namespaces;
        private Dictionary<Type, string> dbSets;

        private System.StringBuilder classSource;
        #endregion

        public static string GetTemplate(string templateName)
        {
            string resourceName = typeof(UnifiedContextCreator).Assembly.GetManifestResourceNames().Where(a => a.EndsWith(string.Format("{0}.template", templateName), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            using (StreamReader reader = new StreamReader(typeof(UnifiedContextCreator).Assembly.GetManifestResourceStream(resourceName)))
            {
                return reader.ReadToEnd();
            }
        }
        public void AddContext(DbContext context)
        {
            this.AddContext(context.GetType());
        }

        public void AddContext(Type contextType)
        {
            this.AddAssemblyReference(contextType.Assembly);
            foreach (var property in contextType.GetProperties())
            {
                if (property.PropertyType.GenericTypeArguments.Length == 0)
                    continue;
                Type dbSetType = property.PropertyType.GenericTypeArguments[0];
                if (property.PropertyType != typeof(DbSet<>).MakeGenericType(dbSetType))
                    continue;
                string @namespace = dbSetType.Namespace;
                
                if (!this.namespaces.Contains(@namespace))
                    this.namespaces.Add(@namespace);
                this.dbSets.Add(dbSetType, property.Name);
            }
        }

        private void AddAssemblyReference(AssemblyName assemblyName)
        {
            Assembly.Load(assemblyName);
            this.referencedAssemblies.Add(string.Format("{0}.dll", assemblyName.Name));
        }

        private void AddAssemblyReference(Assembly assembly)
        {
            foreach (var refAsmName in assembly.GetReferencedAssemblies())
                this.AddAssemblyReference(refAsmName);
            this.AddAssemblyReference(assembly.GetName());
        }

        #region Public Properties
        public string ClassName
        {
            get
            {
                return "UnifiedContext";
            }
        }

        public IEnumerable<string> ReferencedAssemblies
        {
            get
            {
                return this.referencedAssemblies.AsEnumerable();
            }
        }

        public string ClassSource
        {
            get
            {
                return this.classSource.ToString();
            }
        }

        public string FullClassName
        {
            get
            {
                return string.Format("{0}.{1}", UnifiedContextCreator.RootNamespace, this.ClassName);
            }
        }
        #endregion

        private string GenerateUsingClauseNamespaces()
        {
            System.StringBuilder returnValue = new System.StringBuilder();
            foreach (var @namespace in this.namespaces.Distinct())
                returnValue.AppendFormat("using {0};", @namespace);

            return returnValue;
        }

        private string GenerateDbSets()
        {
            System.StringBuilder returnValue = new System.StringBuilder();
            foreach (var dbSet in this.dbSets)
            {    
                returnValue.AppendFormat("\t\t public DbSet<{0}> {1}", dbSet.Key.Name, dbSet.Value);
                returnValue.AppendLine(" { get; set; }");
                returnValue.AppendLine();
            }
            return returnValue;
        }

        private string GetClassSource()
        {
            System.StringBuilder classSource = new System.StringBuilder(this.classSource.ToString());
            classSource.Replace("{ClassName}", this.ClassName);
            classSource.Replace("{Template:UsingClauseNamespaces}", this.GenerateUsingClauseNamespaces());
            classSource.Replace("{Template:DbSets}", this.GenerateDbSets());

            return classSource;
        }

        public DbContext CreateInstance()
        {
            var loCompiler = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            foreach (var referencedAssembly in this.ReferencedAssemblies.Distinct())
            {
                string assemblyPath = string.Format("{0}\\bin\\{1}", AppDomain.CurrentDomain.BaseDirectory, referencedAssembly);
                parameters.ReferencedAssemblies.Add((System.IO.File.Exists(assemblyPath)) ? assemblyPath : referencedAssembly);
            }
            CompilerResults compilerResult = loCompiler.CompileAssemblyFromSource(parameters, this.GetClassSource());
            if (compilerResult.Errors.HasErrors)
            {
                System.StringBuilder errors = new System.StringBuilder("Error Generating Class");
                errors.AppendLine();
                foreach (var error in compilerResult.Errors)
                    errors.AppendLine(error.ToString());
                throw new InvalidOperationException(errors.ToString());
            }
            return (DbContext) compilerResult.CompiledAssembly.CreateInstance(this.FullClassName);
        }
    }
}
