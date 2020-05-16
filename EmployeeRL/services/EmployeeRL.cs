using EmployeeCommonLayer;
using EmployeeRL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
        public string Return_Data(EmployeeModle data)
        {
            //step 7 : connect to stored procedure and add in column
            Connection();
            SqlCommand command = new SqlCommand("spAddNewEmpRegistration", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstName", data.firstName);
            command.Parameters.AddWithValue("@lastName", data.lastName);
            command.Parameters.AddWithValue("@userName", data.userName);
            command.Parameters.AddWithValue("@passWord", data.passWord);
            //open connection
            con.Open();
            //this qury return 1 after succesfuly run 0 for fail
            int i =  command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
