using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Question1
{
    class Updation
    {

        static string connectionString = "Data Source=ICS-LT-2L6BJ84\\SQLEXPRESS;Initial Catalog=CodeChallenge;" +
                "user id=sa;password=Nithinkumar@123; ";
        static SqlCommand cmd = null;
        static SqlDataReader dr = null;


        static void Main()
        {
            UpdateSalary();
            Console.Read();
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void Display(int empId)
        {
            SqlConnection conn = GetConnection();

            cmd = new SqlCommand("SELECT * FROM Employee_Details WHERE EmpId = @EmpId", conn);
            cmd.Parameters.AddWithValue("@EmpId", empId);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Console.WriteLine("Employee Details:");
                Console.WriteLine($"EmpId: {dr["EmpId"]}");
                Console.WriteLine($"Name: {dr["Name"]}");
                Console.WriteLine($"Salary: {dr["Salary"]}");
                Console.WriteLine($"Gender: {dr["Gender"]}");
                Console.WriteLine($"NetSalary: {dr["NetSalary"]}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }


            conn.Close();
        }

        public static void UpdateSalary()
        {
            Console.Write("Enter Employee ID to update salary: ");
            int empId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before Update:");
            Display(empId);

            SqlConnection conn = GetConnection();

            SqlCommand cmd = new SqlCommand("UpdateEmployeeSalary", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", empId);

            SqlParameter salaryParam = new SqlParameter("@UpdatedSalary", SqlDbType.Decimal);
            salaryParam.Direction = ParameterDirection.Output;
            salaryParam.Precision = 10;
            salaryParam.Scale = 2;
            cmd.Parameters.Add(salaryParam);

            cmd.ExecuteNonQuery();

            decimal updatedSalary = (decimal)salaryParam.Value;
            Console.WriteLine($"Updated Salary for EmpId {empId}: {updatedSalary}");

            conn.Close();
            Console.WriteLine("\nAfter Update:");
            Display(empId);
        }
    }

}


