using System;
using System.Collections.Generic; // ~ import
using DeliveryApp.Models;
using DeliveryApp.Connection;
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class ProdutoData : Connect
    {
        public List<Produto> Read(Empresa empresa){
            string sql = "SELECT * FROM Produto WHERE id_empresa = @id";

            List<Produto> lista = new List<Produto>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", empresa.Id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();
        

            while(reader.Read())
            {
                Produto produto = new Produto();
                produto.Id = new Guid(reader.GetString(0));
                produto.Nome = reader.GetString(1);
                produto.Descricao = reader.GetString(2);
                produto.Valor = reader.GetFloat(3);
            

                lista.Add(produto);
            }

            return lista;
        }
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
                produto.Valor = (float)reader["Valor"];
                produto.Imagem = (byte[])reader["Imagem"];
                produto.EmpresaId = (int)reader["EmpresaId"];
            }

            return produto;
        }

        public void Create(Produto produto, Empresa empresa){
            string sql = "INSERT INTO Produto values (@id, @nome, @descricao, @valor, @imagem, @id_empresa";
            
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@valor", produto.Valor);
            cmd.Parameters.AddWithValue("@imagem", produto.Imagem);
            cmd.Parameters.AddWithValue("@id_empresa", empresa.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Guid id){
            string sql = "DELETE FROM Produto WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }


        public void Update(Produto produto){
            string sql = "UPDATE Produto SET Nome = @nome, Descricao = @descricao, Valor = @valor, Imagem = @imagem, id_empresa = @id_empresa WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

           
            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@valor", produto.Valor);
            cmd.Parameters.AddWithValue("@imagem", produto.Imagem);
            cmd.Parameters.AddWithValue("@id_empresa", produto.EmpresaId);

            cmd.ExecuteNonQuery(); 
        }

    
    }
}