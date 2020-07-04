using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestEntidades
{
    [TestClass]
    public class EntidadesUnitTest
    {
        [TestMethod]
        public void VerificarListaPaquetesInstanciada_OK()
        {
            //arrange
            Correo testCorreo = new Correo();
            bool listaEsNula;

            //act
            listaEsNula = Object.Equals(testCorreo.Paquetes, null);

            //assert
            Assert.IsFalse(listaEsNula);
        }

        [TestMethod]
        public void VerificarAgregarIguales_OK()
        {
            //arrange
            Correo testCorreo = new Correo();
            Paquete paquete1 = new Paquete("Avellaneda", "123 - 124 - 1254");
            Paquete paquete2 = new Paquete("Avellaneda", "123 - 124 - 1254");

            //act
            testCorreo += paquete1;

            try
            {
                testCorreo += paquete2;
                Assert.Fail();
            }
            catch (TrackingIdRepetidoException ex)
            {
                //assert
                Assert.IsInstanceOfType(ex, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
