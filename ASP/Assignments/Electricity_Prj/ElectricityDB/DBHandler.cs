using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Electricity_Prj
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string connect = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(connect);
        }
    }
}
