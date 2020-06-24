using System;
using System.Collections.Generic; // ~ import
using DeliveryApp.Models;
using System.Linq;
using System.Data.SqlClient; // ADO.NET
using DeliveryApp.Connection;

namespace DeliveryApp.Data
{
    public class ItensCompradosData : Connect
    {
        public List<ItensComprados> Read(int id_pedido)
        {
            Console.WriteLine(id_pedido);
            string sql = "SELECT * from Itens_Comprados inner join Produto on Itens_comprados.id_produto = Produto.id inner join Pedido on Pedido.id = Itens_Comprados.id_pedido where Itens_Comprados.id_pedido = @id_pedido";

            List<ItensComprados> lista = new List<ItensComprados>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id_pedido", id_pedido);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                ItensComprados itenscomprados = new ItensComprados();
                itenscomprados.Id = reader.GetInt32(0);  
                itenscomprados.Id_Pedido = id_pedido;
                itenscomprados.Pedido = new Pedido();
                itenscomprados.Pedido.Status_Pedido = reader.GetInt32(17);
                itenscomprados.Produto = new Produto();     
                itenscomprados.Produto.Nome = reader.GetString(6);
                itenscomprados.Produto.Descricao = reader.GetString(7);
                itenscomprados.Produto.Valor = reader.GetDouble(8);

                lista.Add(itenscomprados);
            }

            return lista;
        }

        public ItensComprados Read(Guid id)
        {
            string sql = "SELECT * from Itens_Comprados where id = @id";

            ItensComprados itenscomprados = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                itenscomprados = new ItensComprados();
                itenscomprados.Id = (int)reader["Id"];
                itenscomprados.Quantidade = (int)reader["Quantidade"];
                itenscomprados.Valor = (float)reader["Valor"];              
            }

            return itenscomprados;
        }

        public void Create(ItensComprados itenscomprados)
        {

            string sql = "INSERT INTO itens_comprados(quantidade, valor, id_produto, id_pedido) VALUES (@quantidade, @valor , @id_produto, @id_pedido)";
            
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@quantidade", itenscomprados.Quantidade);
            cmd.Parameters.AddWithValue("@valor", itenscomprados.Valor);
            cmd.Parameters.AddWithValue("@id_produto", itenscomprados.Id_Produto);
            cmd.Parameters.AddWithValue("@id_pedido", itenscomprados.Id_Pedido);
            cmd.ExecuteNonQuery();
        }

        public Double Soma(Pedido pedido) {
           string sql = "SELECT SUM(valor) AS valor from Itens_Comprados where id_pedido = @id";

            Double valor = 0;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                 valor = reader.GetDouble(0);              
            }

            return valor;
        
        }
    }
}