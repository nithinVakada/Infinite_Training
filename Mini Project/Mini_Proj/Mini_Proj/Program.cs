using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Mini_Proj
{
    class Program
    {
        public static string connect = "Data Source=ICS-LT-2L6BJ84\\SQLEXPRESS;Initial Catalog=cd;" +
                "user id=sa;password=Nithinkumar@123; ";
        public static SqlConnection con = new SqlConnection(connect);
        public static SqlCommand cmd;
        static void Main(string[] args)
        {
           
            Console.WriteLine("*************** Welcome To E-Tikceting-Platform ************");
            bool do_looping = true;
            while(do_looping)
            {
               
                Console.WriteLine("\n Enter choice : ");
                Console.WriteLine("1.Login as Admin");
                Console.WriteLine("2.Login as Customer");
                Console.WriteLine("3.Exit");

                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1: Console.WriteLine("\t\t Admin Login!!!");
                            Console.WriteLine("Enter UserName");
                            string admin_username = Console.ReadLine();
                            Console.WriteLine("Enter Password");
                            string admin_password = Console.ReadLine();
                            if (AuthenticateAdmin(admin_username, admin_password))
                            {
                            AdminMenu();
                            } 
                            else
                            {
                            Console.WriteLine("Invalid Credentials!!!");
                            }
                         break;

                    case 2:
                        Console.WriteLine("\t\t User Login!!!");
                        Console.WriteLine("Enter UserName");
                        string customer_username = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        string customer_password = Console.ReadLine();
                        if (AuthenticateUser(customer_username, customer_password))
                        {
                            UserMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Credentials!!!");
                        }
                        break;
                    case 3:
                        do_looping = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!! Please Enter again");
                        break;
                } 

            }
            Console.WriteLine("Press Any key to exit");
            Console.Read();
        }
        static bool AuthenticateAdmin(string username, string password)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT role FROM Admin WHERE Admin_name = @username AND Admin_password = @password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = cmd.ExecuteReader();
            //string role = null;

            if (reader.Read())
            {
                //role = reader["role"].ToString();
                return true;
            }

            // Clean up resources manually
            //reader.Close();
            //reader.Dispose();
            //cmd.Dispose();
            //con.Close();
            //con.Dispose();

            return false;

        }
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("***************** Admin Menu **********************");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. View Cancellations");
                Console.WriteLine("3. Update Train");
                Console.WriteLine("4. Add Train");
                Console.WriteLine("5. Delete Train");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                int Admin_choice = int.Parse(Console.ReadLine());

                switch (Admin_choice)
                {
                    case 1:
                        ViewBookings();
                        break;
                    case 2:
                        ViewCancellations();
                        break;
                    case 3:
                        UpdateTrain();
                        break;
                    case 4:
                        AddTrain();
                        break;
                    case 5:
                        DeleteTrain();
                        break;
                    default:return;
                }
            }

        }

        static bool AuthenticateUser(string Username, string Password)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();

             cmd =new SqlCommand("SELECT role FROM Users WHERE User_name = @username AND password = @password", con);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", Password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return true;
            return false;
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancellation of Tickets");
                Console.WriteLine("4.Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                    
                    switch (choice)
                    {
                        case 1: ViewTrains(); break;
                        case 2: BookTickets(); break;
                        case 3: CancelTickets(); break;
                        case 4: return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }      
            }
        }

        static void ViewBookings()
        {
                con.Open();

                cmd = new SqlCommand("SELECT * FROM Bookings WHERE status = 'Active'", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Booking ID: {reader["Booking_id"]}, Train No: {reader["Train_no"]}, User ID: {reader["Cust_Id"]}, Seats: {reader["Seats_Booked"]}, Date: {reader["Date_Of_Booking"]}");
                }

                reader.Close();
                con.Close();
        }

        static void ViewCancellations()
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Cancellations", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Cancellation ID: {reader["cancellation_id"]}, Booking ID: {reader["booking_id"]}, Seats Cancelled: {reader["seats_cancelled"]}, Date: {reader["cancellation_date"]}");
            }

            reader.Close();
            con.Close();

        }

        static void UpdateTrain()
        {

        }
        static void AddTrain()
        {
            
            Console.WriteLine("\nEnter Train Details: ");
            Console.Write("Train No: ");
            int train_no = int.Parse(Console.ReadLine());
            Console.Write("Train Name: ");
            string train_name = Console.ReadLine();
            Console.Write("Source: ");
            string source = Console.ReadLine();
            Console.Write("Destination: ");
            string destination = Console.ReadLine();
            Console.Write("Class ID (1. First AC, 2. Second AC, 3. Third AC, 4. Sleeper): ");
            int class_id = int.Parse(Console.ReadLine());
            Console.Write("Seats Available: ");
            int seats_available = int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            int price = int.Parse(Console.ReadLine());

            cmd = new SqlCommand("proc_AddTrain",con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@train_no", train_no);
            cmd.Parameters.AddWithValue("@train_name", train_name);
            cmd.Parameters.AddWithValue("@source", source);
            cmd.Parameters.AddWithValue("@destination", destination);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            cmd.Parameters.AddWithValue("@seats_available", seats_available);
            cmd.Parameters.AddWithValue("@price", price);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Console.WriteLine("Train is Added Successfully");
                con.Close();
                return;
            }

            Console.WriteLine("Train is not added");
            con.Close();
        }

        static void DeleteTrain()
        {
            Console.WriteLine("Enter Train numer to delete");
            int trainNo = int.Parse(Console.ReadLine());
            con.Open();

            try
            {
                cmd = new SqlCommand("DELETE FROM Train_Class WHERE Train_No = @Train_No", con);
                cmd.Parameters.AddWithValue("@Train_No", trainNo);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM Trains WHERE Train_No = @Train_No", con);
                cmd.Parameters.AddWithValue("@Train_No", trainNo);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting train: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static void ViewTrains()
        {
            con.Open();
            cmd = new SqlCommand("Select * from Trains", con);
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine(dr["Train_No"].ToString()+"  "+dr["Train_Name"]+"  "+dr["Source_Station"]);
            }
            // Console.WriteLine("");
            con.Close();

        }

        static void BookTickets()
        {
            cmd = new SqlCommand("proc_BookTickets", con);
            con.Open();

            Console.WriteLine("\n Enter the following details to book your ticekts");
            Console.WriteLine("Enter User_Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Train no:");
            int trainNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Class ID : ");
            int classID = int.Parse(Console.ReadLine());
            Console.WriteLine("Date of Travel (yyyy-mm-dd) :");
            DateTime travelDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("No. of seats to book : ");
            int seats = int.Parse(Console.ReadLine());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_Name", userName);
            cmd.Parameters.AddWithValue("@Train_no", trainNo);
            cmd.Parameters.AddWithValue("@class_id", classID);
            cmd.Parameters.AddWithValue("@Date_of_Travel", travelDate);
            cmd.Parameters.AddWithValue("@Seats_booked", seats);

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Console.WriteLine("Booking Id : "+reader["Booking_id"]);
            }
            reader.Close();
            con.Close();
        }

        static void CancelTickets()
        {
            try
            {
               
                Console.WriteLine("\nEnter Cancellation Details");
                Console.Write("User Name: ");
                string user_name = Console.ReadLine();
                Console.Write("Booking ID: ");
                int bookingId=int.Parse(Console.ReadLine());  ;
                Console.Write("Seats to Cancel: ");
                int seats=int.Parse(Console.ReadLine()); 

                cmd = new SqlCommand("proc_CancelTickets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_name", user_name);
                cmd.Parameters.AddWithValue("@bookingID", bookingId);
                cmd.Parameters.AddWithValue("@seats_toGet_Cancelled", seats);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["Message"].ToString());
                }
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                    con.Close();
            }


        }


    }
}
