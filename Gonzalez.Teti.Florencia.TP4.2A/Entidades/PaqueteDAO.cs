using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        #region Metodos

        /// <summary>
        /// Inicializa los atributos de clase de PaqueteDAO, configurando la conexion del atributo conexion
        /// </summary>
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.conexion);
        }

        /// <summary>
        /// Este metodo realiza una insercion de un objeto de tipo Paquete en una base de datos
        /// </summary>
        /// <param name="p">el objeto de tipo Paquete a guardar en la base de datos</param>
        /// <returns>Si ocurre un error, se lanzara una excepcion. Si se logro guardar retornara true, caso contrario retornara false.</returns>
        public static bool Insertar(Paquete p)
        {
            bool sePudoInsertar = true;

            try
            {
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "INSERT into [correo-sp-2017].dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Florencia Gonzalez Teti')";

                comando.Connection = conexion;

                conexion.Open();

                int resultado = comando.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                sePudoInsertar = false;
                throw ex;
            }
            finally
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return sePudoInsertar;
        }

        #endregion

    }
}
