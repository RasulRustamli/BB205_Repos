using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB205_Ado.net.DataBase
{
    internal class Sql
    {
        private static readonly string connectionString = "server=DESKTOP-FHK353D;database=BB205_ADO;Trusted_connection=true;Integrated security=true;";
        private static readonly SqlConnection connection= new SqlConnection(connectionString);
        //non query method//delete update insert
        public int NonQueryProsses(string command)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(command, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close(); 
            return result; 
        }
        //query method select
        public DataTable Query(string command)
        {
            connection.Open();
            SqlDataAdapter query= new SqlDataAdapter(command,connection);
            DataTable table =new DataTable();
            query.Fill(table);
            connection.Close();
            return table;
        }
    }
}
