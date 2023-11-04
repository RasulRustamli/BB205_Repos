using BB205_Ado.net.Models;
using BB205_Ado.net.Services;
using System.Data;
using System.Data.SqlClient;

namespace BB205_Ado.net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ado.net intro
            //string con = "server=DESKTOP-FHK353D;database=BB205_ADO;Trusted_connection=true;Integrated security=true;";

            //using (SqlConnection connection = new SqlConnection(con))
            //{
            //    connection.Open();
            //    //non query method// Insert,Delete Update
            //    //string cmd = "INSERT INTO Students VALUES('Fidan',19)";

            //    //using (SqlCommand command = new SqlCommand(cmd, connection))
            //    //{
            //    //    int result = command.ExecuteNonQuery();
            //    //    if (result > 0)
            //    //    {
            //    //        Console.WriteLine("Succes");
            //    //    }
            //    //    else
            //    //    {
            //    //        Console.WriteLine("We have some problems");
            //    //    }
            //    //}

            //    string selectQuery = "SELECT * FROM Students";
            //    using (SqlDataAdapter query=new SqlDataAdapter(selectQuery,connection))
            //    {
            //        DataTable table=new DataTable();

            //        query.Fill(table);

            //        //foreach (DataColumn dr in table.Columns)
            //        //{
            //        //    Console.Write(dr+"| ");
            //        //}
            //        foreach (DataRow item in table.Rows)
            //        {
            //            Console.WriteLine("");
            //            Console.WriteLine(item["Id"]+" "+item["Name"]+" "+item["Age"]);
            //        }

            //    }

            //}
            #endregion


            StudentsService studentsService = new StudentsService();
            Student student = new Student()
            {
                Name = "Emil",
                Age = 19
            };

            //studentsService.Add(student);

            studentsService.Delete(3);


            foreach (var item in studentsService.GetAll())
            {
                Console.WriteLine(item);
            }







        }
    }
}