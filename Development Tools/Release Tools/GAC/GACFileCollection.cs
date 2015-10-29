using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.GAC
{
    public sealed class GACFileCollection
        : IDictionary<string, GACFile>
    {
        public GACFileCollection()
            : base()
        {
            this.gacFiles = new Dictionary<string, GACFile>();
        }

        #region Private Declarations
        private Dictionary<string, GACFile> gacFiles;
        private readonly object syncObject = new object();
        #endregion

        #region Public Read-Only Properties
        public int Count
        {
            get
            {
                lock (this.syncObject)
                {
                    return this.gacFiles.Count;
                }
            }
        }
        #endregion


        public void Add(FileInfo file)
        {
            GACFile assemblyFile = new GACFile(file);
            if (!this.gacFiles.ContainsKey(assemblyFile.Name))
            {
                this.gacFiles.Add(assemblyFile.Name, assemblyFile);
            }
            else
            {
                this.gacFiles[assemblyFile.Name] = assemblyFile;
            }
        }

        public void Add(GACFile file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

            if (!this.gacFiles.ContainsKey(file.Name))
            {
                this.gacFiles.Add(file.Name, file);
            }
            else
            {
                this.gacFiles[file.Name] = file;
            }
        }

        public bool Add(AssemblyName assemblyName)
        {
            try
            {
                this.Add(new GACFile(assemblyName));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Add(string filePath)
        {
            this.Add(new FileInfo(filePath));
        }

        

        

        private static void ProcessAsmName(object state)
        {
            AssemblyName asm = (AssemblyName) ((object[]) state)[0];
            GACFileCollection returnValue = (GACFileCollection)((object[])state)[1];
            try
            {
                GACFile file = new GACFile(asm);
                returnValue.gacFiles.Add(file.Name, file);
                Console.WriteLine(returnValue.gacFiles.Count);
            }
            catch
            {
            }
            finally
            {
                Interlocked.Increment(ref addCount);
            }
        }
        private static long count = 0;
        private static long addCount = 0;
        private static long errorCount = 0;
        private static ManualResetEventSlim mre;
        public IEnumerator<GACFile> GetEnumerator()
        {
            return this.gacFiles.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.gacFiles.Values.GetEnumerator();
        }

        private static double GetRatio()
        {
            double a = Convert.ToDouble(Interlocked.Read(ref addCount));
            double e = Convert.ToDouble(Interlocked.Read(ref errorCount));
            double c = Convert.ToDouble(Interlocked.Read(ref count));
            return (a + e) / c;
        }
        private static long threadCount = 0;
        private void ProcessGAC(object state)
        {
            Interlocked.Increment(ref threadCount);
            Console.WriteLine("Threads increased to {0}...", Interlocked.Read(ref threadCount));
            Console.WriteLine("Ratio: {0}", GetRatio());
            AssemblyName f = null;
            GACFileCollection returnValue = (GACFileCollection) ((object[])state)[0];
            Queue<AssemblyName> queue = (Queue<AssemblyName>) ((object[])state)[1];
            bool processFinished = (bool) ((object[])state)[2];
            while (true)
            {
                lock (syncObject)
                {
                    f = (queue.Count > 0) ? queue.Dequeue() : null;
                }

                if (f == null)
                    continue;
                try
                {
                    returnValue.Add(new GACFile(f));
                    Interlocked.Increment(ref addCount);


                }
                catch
                {
                    Interlocked.Increment(ref errorCount);
                }
                finally
                {
                    double ratio = GetRatio();
                    
                    if (ratio < 0.5 && Interlocked.Read(ref threadCount) < 25)
                    {
                        Thread t = new Thread(new ParameterizedThreadStart(ProcessGAC));
                        t.IsBackground = true;
                        t.Start(state);

                    }
                }
                long readCount2 = Interlocked.Read(ref addCount);
                long errorCount2 = Interlocked.Read(ref errorCount);
                long count2 = Interlocked.Read(ref count);
                if (processFinished &&
                        (readCount2 + errorCount2 == count2))
                    break;
            }
            mre.Set();
        }

        void IDictionary<string, GACFile>.Add(string key, GACFile value)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, GACFile>.ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        ICollection<string> IDictionary<string, GACFile>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<string, GACFile>.Remove(string key)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, GACFile>.TryGetValue(string key, out GACFile value)
        {
            throw new NotImplementedException();
        }

        ICollection<GACFile> IDictionary<string, GACFile>.Values
        {
            get { throw new NotImplementedException(); }
        }

        GACFile IDictionary<string, GACFile>.this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void ICollection<KeyValuePair<string, GACFile>>.Add(KeyValuePair<string, GACFile> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, GACFile>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, GACFile>>.Contains(KeyValuePair<string, GACFile> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, GACFile>>.CopyTo(KeyValuePair<string, GACFile>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        

        bool ICollection<KeyValuePair<string, GACFile>>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<KeyValuePair<string, GACFile>>.Remove(KeyValuePair<string, GACFile> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<string, GACFile>> IEnumerable<KeyValuePair<string, GACFile>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
