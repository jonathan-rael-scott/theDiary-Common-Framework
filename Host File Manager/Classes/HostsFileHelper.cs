using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public static class HostsFileHelper
    {
        private static readonly string hostsFilePath = string.Format(@"{0}\System32\Drivers\Etc\hosts", System.Environment.GetEnvironmentVariable("SystemRoot"));
        private static System.IO.FileInfo hostsFile = null;
        private static bool isDirty = false;
        private static Dictionary<Guid, IEntry> entries = new Dictionary<Guid, IEntry>();

        public static string HostsFilePath
        {
            get
            {
                return HostsFileHelper.hostsFilePath;
            }
        }

        public static System.IO.FileInfo HostsFile
        {
            get
            {
                if (HostsFileHelper.hostsFile == null)
                    HostsFileHelper.hostsFile = new System.IO.FileInfo(HostsFileHelper.HostsFilePath);

                return HostsFileHelper.hostsFile;
            }
        }

        public static IEnumerable<HostEntry> GetHostEntries(bool refresh = false)
        {            
            if (refresh || entries.Count == 0)
            {
                entries.Clear();
                using (var reader = HostsFileHelper.HostsFile.OpenText())
                {
                    while (!reader.EndOfStream)
                    {
                        IEntry entry = null;
                        HostEntry hostEntry;
                        string lineText = reader.ReadLine();
                        if (HostEntry.TryParse(lineText, out hostEntry))
                        {
                            entry = hostEntry;
                        }
                        else
                        {
                            entry = new HostComment(lineText);
                            
                        }
                        entries.Add(entry.EntryId, entry);
                    }
                }
                HostsFileHelper.IsDirty = false;
            }

            return entries.Values.Where(entry => entry is HostEntry).Cast<HostEntry>();
        }

        public static IEntry GetEntry(Guid entryId)
        {
            return entries[entryId];
        }

        public static void RemoveEntry(IEntry entry)
        {
            if(entries.Remove(entry.EntryId))
                HostsFileHelper.IsDirty = true;
        }

        public static IEntry SetEntry(IEntry entry)
        {
            if (entries.ContainsKey(entry.EntryId))
            {
                entries[entry.EntryId] = entry;
            }
            else
            {
                entries.Add(entry.EntryId, entry);
            }
            HostsFileHelper.IsDirty = true;
            return entry;
        }
        
        public static bool IsDirty
        {
            get
            {
                return HostsFileHelper.isDirty;
            }
            private set
            {
                if (value == HostsFileHelper.isDirty)
                    return;

                HostsFileHelper.isDirty = value;
                if (HostsFileHelper.IsDirtyHandler != null)
                    HostsFileHelper.IsDirtyHandler(null, new EventArgs());
            }
        }
        public static event EventHandler IsDirtyHandler;
        public static void SaveHostEntries()
        {
            using (StreamWriter writer = new StreamWriter(HostsFileHelper.HostsFile.Open(FileMode.Create)))
            {
                foreach (IEntry entry in entries.Values)
                    writer.WriteLine(entry.LineText);
                HostsFileHelper.IsDirty = false;
            }
        }
    }
}
