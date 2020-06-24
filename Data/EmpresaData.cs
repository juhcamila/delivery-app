using System;
using DeliveryApp.Models;
using DeliveryApp.Connection;
using System.Collections.Generic; 
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class EmpresaData : Connect
    {   
        public List<Empresa> Read(){
            string sql = "SELECT * FROM Empresa";

            List<Empresa> lista = new List<Empresa>();

            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();
        

            while(reader.Read())
            {
                Empresa empresa = new Empresa();
                empresa.Id = reader.GetInt32(0);
                empresa.Nome = reader.GetString(1);
                empresa.Telefone = reader.GetString(2);
                empresa.Endereco.Bairro = reader.GetString(3);
                empresa.Endereco.Rua = reader.GetString(4);
                empresa.Endereco.Cidade = reader.GetString(5);
                empresa.Endereco.Cep = reader.GetString(6);
            

                lista.Add(empresa);
            }

            return lista;
        }

        public Empresa GetEmpresa(string email)
        {
            string sql = "SELECT * FROM Empresa INNER JOIN Usuario ON Usuario.email = @email and Usuario.id = Empresa.id_usuario";
        
            Empresa empresa = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                empresa = new Empresa();
                empresa.Id = (int)reader["Id"];
                empresa.Nome = (string)reader["Nome"];
                empresa.Cnpj = (string)reader["Cnpj"];
                empresa.Telefone = (string)reader["Telefone"];
                empresa.EnderecoId = (int)reader["id_endereco"];
            }

            return empresa;
        }

        public Empresa Read(int id){
            string sql = "SELECT * FROM Empresa WHERE id = @id";

            Empresa empresa = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                empresa = new Empresa();
                empresa.Id = (int)reader["Id"];
                empresa.Nome = (string)reader["Nome"];
                empresa.Cnpj = (string)reader["Cnpj"];
                empresa.Telefone = (string)reader["Telefone"];
                empresa.Endereco.Bairro = (string)reader["Bairro"];
                empresa.Endereco.Rua = (string)reader["Rua"];
                empresa.Endereco.Cidade = (string)reader["Cidade"];
                empresa.Endereco.Cep = (string)reader["Cep"];
            }

            return empresa;
        }

        public void Create(Empresa empresa){

            string sql = "INSERT INTO Empresa (nome, cnpj, telefone, id_endereco, id_usuario) values (@nome, @cnpj, @telefone, @endereco_id, @usuario_id)";
            
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nome", empresa.Nome);
            cmd.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
            cmd.Parameters.AddWithValue("@telefone", empresa.Telefone);
            cmd.Parameters.AddWithValue("@endereco_id", empresa.Endereco.Id);
            cmd.Parameters.AddWithValue("@usuario_id", empresa.Usuario.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id){
            string sql = "DELETE FROM Empresa WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            cmd.ExecuteNonQuery();
        }


        public void Update(Empresa empresa){
            string sql = "UPDATE Empresa SET nome = @nome, cnpj = @cnpj, telefone = @telefone WHERE id = @id";
                Console.WriteLine(empresa.Id);
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", empresa.Id);
            cmd.Parameters.AddWithValue("@nome", empresa.Nome);
            cmd.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
            cmd.Parameters.AddWithValue("@telefone", empresa.Telefone);
        
            cmd.ExecuteNonQuery(); 
        }
        
    }
}