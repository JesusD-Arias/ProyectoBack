using Proyecto.Documents.Customers.BO;
using Proyecto.Documents.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto.Areas.Customers
{
    public class CustomersController : ApiController
    {
        BOCustomer BoCustomer = new BOCustomer();

        [HttpPost]
        [ActionName("InsertCustomer")]
        public HttpResponseMessage InsertCustomer(DTOCustomer oCustomer)
        {
            try
            {
                var respCustomer = BoCustomer.RegisterCustomer(oCustomer);
                return Request.CreateResponse(HttpStatusCode.OK, $"Se ha registrado el cliente con el nombre: {oCustomer.FullName}, exitosamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de insertar el cliente {ex.Message}");
            }
        }

        [HttpGet]
        [ActionName("GetCustomerById")]
        public HttpResponseMessage GetCustomerById(int Id_customer)
        {
            try
            {
                var respCustomer = BoCustomer.GetCustomerById(Id_customer);
                if (respCustomer.Count == 0)
                    throw new Exception($"No se encontro ningun cliente con el Id: {Id_customer}");

                return Request.CreateResponse(HttpStatusCode.OK, respCustomer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de buscar el cliente {ex.Message}");
            }
        }

        [HttpGet]
        [ActionName("GetAllCustomers")]
        public HttpResponseMessage GetAllCustomers()
        {
            try
            {
                var respCustomer = BoCustomer.GetAllCustomers();
                if (respCustomer.Count == 0)
                    throw new Exception($"No se encontro ningun cliente.");

                return Request.CreateResponse(HttpStatusCode.OK, respCustomer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de buscar los clientes {ex.Message}");
            }
        }

        [HttpPut]
        [ActionName("UpdateCustomer")]
        public HttpResponseMessage UpdateCustomer(DTOCustomer oCustomer)
        {
            try
            {
                var respCustomer = BoCustomer.UpdateCustomer(oCustomer);
                if (respCustomer == 0)
                    throw new Exception($"No se pudo actualizar el cliente.");

                return Request.CreateResponse(HttpStatusCode.OK, $"El cliente ha sido actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de actualizar el cliente {ex.Message}");
            }
        }

        [HttpDelete]
        [ActionName("DeleteCustomerById")]
        public HttpResponseMessage DeleteCustomerById(int Id_customer)
        {
            try
            {
                var respCustomer = BoCustomer.DeleteCustomerById(Id_customer);
                if (respCustomer == 0)
                    throw new Exception($"Id no existe, no se pudo eliminar el cliente.");

                return Request.CreateResponse(HttpStatusCode.OK, $"El cliente ha sido eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de eliminar el cliente {ex.Message}");
            }
        }
    }
}
