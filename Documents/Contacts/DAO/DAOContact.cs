using Proyecto.Connection;
using Proyecto.Documents.Contacts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Proyecto.Documents.Contacts.DAO
{
    public class DAOContact
    {
        ConnectionBD oConexion = new ConnectionBD();
        public int RegisterContact(DTOContact oContact)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" INSERT INTO Contacts( ");

                query.Append(" FullName, ");
                query.Append(" Address, ");
                query.Append(" Phone, ");
                query.Append(" Id_customer ");

                query.Append(" ) VALUES ( ");

                query.Append(" @fullname, ");
                query.Append(" @address, ");
                query.Append(" @phone, ");
                query.Append(" @id_customer ");

                query.Append(" ) ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@fullname", oContact.FullName_contact);
                DParametros.Add("@address", oContact.Address_contact);
                DParametros.Add("@phone", oContact.Phone_contact);
                DParametros.Add("@id_customer", oContact.Id_customer);

                var respReturn = oConexion.RunTask(query.ToString(), DParametros);
                return respReturn;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido registrar el contacto en el DAOContact, [{ex}]");
            }
        }

        public List<DTOContact> GetContactsByIdCustomer(int Id_customer)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");

                query.Append(" Id_contact, ");
                query.Append(" FullName, ");
                query.Append(" Address, ");
                query.Append(" Phone, ");
                query.Append(" Id_customer ");

                query.Append(" FROM Contacts ");
                query.Append(" WHERE Id_customer = @id_customer ");
                query.Append(" ORDER BY Id_contact DESC");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@id_customer", Id_customer);

                var resp = oConexion.ReadContact(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener el contacto en el DAOContact, [{ex}]");
            }
        }

        public List<DTOContact> GetAllContacts()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");

                query.Append(" Id_contact, ");
                query.Append(" FullName, ");
                query.Append(" Address, ");
                query.Append(" Phone, ");
                query.Append(" Id_customer ");

                query.Append(" FROM Contacts ORDER BY Id_contact desc");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                var resp = oConexion.ReadContact(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener el contacto en el DAOContact, [{ex}]");
            }
        }

        public int UpdateContact(DTOContact oContact)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" Update Contacts SET ");

                query.Append(" FullName = @fullname, ");
                query.Append(" Address = @address, ");
                query.Append(" Phone = @phone ");

                query.Append(" WHERE Id_contact = @id_contact ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@fullname", oContact.FullName_contact);
                DParametros.Add("@address", oContact.Address_contact);
                DParametros.Add("@phone", oContact.Phone_contact);
                DParametros.Add("@id_contact", oContact.Id_contact);

                var resp = oConexion.RunTask(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido actualizar el contacto en el DAOContact, [{ex}]");
            }
        }

        public int DeleteContactById(int Id_contact)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" DELETE FROM Contacts ");
                query.Append(" WHERE Id_contact = @id_contact ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@id_contact", Id_contact);

                var resp = oConexion.RunTask(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el contacto en el DAOContact, [{ex}]");
            }
        }

        public int DeleteContactByIdCustomer(int Id_customer)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" DELETE FROM Contacts ");
                query.Append(" WHERE Id_customer = @id_customer ");

                Dictionary<string, object> DParametros = new Dictionary<string, object>();
                DParametros.Add("@id_customer", Id_customer);

                var resp = oConexion.RunTask(query.ToString(), DParametros);
                return resp;

            }
            catch (Exception ex)
            {
                throw new Exception($"No se han podido eliminar los contactos en el DAOContact, [{ex}]");
            }
        }
    }
}