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
using System.Web.Mvc;
using System.Web.Mvc.Hosting;

namespace System.Web.Mvc.Hosting
{
    public class AreaRegistrationCreator
    { 
         #region AreaRegistrationCreator
        public AreaRegistrationCreator(IHostedApplication hostedApplication)
            : base()
        {
            this.classSource = new System.StringBuilder(AreaRegistrationCreator.GetTemplate("AreaRegistration"));
            this.dbSets = new Dictionary<Type, string>();
            this.namespaces = new List<string>();
            this.hostedApplication = hostedApplication;
            this.referencedAssemblies = new List<string>();
            this.AddAssemblyReference(typeof(AreaRegistrationCreator).Assembly);
        }
        #endregion

        #region Protected Constant Declarations
        protected const string RootNamespace = "theDiary.Web.Mvc.Hosting";
        #endregion

        #region Private Declarations
        private List<string> referencedAssemblies;
        private List<string> namespaces;
        private Dictionary<Type, string> dbSets;
        private IHostedApplication hostedApplication;
        private System.StringBuilder classSource;
        #endregion

        public static string GetTemplate(string templateName)
        {
            string resourceName = typeof(AreaRegistrationCreator).Assembly.GetManifestResourceNames().Where(a => a.EndsWith(string.Format("{0}.template", templateName), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            using (StreamReader reader = new StreamReader(typeof(AreaRegistrationCreator).Assembly.GetManifestResourceStream(resourceName)))
            {
                return reader.ReadToEnd();
            }
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
        public string HostedApplicationName
        {
            get
            {
                return this.hostedApplication.ApplicationName;
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
                return string.Format("{0}.{1}AreaRegistration", AreaRegistrationCreator.RootNamespace, this.HostedApplicationName);
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

        private string GetClassSource()
        {
            System.StringBuilder classSource = new System.StringBuilder(this.classSource.ToString());
            classSource.Replace("{HostedApplicationName}", this.HostedApplicationName);
            classSource.Replace("{ApplicationNamespaces}", this.hostedApplication.ApplicationContextType.Assembly.GetTypes().Where(a => a.IsSubclassOf(typeof(Controller))).Select<Type, string>(a => a.Namespace).Distinct().Concat("\",\""));
            return classSource;
        }

        public AreaRegistration CreateInstance()
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
            return (AreaRegistration) compilerResult.CompiledAssembly.CreateInstance(this.FullClassName);
        }

        public static dynamic Create(IHostedApplication hostedApplication)
        {
            var creator = new AreaRegistrationCreator(hostedApplication);
            return creator.CreateInstance();
        }
    }
}
