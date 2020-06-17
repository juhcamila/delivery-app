using System;
using System.Collections.Generic;
using DeliveryApp.Models;
using System.Linq;
using System.Data.SqlClient;
using DeliveryApp.Connection;

namespace DeliveryApp.Data
{
    public class ClienteData : Connect
    {
        public Cliente Read(Guid id)
        {
            string sql = "SELECT * FROM Cliente Where Id = @id";

            Cliente cliente = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente = new Cliente();
                cliente.Id = new Guid((string)reader["Id"]);
                cliente.Nome = (string)reader["Nome"];
                cliente.Cpf = (string)reader["Cpf"];
                cliente.Celular = (string)reader["Celular"];
            }
            return cliente;
        }

        public void Create(Cliente cliente,Endereco endereco)
        {
            string sql = "Insert Into Cliente values (@id,@nome,@cpf,@celular,@id_endereco)";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@id_endereco", endereco.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Guid id)
        {
            string sql = "Delete From Cliente Where Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Id", id.ToString());
            cmd.ExecuteNonQuery();
        }

        public void Update(Cliente cliente)
        {
            string sql = "Update Cliente Set Nome = @nome, Cpf = @Cpf, Celular = @Celular Where Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@Celular", cliente.Celular);

            cmd.ExecuteNonQuery();                 
        }
    }
}