using Proyecto.Documents.Contacts.DTO;
using Proyecto.Documents.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto.Connection
{
    public class ConnectionBD
    {
        string cadena = "Data source =MTLP57707\\SQLEXPRESS; Initial catalog=Proyecto; Integrated security=True";

        public SqlConnection conectar = new SqlConnection();

        public ConnectionBD()
        {
            conectar.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectar.Open();
                Console.WriteLine("Conexion establecida");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar conectarse a la Base de Datos " + ex.Message);
            }
        }

        public void cerrar()
        {
            conectar.Close();
        }

        public string EjecutarReturn(string query, Dictionary<string, object> lParametros)
        {
            try
            {
                abrir();

                SqlCommand comando = new SqlCommand(query, conectar);
                foreach (var parametro in lParametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }
                var resp = comando.ExecuteScalar().ToString();

                cerrar();

                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int RunTask(string query, Dictionary<string, object> lParametros)
        {
            try
            {
                abrir();
                SqlCommand comando = new SqlCommand(query, conectar);
                foreach (var parametro in lParametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }
                var resp = comando.ExecuteNonQuery();
                cerrar();
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex}");
            }
        }

        public List<DTOCustomer> ReadCustomer(string query, Dictionary<string, object> lParametros)
        {
            try
            {
                abrir();
                SqlCommand comando = new SqlCommand(query, conectar);
                foreach (var parametro in lParametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }
                List<DTOCustomer> results = new List<DTOCustomer>();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DTOCustomer newItem = new DTOCustomer();
                        newItem.Id_customer = dr.GetInt32(0);
                        newItem.FullName = dr.GetString(1);
                        newItem.Address = dr.GetString(2);
                        newItem.Phone = dr.GetString(3);
                        newItem.CreationDate = dr.GetDateTime(4);
                        results.Add(newItem);
                    }
                }
                cerrar();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DTOContact> ReadContact(string query, Dictionary<string, object> lParametros)
        {
            try
            {
                abrir();
                SqlCommand comando = new SqlCommand(query, conectar);
                foreach (var parametro in lParametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }
                List<DTOContact> results = new List<DTOContact>();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DTOContact newItem = new DTOContact();
                        newItem.Id_contact = dr.GetInt32(0);
                        newItem.FullName_contact = dr.GetString(1);
                        newItem.Address_contact = dr.GetString(2);
                        newItem.Phone_contact = dr.GetString(3);
                        newItem.Id_customer = dr.GetInt32(4);
                        results.Add(newItem);
                    }
                }
                cerrar();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}