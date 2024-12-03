using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SqlConnection cs = new SqlConnection("Data Source= localhost; Initial Catalog = warframe; Integrated Security= true");

            display p = new display();

            p.Menu();

          


            Console.ReadKey();
        }
    }
}
