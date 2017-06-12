using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Zapateria.Controller;
using Zapateria.Modelo;

namespace WebService.Service
{
    /// <summary>
    /// Summary description for ClienteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ClienteService : System.Web.Services.WebService
    {
        Conexion con = new Conexion();
        [WebMethod]
        public List<Cliente> getClientes()
        {
            return con.getClientes();
        }

        [WebMethod]
        public String insertCliente(string idCliente, string nombre, string apellido, string telefono, string email)
        {
            return con.insertCliente(idCliente, nombre, apellido, telefono, email);
        }

        [WebMethod]
        public String updateCliente(string idCliente, string nombre, string apellido, string telefono, string email)
        {
            return con.updateCliente(idCliente, nombre, apellido, telefono, email);
        }
    }
}
