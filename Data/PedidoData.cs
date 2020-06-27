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
        public List<Pedido> Read(Empresa empresa)
        {
            string sql = "SELECT distinct p.*,  c.nome, ed.bairro, ed.rua, ed.cidade, ed.numero FROM pedido p inner join Cliente c ON c.id = p.id_cliente left join endereco ed ON ed.id = p.id_endereco WHERE p.id_empresa = @id";

            List<Pedido> lista = new List<Pedido>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", empresa.Id);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Pedido pedido = new Pedido();
                pedido.Id = reader.GetInt32(0);
                pedido.Cliente = new Cliente();
                pedido.Cliente.Nome = reader.GetString(9);
                //pedido.Data_Pedido = reader.GetDateTime(2);
                pedido.Endereco = new Endereco();
                pedido.Endereco.Bairro = reader.GetString(10);
                pedido.Endereco.Rua = reader.GetString(11);
                pedido.Endereco.Cidade = reader.GetString(12);
                pedido.Endereco.Numero = reader.GetInt32(13);
                //pedido.Tipo_Pagamento = reader.GetInt32(7);
                pedido.Valor_Troco = reader.GetInt32(2);
                pedido.Status_Pedido = reader.GetInt32(6);

                using(ItensCompradosData data = new ItensCompradosData())
                    pedido.Valor_Total = data.Soma(pedido);

                lista.Add(pedido);
            }

            return lista;
        }
        public Pedido Read(int id)
        {
            string sql = "SELECT p.*,ic.valor, e.nome, ed.bairro,ed.rua, ed.cidade ,(SELECT SUM(Valor) FROM itens_comprados ic  "
          + "WHERE ic.id_pedido = @id ) AS Valor_Total" +
"FROM pedido p left join Empresa e ON e.id = p.id_empresa left join endereco ed ON ed.id = p.id_endereco left join Itens_Comprados ic on ic.id_pedido = p.ID WHERE p.id = @id";

            Pedido pedido = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                pedido = new Pedido();
                pedido.Id = (int)reader["Id"];
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

        public Pedido Create(Pedido pedido)
        {

            string sql = "INSERT INTO Pedido (tipo_Pagamento, data_Pedido, valor_Frete, status_Pedido, id_empresa, id_cliente, id_endereco) VALUES ( @tipo_Pagamento, @data_Pedido, @valor_Frete, 0, @id_empresa, @id_cliente, @id_endereco)";
            
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@data_Pedido", pedido.Data_Pedido);
            cmd.Parameters.AddWithValue("@valor_Frete", pedido.Valor_Frete);
            cmd.Parameters.AddWithValue("@tipo_Pagamento", pedido.Tipo_Pagamento);
            cmd.Parameters.AddWithValue("@id_empresa", pedido.Id_Empresa);
            cmd.Parameters.AddWithValue("@id_cliente", pedido.Id_Cliente);
            cmd.Parameters.AddWithValue("@id_endereco", pedido.Id_Endereco);
            //cmd.Parameters.AddWithValue("@valor_total", pedido.itenscomprados.Valor);

            cmd.ExecuteNonQuery();

            sql = "SELECT TOP 1 * FROM Pedido ORDER BY id DESC";

            cmd  = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                pedido = new Pedido();
                pedido.Id = (int)reader["Id"];
            }

            return pedido;

        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Pedido WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }

        public void Update(int id, int status)
        {
            string sql = "UPDATE Pedido SET status_pedido = @status_Pedido WHERE Id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@status_Pedido", status);

            cmd.ExecuteNonQuery();
        }
    }
}