using System;
using System.Collections.Generic; // ~ import
using DeliveryApp.Models;
using System.Linq;
using System.Data.SqlClient; // ADO.NET
using DeliveryApp.Connection;

namespace DeliveryApp.Data
{
    public class PedidoData : Connect
    {
        public List<Pedido> Read(Cliente cliente, int status){
            string sql = "SELECT * FROM Pedido WHERE clienteId = @id and StatusPedido = @status";

            List<Pedido> lista = new List<Pedido>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", cliente.Id.ToString());
            cmd.Parameters.AddWithValue("@status", status);

            SqlDataReader reader = cmd.ExecuteReader();
        

            while(reader.Read())
            {
                Pedido pedido = new Pedido();
                pedido.Id = new Guid(reader.GetString(0));
                pedido.Empresa.Nome = reader.GetString(1);
                pedido.DataPedido = reader.GetDateTime(2);
                pedido.ValorFrete = reader.GetFloat(3);
                pedido.ValorTotal = reader.GetFloat(4);
                pedido.Endereco.Bairro = reader.GetString(5);
                pedido.Endereco.Rua = reader.GetString(6);
                pedido.Endereco.Cidade = reader.GetString(7);
                pedido.TipoPagamento = reader.GetInt32(8);

                lista.Add(pedido);
            }

            return lista;
        }

        public Pedido Read(Guid id){
            string sql = "SELECT * FROM Todo WHERE Id = @id";

            Pedido pedido = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                pedido = new Pedido();
                pedido.Id = new Guid((string)reader["Id"]);
                pedido.DataPedido = (DateTime)reader["DataPedido"];
                pedido.Empresa.Nome = (string)reader["Nome"];
                pedido.ValorFrete = (float)reader["ValorFrete"];
                pedido.ValorTotal = (float)reader["ValorTotal"];
                pedido.StatusPedido = (int)reader["StatusPedido"];
                pedido.TipoPagamento = (int)reader["TipoPagamento"];
                pedido.Endereco.Bairro = (string)reader["Bairro"];
                pedido.Endereco.Rua = (string)reader["Rua"];
                pedido.Endereco.Cidade = (string)reader["Cidade"];
            }

            return pedido;
        }

        public void Create(Pedido pedido, Cliente cliente, Empresa empresa, Endereco endereco) {
            string sql = "INSERT INTO Pedido VALUES (@id, @tipoPagamento, @dataPedido, @empresaId, @valorFrete, @valorTotal, @statusPedido, @clienteId, @enderecoId)";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id);
            cmd.Parameters.AddWithValue("@dataPedido", pedido.DataPedido);
            cmd.Parameters.AddWithValue("@valorFrete", pedido.ValorFrete);
            cmd.Parameters.AddWithValue("@valorTotal", pedido.ValorTotal);
            cmd.Parameters.AddWithValue("@statusPedido", pedido.ValorTotal);
            cmd.Parameters.AddWithValue("@tipoPagamento", pedido.TipoPagamento);
            cmd.Parameters.AddWithValue("@empresaId", empresa.Id);
            cmd.Parameters.AddWithValue("@clienteId", cliente.Id);
            cmd.Parameters.AddWithValue("@enderecoId", endereco.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Guid id) {
            string sql = "DELETE FROM Pedido WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }

        public void Update(Pedido pedido) {
            string sql = "UPDATE Pedido SET sStatusPedido = @statusPedido WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id);
            cmd.Parameters.AddWithValue("@statusPedido", pedido.ValorTotal);

            cmd.ExecuteNonQuery();
        }
    }
}