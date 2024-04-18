using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectsql
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=LAPTOP-UEQBLNF9;Initial Catalog=CUAHANGBACHHOA;Integrated Security=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
