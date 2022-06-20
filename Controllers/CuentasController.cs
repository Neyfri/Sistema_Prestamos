using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Login_Test.Models;

namespace Login_Test.Controllers
{
    public class CuentasController : Controller
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;
        // GET: Cuentas
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            connection.ConnectionString = "data source=(localdb)\\mssqllocaldb; database=base1; integrated security = SSPI;";
        }
        public ActionResult Verificar(usuario control)
        {
            connectionString();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM usuarios where usuario='"+control.usuario1+"' and clave='"+control.clave+"'";
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                connection.Close();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View("Error");
            }
        }

    }
}