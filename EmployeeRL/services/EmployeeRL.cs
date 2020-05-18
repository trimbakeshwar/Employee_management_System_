using EmployeeCommonLayer;
using EmployeeRL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRL.services
{
    public class EmployeeRepositoryLayer : InterfaceEmployeeRL
    {
        private readonly IConfiguration configuration;    
        private SqlConnection con = null;
        string constr = null;    
        public EmployeeRepositoryLayer(IConfiguration configuratio)
        {
            configuration = configuratio;
        }
        /// <summary>
        /// establish connection
        /// </summary>
        private void Connection()
        {
            try
            {
                //call the connection string
                constr = configuration.GetSection("ConnectionStrings").GetSection("EmployeeContext").Value;
                con = new SqlConnection(constr);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        /// <summary>
        /// if user name and password same then welcome massage send
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public dynamic userLogin(EmployeeModle data)
        {
            try
            {
                //establish connection
                Connection();
                //create a object of store procedure
                SqlCommand command = new SqlCommand("spUserLogin", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store prrocedure
                command.Parameters.AddWithValue("@userName", data.userName);
                command.Parameters.AddWithValue("@passWord", data.passWord);
                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                int i = command.ExecuteNonQuery();
                //close connection
                con.Close();
                if (i >= 1)
                {
                    return "delete fail";
                }
                else
                {

                    return "welcome";
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// add data in database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Add_Data(EmployeeModle data)
        {
            try
            {
                //get connection
                Connection();
                //create instance of store procedure
                SqlCommand command = new SqlCommand("spUserRegistration", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to stored procedure
                command.Parameters.AddWithValue("@firstName", data.firstName);
                command.Parameters.AddWithValue("@lastName", data.lastName);
                command.Parameters.AddWithValue("@Qualification", data.Qualification);
                command.Parameters.AddWithValue("@payment", data.payment);
                //command.Parameters.AddWithValue("@userId", data.userId);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@userName", data.userName);
                command.Parameters.AddWithValue("@passWord", data.passWord);
                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                { return "insertion successful "; }
                else
                { return "Email and userName alredy present"; }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// delete employee acording to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(EmployeeModle id)
        {
            try
            {
                Connection();
                //creat instance of store procedure
                SqlCommand command = new SqlCommand("spUserDeleteRegistration", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store procedure
                command.Parameters.AddWithValue("@userId", id.userId);
                //open connection EmployeeTable
                con.Open();
                //this qury return 1 after succesfuly run 0 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "delete fail";
                }
                else
                {
                    return "delete successful";
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// update employee detail
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string Update(EmployeeModle Data)
        {
            try
            {
                Connection();
                //creat instance of store procedure
                SqlCommand command = new SqlCommand("spUserUpdateRegistration", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store procedure
                command.Parameters.AddWithValue("@Qualification", Data.Qualification);
                command.Parameters.AddWithValue("@payment", Data.payment);
                command.Parameters.AddWithValue("@Email", Data.Email);
                command.Parameters.AddWithValue("@userName", Data.userName);
                command.Parameters.AddWithValue("@passWord", Data.passWord);
                command.Parameters.AddWithValue("@userId", Data.userId);
                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "update fail";
                }
                else
                {
                    return "update successful";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// get all employee
        /// </summary>
        /// <returns>list of employee</returns>
        public dynamic GetAllEmployeeDetail()
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("AllEmployeeDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            //call get data method
            return GetData(command);
        }
        public dynamic GetEmployeeDetail(EmployeeModle uid)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("EmployeeDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            //send parameter to store procedure
            command.Parameters.AddWithValue("userId", uid.userId);
            //call get method
            return GetData(command);

        }
        public dynamic GetData(SqlCommand command)
        {
           // command.CommandType = CommandType.StoredProcedure;
            List<EmployeeModle> list = new List<EmployeeModle>();
            //open connection EmployeeTable
            con.Open();
            //data from databse return in reder
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var EmployeeModle = new EmployeeModle
                {
                    //get oridinal is return the name of column on the basis of case insensative
                    //getstring retun the data in sting or particular type 
                    firstName = reader.GetString(reader.GetOrdinal("firstName")),
                    lastName = reader.GetString(reader.GetOrdinal("lastName")),
                    Qualification = reader.GetString(reader.GetOrdinal("Qualification")),
                    payment = reader.GetDecimal(reader.GetOrdinal("payment")),
                    userId = reader.GetInt32(reader.GetOrdinal("userId")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    userName = reader.GetString(reader.GetOrdinal("userName")),
                  
                };
                list.Add(EmployeeModle);
            }
            con.Close();
            return list;
        }

        
    }
}
