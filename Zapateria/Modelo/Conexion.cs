using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Zapateria.Controller;

namespace Zapateria.Modelo
{
    public class Conexion
    {
        private static String dataConnection;
        private static SqlConnection conn;
        private static String querySelect;
        private static String queryInsert;
        private static String queryUpdate;

        public Conexion()
        {
            dataConnection = "user id=jhon.chaparro; password=risemuse123456; " +
                             "server=QUANTICS-ING2\\SQLEXPRESS; Trusted_Connection=yes;" +
                             "database=Fidelizacion; connection timeout=25";
            conn = new SqlConnection(dataConnection);
            querySelect = "SELECT * FROM Cliente";
            queryInsert = "INSERT INTO Cliente(IdCliente, Nombre, Apellido, Telefono, Email) "
                            +"VALUES (@idCliente, @nombre, @apellido, @telefono, @email)";
            queryUpdate = "UPDATE Cliente SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono, Email = @email "
                            + "WHERE IdCliente = @idCliente";
        }

        public List<Cliente> getClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {                
                conn.Open();
                SqlCommand cmd = new SqlCommand(querySelect, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    clientes.Add(
                        new Cliente
                        {
                            idCliente = rd[0].ToString(),
                            nombre = rd[1].ToString(),
                            apellido = rd[2].ToString(),
                            telefono = rd[3].ToString(),
                            email = rd[4].ToString(),
                        }
                    );
                }
                rd.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
                return null;
            }
            return clientes;
        }

        public String insertCliente(string idCliente, string nombre, string apellido, string telefono, string email)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(queryInsert, conn);
                //using (cmd)
                //{

                //}
                //cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return ":D";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conn.Close();
            }
            //return "";
        }

        public String updateCliente(string idCliente, string nombre, string apellido, string telefono, string email)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(queryUpdate, conn);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("apellido", apellido);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                
                cmd.Dispose();
                return ":M0";
            } catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}