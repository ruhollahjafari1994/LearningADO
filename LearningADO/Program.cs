using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LearningADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Server=185.116.163.16,2016;Database=jafariir_DB;User Id=jafariir_ADW;Password=G@briel77;";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            Console.WriteLine("connection Established Successfully");
            Console.ReadLine();
        }
    }
}
