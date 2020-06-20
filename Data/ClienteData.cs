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
        public Cliente Read(int id)
        {
            string sql = "SELECT * FROM Cliente c where c.Id = @id";

            Cliente cliente = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente = new Cliente();
                cliente.Id = (int)reader["Id"];
                cliente.Nome = (string)reader["Nome"];
                cliente.Cpf = (string)reader["Cpf"];
                cliente.Celular = (string)reader["Celular"];
            }
            return cliente;
        }

        public void Create(Cliente cliente)
        {
            Console.WriteLine(cliente.Nome);

            string sql = "Insert Into Cliente(nome,cpf,celular) values (@nome,@cpf,@celular)";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
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
        public void UpdateAddress(string id_endereco,string id_cliente)
        {
            string sql = "Update Cliente Set id_endereco = @id_endereco where id_cliente = @id_cliente";

            SqlCommand cmd = new SqlCommand(sql,connection);

            cmd.Parameters.AddWithValue("id_endereco", id_endereco);
            cmd.Parameters.AddWithValue("id_cliente", id_cliente);
        }
    }
}