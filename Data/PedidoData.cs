using System;
using System.Collections.Generic; 
using DeliveryApp.Models;
using System.Linq;
using System.Data.SqlClient; 
using DeliveryApp.Connection;

namespace DeliveryApp.Data
{
    public class PedidoData : Connect
    {
        public List<Pedido> Read(Pedido pedido)
        {
            string sql = "SELECT p.*,ic.valor, e.nome, ed.bairro,ed.rua, ed.cidade FROM pedido p left join Empresa e ON e.id = p.id_empresa left join endereco ed ON ed.id = p.id_endereco left join Itens_Comprados ic on ic.id_pedido = p.ID WHERE p.id_cliente = @id and p.status_pedido = @status_pedido";

            List<Pedido> lista = new List<Pedido>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id.ToString());
            cmd.Parameters.AddWithValue("@status_pedido", pedido.Status_Pedido.ToString());

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Pedido pedido = new Pedido();
                pedido.Id = new Guid(reader.GetString(0));
                pedido.Empresa.Nome = reader.GetString(1);
                pedido.Data_Pedido = reader.GetDateTime(2);
                pedido.Valor_Frete = reader.GetFloat(3);
                pedido.Endereco.Bairro = reader.GetString(4);
                pedido.Endereco.Rua = reader.GetString(5);
                pedido.Endereco.Cidade = reader.GetString(6);
                pedido.Tipo_Pagamento = reader.GetInt32(7);
                pedido.Valor_Troco = reader.GetInt32(8);
                pedido.status_Pedido = reader.GetInt32(9);

                string ic = "SELECT SUM(valor) where id_pedido = @id";

                SqlCommand cmdIc = new SqlCommand(ic, connection);
                cmdIc.Parameters.AddWithValue("@id", pedido.Id.ToString());

                SqlDataReader readerIc = cmd.ExecuteReader();

                pedido.Valor_Total = readerIc.GetFloat(1);

                lista.Add(pedido);
            }

            return lista;
        }

        public Pedido Read(Guid id)
        {
            string sql = "SELECT p.*,ic.valor, e.nome, ed.bairro,ed.rua, ed.cidade ,(SELECT SUM(Valor) FROM itens_comprados ic  "
          + "WHERE ic.id_pedido = @id ) AS Valor_Total" +
"FROM pedido p left join Empresa e ON e.id = p.id_empresa left join endereco ed ON ed.id = p.id_endereco left join Itens_Comprados ic on ic.id_pedido = p.ID WHERE p.id = @id";

            Pedido pedido = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                pedido = new Pedido();
                pedido.Id = new Guid((string)reader["Id"]);
                pedido.Data_Pedido = (DateTime)reader["DataPedido"];
                pedido.Empresa.Nome = (string)reader["Nome"];
                pedido.Valor_Frete = (float)reader["ValorFrete"];
                pedido.Valor_Total = (float)reader["ValorTotal"];
                pedido.Status_Pedido = (int)reader["StatusPedido"];
                pedido.Tipo_Pagamento = (int)reader["TipoPagamento"];
                pedido.Endereco.Bairro = (string)reader["Bairro"];
                pedido.Endereco.Rua = (string)reader["Rua"];
                pedido.Endereco.Cidade = (string)reader["Cidade"];
            }

            return pedido;
        }

        public void Create(Pedido pedido, Cliente cliente, Empresa empresa, Endereco endereco,ItensComprados itenscomprados)
        {

            string sql = "INSERT INTO Pedido VALUES (@id, @tipo_Pagamento, @data_Pedido, @valor_Frete, @valor_Total, @status_Pedido, @id_empresa, @id_cliente, @id_endereco)";
            
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id);
            cmd.Parameters.AddWithValue("@data_Pedido", pedido.Data_Pedido);
            cmd.Parameters.AddWithValue("@valor_Frete", pedido.Valor_Frete);
            cmd.Parameters.AddWithValue("@status_Pedido", pedido.Valor_Total);
            cmd.Parameters.AddWithValue("@tipo_Pagamento", pedido.Tipo_Pagamento);
            cmd.Parameters.AddWithValue("@id_empresa", empresa.Id);
            cmd.Parameters.AddWithValue("@id_cliente", cliente.Id);
            cmd.Parameters.AddWithValue("@id_endereco", endereco.Id);

            cmd.ExecuteNonQuery();

            ItensCompradosData itens_comprados = new ItensCompradosData();
          //  itens_comprados.Create(itenscomprados);
        }

        public void Delete(Guid id)
        {
            string sql = "DELETE FROM Pedido WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }

        public void Update(Pedido pedido)
        {
            string sql = "UPDATE Pedido SET status_pedido = @status_Pedido WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", pedido.Id);
            cmd.Parameters.AddWithValue("@status_Pedido", pedido.Status_Pedido);

            cmd.ExecuteNonQuery();
        }
    }
}