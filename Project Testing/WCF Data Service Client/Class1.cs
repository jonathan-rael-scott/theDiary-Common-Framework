using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Data_Service_Client
{
    public class Program
    {
        public static void Main(object[] args)
        {

        }
    }
    public class Class1
    {
        public void Test()
        {
            ServiceReference1.WahlEntities context = new ServiceReference1.WahlEntities(null);
            var b = from a in context.Suppliers
                    where !string.IsNullOrWhiteSpace(a.TelephoneNumber)
                    select a;
        }
    }
}
