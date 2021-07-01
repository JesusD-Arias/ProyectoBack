using Proyecto.Connection;
using Proyecto.Documents.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Proyecto.Documents.Customers.DAO
{
    public class DAOCustomer
    {
        ConnectionBD oConexion = new ConnectionBD();
        public string RegisterCustomer(DTOCustomer oCustomer)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" INSERT INTO Customers( ");

                query.Append(" FullName, ");
                query.Append(" Address, ");
                query.Append(" Phone, ");
                query.Append(" Creation_date ");

                query.Append(" ) OUTPUT INSERTED.Id_customer VALUES ( ");

                query.Append(" @fullname, ");
                query.Append(" @address, ");
                query.Append(" @phone, ");
                query.Append(" @creation_date ");

                query.Append(" ) ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@fullname", oCustomer.FullName);
                DParametros.Add("@address", oCustomer.Address);
                DParametros.Add("@phone", oCustomer.Phone);
                DParametros.Add("@creation_date", DateTime.Now);

                var respReturn = oConexion.EjecutarReturn(query.ToString(), DParametros);
                return respReturn;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido registrar el cliente en el DAOCustomer, [{ex}]");
            }
        }
        public List<DTOCustomer> GetCustomerById(int Id_customer)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");

                query.Append(" Id_customer, ");
                query.Append(" FullName, ");
                query.Append(" Address, ");
                query.Append(" Phone, ");
                query.Append(" Creation_date ");

                query.Append(" FROM Customers ");
                query.Append(" WHERE Id_customer = @id_customer ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@id_customer", Id_customer);

                var resp = oConexion.ReadCustomer(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener el cliente en el DAOCustomer, [{ex}]");
            }
        }
        public List<DTOCustomer> GetAllCustomers()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");

                query.Append(" Id_customer, ");
                query.Append(" FullName, ");
                query.Append(" Address, ");
                query.Append(" Phone, ");
                query.Append(" Creation_date ");

                query.Append(" FROM Customers ORDER BY Id_customer desc");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                var resp = oConexion.ReadCustomer(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener el cliente en el DAOCustomer, [{ex}]");
            }
        }
        public int UpdateCustomer(DTOCustomer oCustomer)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" Update Customers SET ");

                query.Append(" FullName = @fullname, ");
                query.Append(" Address = @address, ");
                query.Append(" Phone = @phone ");

                query.Append(" WHERE Id_customer = @id_customer ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@fullname", oCustomer.FullName);
                DParametros.Add("@address", oCustomer.Address);
                DParametros.Add("@phone", oCustomer.Phone);
                DParametros.Add("@id_customer", oCustomer.Id_customer);

                var resp = oConexion.RunTask(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido actualizar el cliente en el DAOCustomer, [{ex}]");
            }
        }

        public int DeleteCustomerById(int Id_customer)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" DELETE FROM Customers ");
                query.Append(" WHERE Id_customer = @id_customer ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@id_customer", Id_customer);

                var resp = oConexion.RunTask(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el cliente en el DAOCustomer, [{ex}]");
            }
        }
    }
}