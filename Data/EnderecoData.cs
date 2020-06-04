using System;
using System.Collections.Generic; // ~ import
using DeliveryApp.Models;
using System.Linq;
using DeliveryApp.Connection;
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class EnderecoData
    {
        private Connect connect = new Connect();

        public Endereco Read(Guid id){
            string sql = "SELECT * FROM Endereco WHERE Id = @id";

            Endereco endereco = null;

            SqlCommand cmd = new SqlCommand(sql, connect.Connection());
        }
    }
}