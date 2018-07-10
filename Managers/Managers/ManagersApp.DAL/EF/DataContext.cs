using ManagersApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersApp.DAL.EF
{
    public class DataContext : DbContext
    {

       public DbSet<Client> Clients { get; set; }
       public DbSet<Goods> Goodses { get; set; }
       public DbSet<Manager> Managers { get; set; }
       public DbSet<Sale> Sales { get; set; }

        static DataContext()
        {
            String str;
            SqlConnection myConn = new SqlConnection(ConfigurationManager.AppSettings.Get("createDataBaseConnectionString"));
            SqlCommand myCommand;
            myCommand = new SqlCommand("SELECT database_id FROM sys.databases WHERE Name= 'NewDatabase';", myConn);

            myConn.Open();
            object result = myCommand.ExecuteScalar();
            myConn.Close();

            if (result == null)
            {
                str = "CREATE DATABASE NewDatabase;";
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
                myCommand = new SqlCommand(str, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }


                myConn = new SqlConnection(ConfigurationManager.AppSettings.Get("DataBaseConnectionString"));

                str = @"CREATE TABLE Clients (
                    [id] int ,
                    [name] char(100) );";

                myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.ExecuteNonQuery();

               str = @"CREATE TABLE Goodses (
                    [id] int ,
                    [name] char(100) );";
                myCommand = new SqlCommand(str, myConn);
                myCommand.ExecuteNonQuery();

                str = @"CREATE TABLE Managers (
                    [id] int ,
                    [name] char(100) );";
                myCommand = new SqlCommand(str, myConn);
                myCommand.ExecuteNonQuery();

                str = @"CREATE TABLE Sales (
                    [id] int ,
                    [clientId] int  ,
                    [managerId] int ,
                    [goodsId] int ,
                    [date] date,
                    [summ] int );";
                myCommand = new SqlCommand(str, myConn);
                myCommand.ExecuteNonQuery();
               
                //myConn.Close();
            }
        }

        public DataContext()
            : base()
        {
         
        }

       
    }
     
    
}

