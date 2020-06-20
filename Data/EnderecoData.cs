using System;
using DeliveryApp.Models;
using DeliveryApp.Connection;
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class EnderecoData : Connect
    {
        public Endereco Read(int id){
            string sql = "SELECT * FROM Endereco e inner join cliente c on e.id = c.id_endereco where e.id = @id";

            Endereco endereco = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                endereco = new Endereco();
                endereco.Id = (int)reader["Id"];
                endereco.Rua = (string)reader["Rua"];
                endereco.Numero = (int)reader["Numero"];
                endereco.Bairro = (string)reader["Bairro"];
                endereco.Complemento = (string)reader["Complemento"];
                endereco.Cep = (string)reader["Cep"];
                endereco.Cidade = (string)reader["Cidade"];
            }

            return endereco;
        }

        public Endereco Create(Endereco endereco){
            string sql = "INSERT INTO Endereco (rua, numero, bairro, complemento, cep, cidade) values (@rua, @numero, @bairro, @complemento, @cep, @cidade)";
           
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@rua", endereco.Rua);
            cmd.Parameters.AddWithValue("@numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            cmd.Parameters.AddWithValue("@cidade", endereco.Cidade);

            cmd.ExecuteNonQuery();

            sql = "SELECT TOP 1 * FROM Endereco ORDER BY id DESC";

            cmd  = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                endereco = new Endereco();
                endereco.Id = (int)reader["Id"];
            }

            return endereco;
        }

        public void Delete(int id){
            string sql = "DELETE FROM Endereco WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }


        public void Update(Endereco endereco){
            string sql = "UPDATE Endereco SET Rua = @rua, Numero = @numero, Bairro = @bairro, Complemento = @complemento, Cep = @cep, Cidade = @cidade WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

           
            cmd.Parameters.AddWithValue("@id", endereco.Id);
            cmd.Parameters.AddWithValue("@rua", endereco.Rua);
            cmd.Parameters.AddWithValue("@numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            cmd.Parameters.AddWithValue("@cidade", endereco.Cidade);

            cmd.ExecuteNonQuery(); 
        }

    }
}