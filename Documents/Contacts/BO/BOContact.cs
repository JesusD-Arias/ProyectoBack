using Proyecto.Documents.Contacts.DAO;
using Proyecto.Documents.Contacts.DTO;
using Proyecto.Documents.Customers.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace Proyecto.Documents.Contacts.BO
{
    public class BOContact
    {
        DAOContact DaoContact = new DAOContact();
        public int RegisterContact(DTOContact oContact)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {

                    if (string.IsNullOrWhiteSpace(oContact.FullName_contact))
                    {
                        throw new Exception($"Por favor ingresar el nombre del contacto");
                    }
                    if (string.IsNullOrWhiteSpace(oContact.Address_contact))
                    {
                        throw new Exception($"Por favor ingresar un numero de telefono");
                    }

                    var respContact= DaoContact.RegisterContact(oContact);
                    Scope.Complete();
                    return respContact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido registrar el cliente en el BOContacto, [{ex}]");
            }
        }
        public List<DTOContact> GetContactsByIdCustomer(int Id_customer)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    string Id = Id_customer.ToString();
                    if (string.IsNullOrWhiteSpace(Id))
                    {
                        throw new Exception($"Por favor ingresar un Id del contacto.");
                    }

                    var respCustomer = DaoContact.GetContactsByIdCustomer(Id_customer);
                    Scope.Complete();
                    return respCustomer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener el contacto en el BOContact, [{ex}]");
            }
        }

        public List<DTOContact> GetAllContacts()
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var respContact = DaoContact.GetAllContacts();
                    Scope.Complete();
                    return respContact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener ningun contacto en el BOContact, [{ex}]");
            }
        }

        public int UpdateContact(DTOContact oContact)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (string.IsNullOrWhiteSpace(oContact.FullName_contact))
                    {
                        throw new Exception($"Por favor ingresar un nombre");
                    }
                    if (string.IsNullOrWhiteSpace(oContact.Phone_contact))
                    {
                        throw new Exception($"Por favor ingresar un numero de telefono");
                    }

                    var respContact = DaoContact.UpdateContact(oContact);
                    Scope.Complete();
                    return respContact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido actualizar el contacto en el BOContact, [{ex}]");
            }
        }
        public int DeleteContactById(int Id_contact)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    string Id = Id_contact.ToString();
                    if (string.IsNullOrWhiteSpace(Id))
                    {
                        throw new Exception($"Por favor ingresar un Id del contacto.");
                    }

                    var respContact = DaoContact.DeleteContactById(Id_contact);
                    Scope.Complete();
                    return respContact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el contacto en el BOContacto, [{ex}]");
            }
        }

        public int DeleteContactByIdCustomer(int Id_customer)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    string Id = Id_customer.ToString();
                    if (string.IsNullOrWhiteSpace(Id))
                    {
                        throw new Exception($"Por favor ingresar un Id del Cliente.");
                    }

                    var respContact = DaoContact.DeleteContactByIdCustomer(Id_customer);
                    Scope.Complete();
                    return respContact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se han podido eliminar los contactos en el BOContacto, [{ex}]");
            }
        }
    }
}
