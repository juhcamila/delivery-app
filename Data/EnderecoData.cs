using System;
using DeliveryApp.Models;
using DeliveryApp.Connection;
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class EnderecoData : Connect
    {
        public Endereco Read(Guid id,Guid id_cliente){
            string sql = "SELECT * FROM Endereco e inner join cliente c on e.id = c.id_endereco where e.id = @id and c.id_cliente = @id_cliente";

            Endereco endereco = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());
             cmd.Parameters.AddWithValue("@id_cliente", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                endereco = new Endereco();
                endereco.Id = new Guid((string)reader["Id"]);
                endereco.Rua = (string)reader["Rua"];
                endereco.Numero = (int)reader["Numero"];
                endereco.Bairro = (string)reader["Bairro"];
                endereco.Complemento = (string)reader["Complemento"];
                endereco.Cep = (string)reader["Cep"];
                endereco.Cidade = (string)reader["Cidade"];
            }

            return endereco;
        }

        public void Create(Endereco endereco){
            string sql = "INSERT INTO Endereco values (@id, @rua, @numero, @bairro, @complemento, @cpf, @Cidade";
            
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", endereco.Id);
            cmd.Parameters.AddWithValue("@rua", endereco.Rua);
            cmd.Parameters.AddWithValue("@numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            cmd.Parameters.AddWithValue("@cidade", endereco.Cidade);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Guid id){
            string sql = "DELETE FROM Endereco WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

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