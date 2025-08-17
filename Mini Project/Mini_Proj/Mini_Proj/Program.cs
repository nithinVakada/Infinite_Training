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
                Console.WriteLine("3.Registration");
                Console.WriteLine("4.Exit");

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
                        string name = AuthenticateUser(customer_username, customer_password);
                        if (AuthenticateUser(customer_username, customer_password)!=null)
                        {
                            Console.WriteLine("\n Welcome {0}",name);
                            UserMenu(name);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Credentials!!!");
                        }
                        break;

                    case 3: Register();
                        break;
                    case 4:
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

        static void Register()
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                Console.WriteLine("Enter User Name");
                string uname = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string pw = Console.ReadLine();
                Console.WriteLine("Enter Phone Number");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                SqlCommand cmd = new SqlCommand("Insert into Users(User_name,Phone,Email,Password,Role) values(@uname,@phone,@email,@pw,'user')", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pw", pw);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    Console.WriteLine("Successfully inserted user");
                }
                else
                {
                    Console.WriteLine("Not Inserted");
                }

            }
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
            
           con.Close();
            return false;

        }
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("***************** Admin Menu **********************");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. View Cancellations");
                Console.WriteLine("3. Add Train or Add Trains Class");
                Console.WriteLine("4. Delete Train");
                Console.WriteLine("5.View Trains");
                Console.WriteLine("6.Reactivate Train");
                Console.WriteLine("7.Check Seats Availability");
                Console.WriteLine("8. Logout");
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
                        AddTrain();
                        break;
                    case 4:
                        DeleteTrain();
                        break;
                    case 5:ViewTrains();
                        break;
                    case 6:ReactivateTrain();
                        break;
                    case 7: GetSeatsAvailable();
                        break;
                    default:return;
                }
            }

        }

        static string AuthenticateUser(string Username, string Password)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();

             cmd =new SqlCommand("SELECT role FROM Users WHERE User_name = @username AND password = @password", con);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", Password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return Username;
            return null;
        }

        static void UserMenu(string name)
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancellation of Tickets");
                Console.WriteLine("4. Check Seats Availability");
                Console.WriteLine("5. View My Bookings");
                Console.WriteLine("6.Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                    
                    switch (choice)
                    {
                        case 1: ViewTrains(); break;
                        case 2: BookTickets(name); break;
                        case 3: CancelTickets(name); break;
                        case 4: GetSeatsAvailable();break;
                        case 5:ViewMyBookings(name);break;
                        case 6: return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }      
            }
        }

        static void ReactivateTrain()
        {
            con.Open();
            Console.Write("Enter train no to reactivate: ");
            int trainno = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("sp_Reactivate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@trainno", trainno);
            SqlDataReader reader = cmd.ExecuteReader();

            
                // Console.WriteLine($"Booking ID: {reader["Booking_id"]}, Train No: {reader["Train_no"]}, User ID: {reader["Cust_Id"]}, Seats: {reader["Seats_Booked"]}, Date: {reader["Date_Of_Booking"]}");
                Console.WriteLine("Train Marked as Active Succesfully");
            

            reader.Close();
            con.Close();
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

            //if (dr.Read())
            //{
            //    Console.WriteLine("Train is Added Successfully");
            //    con.Close();
            //    return;
            //}

            Console.WriteLine("Train is  added");
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


                //cmd = new SqlCommand("UPDATE Bookings SET Status = 'Inactive' WHERE Train_No = @Train_No", con);
                //cmd.Parameters.AddWithValue("@Train_No", trainNo);
                //cmd.ExecuteNonQuery();


                Console.WriteLine("Train deleted successfully ");
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
            cmd = new SqlCommand("Select * from Trains where status = 'Active'  ", con);
            SqlDataReader dr=cmd.ExecuteReader();
            Console.WriteLine();
            while(dr.Read())
            {
                Console.WriteLine(dr["Train_No"].ToString()+"  "+dr["Train_Name"]+"  "+dr["Source_Station"]+"-->"+dr["Destination_Station"]);
            }
            // Console.WriteLine("");
            con.Close();

        }

        //static void GetSeatsAvailable()
        //{
        //    Console.Write("Enter Train Number: ");
        //    int trainNo = int.Parse(Console.ReadLine());

        //    Console.Write("Class ID (1. First AC, 2. Second AC, 3. Third AC, 4. Sleeper): ");
        //    int classId = int.Parse(Console.ReadLine());

            

        //    using (SqlConnection conn = new SqlConnection(connect))
        //    {
        //        string query = "SELECT Seats_Available FROM Train_Class WHERE Train_No = @TrainNo AND Class_Id = @ClassId";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@TrainNo", trainNo);
        //            cmd.Parameters.AddWithValue("@ClassId", classId);

        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    int seatsAvailable = reader.GetInt32(0);
        //                    Console.WriteLine($"Seats Available: {seatsAvailable}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("No data found for the given Train Number and Class ID.");
        //                }
        //            }
        //        }
        //    }
        //}

        static void GetSeatsAvailable()
        {
            Console.Write("Enter Train Number: ");
            int trainNo = int.Parse(Console.ReadLine());

            
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(connect);
                string query = @"
            SELECT TC.Class_Id, C.Class_Name, TC.Seats_Available
            FROM Train_Class TC
            JOIN Class C ON TC.Class_Id = C.Class_Id
            WHERE TC.Train_No = @TrainNo";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                con.Open();
                reader = cmd.ExecuteReader();

                Console.WriteLine("\nSeats Availability:");
                while (reader.Read())
                {
                    Console.WriteLine($"Class: {reader["Class_Name"]} (ID: {reader["Class_Id"]}) - Seats Available: {reader["Seats_Available"]} ");
                }

                if (!reader.HasRows)
                {
                    Console.WriteLine("No seat availability found for the given Train Number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
                 con.Close();
            }
        }



        static void BookTickets(string name)
        {
            cmd = new SqlCommand("proc_BookTickets", con);
            con.Open();

            Console.WriteLine("\n Enter the following details to book your ticekts");
           // Console.WriteLine("Enter Passenger Name");
            // string userName = Console.ReadLine();
            string userName = name;
            Console.WriteLine("Train no:");
            int trainNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Class ID : ");
            int classID = int.Parse(Console.ReadLine());
            //Console.WriteLine("Date of Travel (yyyy-mm-dd) :");
            //DateTime travelDate = DateTime.Parse(Console.ReadLine());
            DateTime travelDate;

            while (true)
            {
                Console.WriteLine("Date of Travel (yyyy-MM-dd):");
                string input = Console.ReadLine();

                try
                {
                    // Parse using exact format
                    travelDate = DateTime.ParseExact(input, "yyyy-MM-dd", null);

                    if (travelDate.Date >= DateTime.Today)
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Date of travel cannot be in the past. Please enter a valid future date(i.e. from today onwards)");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                }
            }

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
                // Console.WriteLine("Booking Id : "+reader["Booking_id"]);
                Console.WriteLine("Tickets booked successfully");
            }
            reader.Close();
            con.Close();
        }

        static void CancelTickets(string name)
        {
            try
            {
               
                Console.WriteLine("\nEnter Cancellation Details");
                //Console.Write("Customer Name: ");
                //string user_name = Console.ReadLine();
                string user_name = name;
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

        public static void ViewMyBookings(string customerName)
        {
            
            SqlDataReader reader = null;

            try
            {
                
                con = new SqlConnection(connect);
                con.Open();

                // Step 1: Get Cust_Id from Users table
                string getCustIdQuery = "SELECT User_Id FROM Users WHERE User_Name = @UserName";
                cmd = new SqlCommand(getCustIdQuery, con);
                cmd.Parameters.AddWithValue("@UserName", customerName);
                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                int custId = Convert.ToInt32(result);

                // Step 2: Call stored procedure
                cmd = new SqlCommand("ViewMyBookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CustId", custId);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Booking ID: {reader["Booking_id"]}, Train No: {reader["Train_No"]}, Train Name: {reader["Train_Name"]}, " +
                                      $"Class: {reader["Class_Name"]}, Booking Date: {reader["Date_Of_Booking"]}, Travel Date: {reader["Date_Of_Travel"]}, " +
                                      $"Seats: {reader["Seats_booked"]}, Total Cost: {reader["Total_Cost"]}, Status: {reader["Status"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
                con.Close();
            }
        }




    }
}
