using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public interface IEntry
    {
        Guid EntryId { get; }
        string LineText { get; }
    }

    public sealed class HostComment
        : IEntry
    {
        public HostComment(string text)
        {
            this.EntryId = Guid.NewGuid();
            this.LineText = text;
        }
        public Guid EntryId { get; private set; }
        public string LineText { get; private set; }
    }

    public sealed class HostEntry
        : IEntry
    {
        #region Constructors
        public HostEntry()
        {
            this.entryId = Guid.NewGuid();
        }

        private HostEntry(string hostEntry)
            : this()
        {
            string[] vals = hostEntry.Split(new char[0]);
            bool enabled = (hostEntry[0] == '#');
            int startIndex = enabled ? 0 : 1;
            string ipAddress = vals[0].Substring(startIndex);
            string destination = vals[1];
            string description = vals.Length > 2 ? vals[2] : string.Empty;

            this.IPAddress = IPAddress.Parse(ipAddress);
            this.Enabled = enabled;
            this.Description = description;
            this.Destination = destination;
        }

        public HostEntry(string destination, string ipAddress, bool enabled = true)
            : this(destination, IPAddress.Parse(ipAddress), string.Empty, enabled)
        {
        }

        public HostEntry(string destination, IPAddress ipAddress, bool enabled = true)
            : this(destination, ipAddress, string.Empty, enabled)
        {
        }

        public HostEntry(string destination, string ipAddress, string description = "", bool enabled = true)
            : this(destination, IPAddress.Parse(ipAddress), destination, enabled)
        {
        }

        public HostEntry(string destination, IPAddress ipAddress, string description = "", bool enabled = true)
            : this()
        {
            this.IPAddress = ipAddress;
            this.Enabled = enabled;
            this.Description = description;
            this.Destination = destination;
        }
        #endregion

        #region Private Declarations
        private Guid entryId;
        #endregion

        #region IEntry Implementation
        Guid IEntry.EntryId
        {
            get
            {
                return this.entryId;
            }
        }

        string IEntry.LineText
        {
            get 
            { 
                return this.ToString(); 
            }
        }
        #endregion

        #region Public Properties
        public string Description { get; set; }

        public IPAddress IPAddress { get; set; }

        public bool Enabled { get; set; }

        public string Destination { get; set; }
        #endregion

        #region Public Methods & Functions
        public override string ToString()
        {
            string enabled = this.Enabled ? string.Empty : "#";

            return string.Format("{2}{0}\t{1}\t{3}", this.IPAddress, this.Destination, enabled, this.Description ?? string.Empty);
        }
        #endregion

        #region Public Static Methods & Functions
        public static HostEntry Parse(string value)
        {
            HostEntry hostEntry;
            if (!HostEntry.TryParse(value, out hostEntry))
                throw new InvalidOperationException("The specified value is not a valid host entry.");

            return hostEntry;
        }

        public static bool TryParse(string value, out HostEntry hostEntry)
        {
            hostEntry = null;
            if (value.Length == 0)
                return false;
            value = value.Trim();
            string[] vals = value.Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (vals.Length < 2)
                return false;

            bool enabled = (value[0] != '#');
            int startIndex = enabled ? 0 : 1;
            string ipAddressValue = vals[0].Substring(startIndex);

            string destination = vals[1];
            string description = vals.Length > 2 ? value.Substring(value.IndexOf(vals[2])) : string.Empty;
            IPAddress ipAddress;

            if (IPAddress.TryParse(ipAddressValue, out ipAddress))
                hostEntry = new HostEntry(destination, ipAddress, description, enabled);

            return (hostEntry != null);
        }

        public static explicit operator string[](HostEntry hostEntry)
        {
            return new string[]{
                hostEntry.IPAddress.ToString(),
                hostEntry.Destination,
                hostEntry.Enabled ? "Enabled" : "Disabled",
                hostEntry.Description
            };
        }
        #endregion

        
    }
}
