using System;
using DeliveryApp.Models;
using DeliveryApp.Connection;
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class ProdutoData : Connect
    {
        public Produto Read(Guid id){
            string sql = "SELECT * FROM Produto WHERE Id = @id";

            Produto produto = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                produto = new Produto();
                produto.Id = new Guid((string)reader["Id"]);
                produto.Nome = (string)reader["Nome"];
                produto.Descricao = (string)reader["Descricao"];
                produto.valor = (float)reader["Valor"];
                produto.Imagem = (byte[])reader["Imagem"];
                produto.EmpresaId = (int)reader["EmpresaId"];
            }

            return produto;
        }

        public void Create(Produto produto){
            string sql = "INSERT INTO Produto values (@id, @nome, @descricao, @valor, @imagem, @empresa_id";
            
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@valor", produto.valor);
            cmd.Parameters.AddWithValue("@imagem", produto.Imagem);
            cmd.Parameters.AddWithValue("@empresa_id", produto.EmpresaId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Guid id){
            string sql = "DELETE FROM Produto WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }


        public void Update(Produto produto){
            string sql = "UPDATE Produto SET Nome = @nome, Descricao = @descricao, Valor = @valor, Imagem = @imagem, EmpresaId = @empresa_id WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

           
            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@valor", produto.valor);
            cmd.Parameters.AddWithValue("@imagem", produto.Imagem);
            cmd.Parameters.AddWithValue("@empresa_id", produto.EmpresaId);

            cmd.ExecuteNonQuery(); 
        }

    
    }
}