using Proyecto.Documents.Contacts.BO;
using Proyecto.Documents.Contacts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto.Areas.Customers
{
    public class ContactsController : ApiController
    {
        BOContact BoContact = new BOContact();
        [HttpPost]
        [ActionName("InsertContact")]

        public HttpResponseMessage InsertContact(DTOContact oContact)
        {
            try
            {
                BoContact.RegisterContact(oContact);
                return Request.CreateResponse(HttpStatusCode.OK, $"Se ha registrado el contacto exitosamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de insertar el contacto {ex.Message}");
            }
        }

        [HttpGet]
        [ActionName("GetContactsByIdCustomer")]
        public HttpResponseMessage GetContactsByIdCustomer(int Id_customer)
        {
            try
            {
                var respContact = BoContact.GetContactsByIdCustomer(Id_customer);
                if (respContact.Count == 0)
                    throw new Exception($"No se encontro ningun contacto en el cliente con Id: {Id_customer}.");

                return Request.CreateResponse(HttpStatusCode.OK, respContact);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de buscar el contacto {ex.Message}");
            }
        }

        [HttpGet]
        [ActionName("GetAllContacts")]
        public HttpResponseMessage GetAllContacts()
        {
            try
            {
                var respContact = BoContact.GetAllContacts();
                if (respContact.Count == 0)
                    throw new Exception($"No se encontro ningun contacto.");

                return Request.CreateResponse(HttpStatusCode.OK, respContact);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de buscar los contactos {ex.Message}");
            }
        }

        [HttpPut]
        [ActionName("UpdateContact")]
        public HttpResponseMessage UpdateContact(DTOContact oContact)
        {
            try
            {
                var respContact = BoContact.UpdateContact(oContact);
                if (respContact == 0)
                    throw new Exception($"No se pudo actualizar el contacto.");

                return Request.CreateResponse(HttpStatusCode.OK, $"El contacto ha sido actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de actualizar el contacto {ex.Message}");
            }
        }

        [HttpDelete]
        [ActionName("DeleteContactById")]
        public HttpResponseMessage DeleteContactById(int Id_contact)
        {
            try
            {
                var respContact = BoContact.DeleteContactById(Id_contact);
                if (respContact == 0)
                    throw new Exception($"Id no existe, no se pudo eliminar el contacto.");

                return Request.CreateResponse(HttpStatusCode.OK, $"El contacto ha sido eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error al tratar de eliminar el contacto {ex.Message}");
            }
        }
    }
}
