using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService_Test.WahlEntities1 context = new WahlEntities1();
            //ServiceReference1.WahlEntities context = new ServiceReference1.WahlEntities(new Uri("http://localhost:15741/WcfDataService1.svc"));

            IEnumerable<DataService_Test.Company> companies = (from a in context.Company
                                             select a).ToArray();
                        
            foreach (var company in companies)
                Console.WriteLine(company.CompanyName);

            context.Company.Add(new Company()
            {
                CompanyName = "My Test Company " + companies.Count() + 1,
            });
            context.Database.Connection.
            context.SaveChanges();
        }
    }
}
