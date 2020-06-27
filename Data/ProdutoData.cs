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
                produto.Id = reader.GetInt32(0);
                produto.Nome = reader.GetString(1);
                produto.Descricao = reader.GetString(2);
                produto.Valor = reader.GetDouble(3);
                produto.NomeImagem = reader.GetString(4);
            

                lista.Add(produto);
            }

            return lista;
        }

         public List<Produto> ReadCliente(int id){
            string sql = "SELECT * FROM Produto inner join Empresa  on Empresa.id = produto.id_empresa WHERE Produto.id_empresa = @id";

            List<Produto> lista = new List<Produto>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
        

            while(reader.Read())
            {
                Produto produto = new Produto();
                produto.Id = reader.GetInt32(0);
                produto.Nome = reader.GetString(1);
                produto.Descricao = reader.GetString(2);
                produto.Valor = reader.GetDouble(3);
                produto.Empresa = new Empresa();
                produto.Empresa.Nome = reader.GetString(6);
                produto.NomeImagem = reader.GetString(5);
                produto.EmpresaId = id;
        

                lista.Add(produto);
            }

            return lista;
        }




        public Produto Read(int id){
            string sql = "SELECT * FROM Produto WHERE Id = @id";

            Produto produto = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                produto = new Produto();
                produto.Id = (int)reader["Id"];
                produto.Nome = (string)reader["Nome"];
                produto.Descricao = (string)reader["Descricao"];
                produto.Valor = (Double)reader["Valor"];
                produto.NomeImagem = (string)reader["nome_imagem"];
                produto.EmpresaId = (int)reader["id_empresa"];
            }

            return produto;
        }

        public void Create(Produto produto){
            string sql = "INSERT INTO Produto (nome, descricao, valor, nome_imagem, id_empresa) values (@nome, @descricao, @valor, @nome_imagem, @id_empresa)";
            
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@valor", produto.Valor);
            cmd.Parameters.AddWithValue("@nome_imagem", produto.NomeImagem);
            cmd.Parameters.AddWithValue("@id_empresa", produto.EmpresaId);

            cmd.ExecuteNonQuery();
        }

        public void Update(Produto produto){
            string sql = "UPDATE Produto SET nome = @nome, descricao = @descricao, valor = @valor, nome_imagem = @imagem WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);
           
            cmd.Parameters.AddWithValue("@id", produto.Id);
            cmd.Parameters.AddWithValue("@nome", produto.Nome);
            cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@valor", produto.Valor);
            cmd.Parameters.AddWithValue("@imagem", produto.NomeImagem);

            cmd.ExecuteNonQuery(); 
        }

    
    }
}