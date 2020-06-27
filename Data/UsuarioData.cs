using System;
using DeliveryApp.Models;
using DeliveryApp.Connection;
using System.Data.SqlClient;

namespace DeliveryApp.Data
{
    public class UsuarioData : Connect
    {
        public UsuarioData()
        {
        
        }


        public Usuario Read(int id){
            string sql = "SELECT * FROM Usuario WHERE id = @id";

            Usuario usuario = null;

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                usuario = new Usuario();
                usuario.Id = (int)reader["Id"];
                usuario.Email = (string)reader["Email"];
                usuario.Senha = (string)reader["Senha"];
                usuario.Tipo = (int)reader["Tipo"];
            }

            return usuario;
        }

        public Usuario Create(Usuario usuario){
            string sql = "INSERT INTO Usuario (email, senha, tipo) values (@email, @senha, @tipo)";
            
            SqlCommand cmd  = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);

            cmd.ExecuteNonQuery();

            sql = "SELECT TOP 1 * FROM Usuario ORDER BY id DESC";

            cmd  = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                usuario = new Usuario();
                usuario.Id = (int)reader["Id"];
            }

            return usuario;
        }

        public Boolean Logar(Usuario usuario) {
            string sql = "SELECT * FROM Usuario WHERE email = @email and senha = @senha and tipo = @tipo";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int id){
            string sql = "DELETE FROM Usuario WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }


        public void Update(Usuario usuario){
            string sql = "UPDATE Usuario SET email = @email, senha = @senha WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, connection);

           
            cmd.Parameters.AddWithValue("@id", usuario.Id);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
        
            cmd.ExecuteNonQuery(); 
        }
        
    }
}