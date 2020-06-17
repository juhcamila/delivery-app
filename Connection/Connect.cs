using System;
using System.Data.SqlClient; // ADO.NET

namespace DeliveryApp.Connection
{
    public abstract class Connect : IDisposable
    {
        public SqlConnection connection;

        public Connect(){
            string strConn = @"Data Source=localhost;
              Initial Catalog=BDDelivery_Food;
              User=sa;
              Password=A1b2c3d4e5!";

              connection = new SqlConnection(strConn);
              connection.Open();
        }

        public void Dispose(){
         connection.Close();
        }
    }
}