using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//Write a stored Procedure that inserts records in the Employee_Details table
 
//The procedure should generate the EmpId automatically to insert and should return the generated value to the user
 
//Also the Salary Column is a calculated column (Salary is givenSalary - 10%)
 
//Table: Employee_Details(Empid, Name, Salary, Gender)
//Hint(User should not give the EmpId)


//Test the Procedure using ADO classes and show the generated Empid and Salary

namespace Question1
{
    class Program
    {
        
        static void Main()
        {      
            InsertValues();
            Display();
            Console.Read();
        }

        static SqlConnection getConnection()
        {
            string connectionString = "Data Source=ICS-LT-2L6BJ84\\SQLEXPRESS;Initial Catalog=CodeChallenge;" +
                "user id=sa;password=Nithinkumar@123; "; ;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        static void InsertValues()
        {

            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary : ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Gender : ");
            string gender = Console.ReadLine();


            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand("InsertEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@Gender", gender);

            // Output parameters
            SqlParameter empIdParam = new SqlParameter("@EmpId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(empIdParam);

            SqlParameter netSalaryParam = new SqlParameter("@NetSalary", SqlDbType.Decimal)
            {
                Precision = 10,
                Scale = 2,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(netSalaryParam);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("\n Record is inserted successfully!");
                Console.WriteLine("Generated Employee Id is: " + empIdParam.Value);
                Console.WriteLine("Net Salary : " + netSalaryParam.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static void Display()
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee_Details", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nAll Employee Records:");
                Console.WriteLine("--------------------------------------------------");

                while (dr.Read())
                {
                    Console.WriteLine($"EmpId     : {dr["EmpId"]}");
                    Console.WriteLine($"Name      : {dr["Name"]}");
                    Console.WriteLine($"Salary    : {dr["Salary"]}");
                    Console.WriteLine($"Gender    : {dr["Gender"]}");
                    Console.WriteLine($"NetSalary : {dr["NetSalary"]}");
                    Console.WriteLine("--------------------------------------------------");
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }

}

