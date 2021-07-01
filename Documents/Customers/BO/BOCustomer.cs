using Proyecto.Documents.Contacts.BO;
using Proyecto.Documents.Customers.DAO;
using Proyecto.Documents.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Proyecto.Documents.Customers.BO
{
    public class BOCustomer
    {
        DAOCustomer DaoCustomer = new DAOCustomer();
        BOContact BoContact = new BOContact();
        public string RegisterCustomer(DTOCustomer oCustomer)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (string.IsNullOrWhiteSpace(oCustomer.FullName))
                    {
                        throw new Exception($"Por favor ingresar el nombre");
                    }
                    if (string.IsNullOrWhiteSpace(oCustomer.Phone))
                    {
                        throw new Exception($"Por favor ingresar un numero de telefono");
                    }

                    var respCustomer = DaoCustomer.RegisterCustomer(oCustomer);
                    Scope.Complete();
                    return respCustomer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido registrar el cliente en el BOCustomer, [{ex}]");
            }
        }

        public List<DTOCustomer> GetCustomerById(int Id_customer)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    string Id = Id_customer.ToString();
                    if (string.IsNullOrWhiteSpace(Id))
                    {
                        throw new Exception($"Por favor ingresar un Id del cliente.");
                    }

                    var respCustomer = DaoCustomer.GetCustomerById(Id_customer);
                    Scope.Complete();
                    return respCustomer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener el cliente en el BOCustomer, [{ex}]");
            }
        }

        public List<DTOCustomer> GetAllCustomers()
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var respCustomer = DaoCustomer.GetAllCustomers();
                    Scope.Complete();
                    return respCustomer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido obtener ningun cliente en el BOCustomer, [{ex}]");
            }
        }

        public int UpdateCustomer(DTOCustomer oCustomer)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    if (string.IsNullOrWhiteSpace(oCustomer.FullName))
                    {
                        throw new Exception($"Por favor ingresar un nombre");
                    }
                    if (string.IsNullOrWhiteSpace(oCustomer.Phone))
                    {
                        throw new Exception($"Por favor ingresar un numero de telefono");
                    }

                    var respCustomer = DaoCustomer.UpdateCustomer(oCustomer);
                    Scope.Complete();
                    return respCustomer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido actualizar el cliente en el BOCustomer, [{ex}]");
            }
        }
        public int DeleteCustomerById(int Id_customer)
        {
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    string Id = Id_customer.ToString();
                    if (string.IsNullOrWhiteSpace(Id))
                    {
                        throw new Exception($"Por favor ingresar un Id del cliente.");
                    }

                    BoContact.DeleteContactByIdCustomer(Id_customer);
                    var respCustomer = DaoCustomer.DeleteCustomerById(Id_customer);
                    Scope.Complete();
                    return respCustomer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el cliente en el BOCustomer, [{ex}]");
            }
        }    
    }
}