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
        public List<ItensComprados> Read(Pedido pedido)
        {
            string sql = "SELECT * FROM ItensComprados where id_pedido = @id_pedido";

            List<ItensComprados> lista = new List<ItensComprados>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                ItensComprados itenscomprados = new ItensComprados();
                itenscomprados.Id = new Guid(reader.GetString(0));       
                itenscomprados.Quantidade = reader.GetInt32(1);
                itenscomprados.Valor = reader.GetFloat(2);

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
                itenscomprados.Id = new Guid((string)reader["Id"]);
                itenscomprados.Quantidade = (int)reader["Quantidade"];
                itenscomprados.Valor = (float)reader["Valor"];              
            }

            return itenscomprados;
        }

        public void Create(ItensComprados itenscomprados,Pedido pedido,Produto produto)
        {

            string sql = "INSERT INTO itens_comprados VALUES (@id,@quantidade,@valor,@id_produto,@id_pedido)";
            
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", itenscomprados.Id);
            cmd.Parameters.AddWithValue("@quantidade", itenscomprados.Quantidade);
            cmd.Parameters.AddWithValue("@valor", itenscomprados.Valor);
            cmd.Parameters.AddWithValue("@id_produto", produto.Id);
            cmd.Parameters.AddWithValue("@id_pedido", pedido.Id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(Guid id)
        {
            string sql = "DELETE FROM Itens_comprados WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }
    }
}