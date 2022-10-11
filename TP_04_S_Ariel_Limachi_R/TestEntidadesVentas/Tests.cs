using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_3_Ventas;
using ExepcionesPropias;
using System.Collections.Generic;

namespace TestEntidadesVentas
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestGuardarEnArhivo()
        {
            Persona Guardada = new Persona("sergio", "ramos", "11101010101", "CABA");
            Archivos.Save<Persona>("testUnitario.xml", Guardada);
            Persona Recuperada = Archivos.Leer<Persona>("testUnitario.xml");
            Assert.IsTrue(Guardada == Recuperada);
        }

        [TestMethod]
        public void TestNumeroDeFacturaDiferenteEIncremental()
        {
            Factura actual = new Factura();
            Factura nuevo = new Factura();
            Assert.IsTrue(actual.NroFactura != nuevo.NroFactura && actual.NroFactura < nuevo.NroFactura);
        }
        [TestMethod]
        public void TestElDetalledeCompraEstaVacio()
        {
            bool r = false;
            try
            {

                List<Producto> DetalleComprasvacia = new List<Producto>();
                Persona algo = new Persona();
                Factura aux = new Factura( DetalleComprasvacia, algo, algo);
            }
            catch (DetalleDeCompraVacioException)
            {
                r = true;
            }
            finally
            {
                Assert.IsTrue(r);
            }
        }
        [TestMethod]
        public void ObteniendoUnEmpleadoDeSql()
        {
            DB connexion = new DB("Server=DESKTOP-6B54B0U;Database=petShop;Trusted_Connection=True;");
            Persona recuperada=connexion.RetornarUnEmpleado("20353535352");
            Assert.IsNotNull(recuperada);
            Assert.IsTrue(recuperada.Nombre == "Gabriel" && recuperada.Apellido == "Trigo" && recuperada.Cuil == "20353535352");
        }

        [TestMethod]
        public void ObteniendoTodosEmpleadosDeSql()
        {
            DB connexion = new DB("Server=DESKTOP-6B54B0U;Database=petShop;Trusted_Connection=True;");
            List<Persona> recuperada = connexion.RetornarTodosLosEmpleados();
            Assert.IsNotNull(recuperada);
            Assert.IsTrue(recuperada[0].Nombre == "Gabriel" && recuperada[0].Apellido == "Trigo" && recuperada[0].Cuil == "20353535352");
            Assert.IsTrue(recuperada[1].Nombre == "Jonatan" && recuperada[1].Apellido == "Trigo" && recuperada[1].Cuil == "22343535350");
        }


        [TestMethod]
        public void InsertarUnCliente()
        {
            DB connexion= new DB("Server=DESKTOP-6B54B0U;Database=petShop;Trusted_Connection=True;");
            Persona persona = new Persona("Ariel", "ramos", "20407331193", "CABA");
            Assert.IsTrue(connexion.InsertarCliente(persona));
        }
    }
}
