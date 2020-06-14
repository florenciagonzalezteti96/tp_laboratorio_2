using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;

namespace TestUnitarioEntidades
{
    [TestClass]
    public class EntidadesTest
    {
        /// <summary>
        /// Este metodo de Test unitario verifica que se creen las listas de los atributos de una instancia de tipo Universidad
        /// El metodo falla si alguna de las listas tienen valor null
        /// </summary>
        [TestMethod]
        public void VerificarListaAlumnoUniversidad_OK()
        {
            //arrange
            Universidad uni = new Universidad();

            //act
            if(uni.Alumnos == null || uni.Instructores == null || uni.Jornadas == null)
            {
                //assert
                Assert.Fail();
            }
        }
        /// <summary>
        /// Este metodo de Test unitario lanza una excepcion de tipo AlumnoRepetidoException al intentar agregar dos alumnos iguales a la misma universidad.
        /// El metodo falla si permite que se agregue el alumno repetido, o si la excepcion que lanza es de un tipo distinto a AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void VerificarAlumnoRepetidoException_OK()
        {
            //arrange
            Alumno alumno = new Alumno(1, "Juan", "Gonzalez", "15000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumnoRepetido = new Alumno(1, "Juan", "Gonzalez", "15000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad uni = new Universidad();

            try
            {
                //act
                uni += alumno;
                uni += alumnoRepetido;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Este metodo de Test unitario agrega dos alumnos con diferente id a la misma universidad.
        /// El metodo falla si lanza una excepcion de tipo AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void VerificarAlumnoRepetidoException_Fail()
        {
            //arrange
            Alumno a1 = new Alumno(1, "Juan", "Gonzalez", "15000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Juan", "Gonzalez", "15000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad uni = new Universidad();

            try
            {
                //act
                uni += a1;
                uni += a2;
            }
            catch (Exception ex)
            {
                if(ex.GetType() == typeof(AlumnoRepetidoException))
                {
                    //assert
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Este metodo de Test unitario leera un archivo de texto existente al pasarle el path del mismo al metodo Leer() de la clase Texto
        /// Si no puede leer, el metodo falla el Test
        /// </summary>
        [TestMethod]
        public void VerificarLeerArchivoTexto_OK()
        {
            //arrange
            Texto txt = new Texto();
            string datosGuardados = "Este archivo se genero al probar el metodo VerificarLeerArchivoTexto_OK() del proyecto TestUnitarioEntidades.";
            string datosLeidos;
            string pathArchivo = "LeerArchivoDeTextoTest.txt";

            //act
            txt.Guardar(pathArchivo, datosGuardados);

            try
            {
                txt.Leer(pathArchivo, out datosLeidos);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Este metodo de Test unitario lanza una excepcion de tipo ArchivosException al pasarle un path de un archivo de texto inexistente al metodo Leer() de la clase Texto
        /// Si no se lanza la excepcion, el metodo falla el Test
        /// </summary>
        [TestMethod]
        public void VerificarLeerArchivoTexto_Fail()
        {
            //arrange
            Texto txt = new Texto();
            string datos;
            string pathArchivo = "ArchivoInexistente.txt";

            //act
            try
            {
                txt.Leer(pathArchivo, out datos);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArchivosException));
            }
        }

        /// <summary>
        /// Este metodo de Test unitario verifica que se guarda un archivo de texto al pasarle un path para crearlo y/o guardarlo a traves del metodo Guardar() de la clase Texto
        /// Si se lanza la excepcion o el archivo no existe luego de ejecutar el metodo Guardar(), el metodo falla el Test 
        /// </summary>
        [TestMethod]
        public void VerificarGuardarArchivoTexto_OK()
        {
            //arrange
            Texto txt = new Texto();
            string datosGuardados = "Este archivo se genero al probar el metodo VerificarGuardarArchivoTexto_OK() del proyecto TestUnitarioEntidades.";
            string archivo = "GuardarArchivoDeTextoTest.txt";

            //act
            try
            {
                txt.Guardar(archivo, datosGuardados);
                if (!File.Exists(archivo))
                {
                    Assert.Fail();
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Este metodo de Test unitario lanza una excepcion de tipo ArchivosException al pasarle un path nulo para crear un archivo con el metodo Guardar() de la clase Texto
        /// Si no se lanza la excepcion, el metodo falla el Test
        /// </summary>
        [TestMethod]
        public void VerificarGuardarArchivoTexto_Fail()
        {
            //arrange
            Texto txt = new Texto();
            string datosGuardados = "Este archivo se genero al probar el metodo VerificarGuardarArchivoTexto_Fail() del proyecto TestUnitarioEntidades.";
            string archivo = null;

            //act
            try
            {
                txt.Guardar(archivo, datosGuardados);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArchivosException));
            }
        }
    }
}
