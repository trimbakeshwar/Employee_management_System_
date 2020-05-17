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
        //step 3 : configration for database: install pakage: using Microsoft.Extensions.Configuration;
        private readonly IConfiguration configuration;
        //step 4 : install pkg System.Data.SqlClient;
        private SqlConnection con = null;
        string constr = null;
        
        public EmployeeRepositoryLayer(IConfiguration configuratio)
        {
            configuration = configuratio;
        }
        //step 5 : connection
        private void Connection()
        {
            try
            {// step 6 : call the connection string
                constr = configuration.GetSection("ConnectionStrings").GetSection("EmployeeContext").Value;
                con = new SqlConnection(constr);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        public dynamic userLogin(EmployeeModle data)
        {
            Connection();
            SqlCommand command = new SqlCommand("spUserLogin", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userName", data.userName);
            command.Parameters.AddWithValue("@passWord", data.passWord);
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
                
                return "welcome";
            }

        }
        public string Add_Data(EmployeeModle data)
        {
        //step 7 : connect to stored procedure and add in column
        Connection();
            SqlCommand command = new SqlCommand("spUserRegistration", con);
            command.CommandType = CommandType.StoredProcedure;
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
            //this qury return 1 after succesfuly run 0 for fail
            int i =  command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "insertion successful ";
            }
            else
            {
                return "insertion fail";
            }

        }
        public string Delete(EmployeeModle id)
        {
            Connection();
            SqlCommand command = new SqlCommand("spUserDeleteRegistration", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userId",id.userId);
            //open connection EmployeeTable
            con.Open();
            //this qury return 1 after succesfuly run 0 for fail
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return  "delete fail";
            }
            else
            {
                return "delete successful";
            }

        }
        public string Update(EmployeeModle Data)
        {
            Connection();
            SqlCommand command = new SqlCommand("spUserUpdateRegistration", con);
             command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Qualification", Data.Qualification);
            command.Parameters.AddWithValue("@payment", Data.payment);            
            command.Parameters.AddWithValue("@Email", Data.Email);
             command.Parameters.AddWithValue("@userName", Data.userName);
             command.Parameters.AddWithValue("@passWord", Data.passWord);
            command.Parameters.AddWithValue("@userId", Data.userId);
            //open connection EmployeeTable
            con.Open();
            //this qury return 1 after succesfuly run 0 for fail
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "update fail";
            }
            else
            {
                return  "update successful";
            }

        }
        public dynamic GetAllEmployeeDetail()
        {
            Connection();
            SqlCommand command = new SqlCommand("AllEmployeeDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            return GetData(command);
        }
        public dynamic GetEmployeeDetail(EmployeeModle uid)
        {
            Connection();
            SqlCommand command = new SqlCommand("EmployeeDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("userId", uid.userId);
            return GetData(command);

        }
        public dynamic GetData(SqlCommand command)
        {
           // command.CommandType = CommandType.StoredProcedure;
            List<EmployeeModle> list = new List<EmployeeModle>();
            //open connection EmployeeTable
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var EmployeeModle = new EmployeeModle
                {
                    firstName = reader.GetString(reader.GetOrdinal("firstName")),
                    lastName = reader.GetString(reader.GetOrdinal("lastName")),
                    Qualification = reader.GetString(reader.GetOrdinal("Qualification")),
                    payment = reader.GetDecimal(reader.GetOrdinal("payment")),
                    userId = reader.GetInt32(reader.GetOrdinal("userId")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    userName = reader.GetString(reader.GetOrdinal("userName")),
                    passWord = reader.GetString(reader.GetOrdinal("passWord"))
                };
                list.Add(EmployeeModle);
            }
            con.Close();
            return list;
        }

        
    }
}
