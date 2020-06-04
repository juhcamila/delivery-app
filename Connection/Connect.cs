using System;
using System.Data.SqlClient; // ADO.NET

namespace DeliveryApp.Connection
{
    public class Connect : IDisposable
    {
        private SqlConnection connection = null;

        public void Connection(){
            string strConn = @"Data Source=localhost;
              Initial Catalog=BdDelivery;
              User=sa;
              Passoword=A1b2c3d4e5!";

              connection = new SqlConnection(strConn);
              connection.Open();
        }

        public void Dispose(){
         connection.Close();
        }
    }
}