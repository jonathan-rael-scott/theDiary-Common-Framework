using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seth.Tools.Development.HostFileManager.Example
{
    class Class1
    {
        public string LoadTemplate()
        {
            var stream = typeof(Class1).Assembly.GetManifestResourceStream("Seth.Tools.Development.HostFileManager.Example.MyTemplate.template");
            var a = new StreamReader(stream);
            string templateCOnent = a.ReadToEnd();
            templateCOnent = templateCOnent.Replace("{Title:Column1}", "Hello Word");
            templateCOnent = templateCOnent.Replace("{Title:Column2}", "Hello Word 2");
            templateCOnent = templateCOnent.Replace("{Title:Column3}", "Hello Word 9");
            templateCOnent = templateCOnent.Replace("{Title:Column4}", "Hello Word 18");
            templateCOnent = templateCOnent.Replace("{Body:Main}", "Hello Word Body");

            return templateCOnent;
        }

        public void Save()
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();                
                command.CommandText = "sp_who2";
                command.CommandType = System.Data.CommandType.Text;

                command.ExecuteNonQuery();
            }
        }

        public void SaveWithExtensions()
        {
            this.ExecuteNonQuery("sp_who2");
        }
    }

    public static class SqlClientExtensions
    {
        public static void ExecuteNonQuery(this object instance, string sqlCommand)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sqlCommand;
                command.CommandType = System.Data.CommandType.Text;

                command.ExecuteNonQuery();
            }
        }

        public static bool IsNumber(this string value)
        {
            double v;
            return double.TryParse(value, out v);
        }

    }
}
