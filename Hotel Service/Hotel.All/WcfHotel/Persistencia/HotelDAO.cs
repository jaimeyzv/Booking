using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfHotel.Dominio;

namespace WcfHotel.Persistencia
{
    public class HotelDAO
    {

        private string connectionString = "Data Source=.;Initial Catalog=Hoteles;Integrated security=true";


        public Hotel Consultar(string nombre)
        {
            Hotel hotelEncontrado = null;
            string sql = "select * from Hotel where Nombre = @Nombre";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    command.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    using (SqlDataReader resultado = command.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            hotelEncontrado = new Hotel()
                            {
                                IdHotel = (int)resultado["IdHotel"],
                                Nombre = (string)resultado["Nombre"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"]
                            };
                        }
                    }
                }
            }

            return hotelEncontrado;
        }




        public Hotel Crear(Hotel hotel)
        {


            Hotel hotelCreado = null;

            string sql = "insert into Hotel (Nombre, Direccion, Telefono) values (@Nombre, @Direccion, @Telefono)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    command.Parameters.Add(new SqlParameter("@Nombre", hotel.Nombre));
                    command.Parameters.Add(new SqlParameter("@Direccion", hotel.Direccion));
                    command.Parameters.Add(new SqlParameter("@Telefono", hotel.Telefono));
                    command.ExecuteNonQuery();
                }
            }

            hotelCreado = Consultar(hotel.Nombre);
            return hotelCreado;
        }

        public Hotel Modificar(Hotel hotel)
        {
            Hotel hotelModificado = null;
            string sql = "UPDATE Hotel SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono WHERE  IdHotel= @IdHotel";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(sql, conexion))
                {

                    command.Parameters.Add(new SqlParameter("@Nombre", hotel.Nombre));
                    command.Parameters.Add(new SqlParameter("@Direccion", hotel.Direccion));
                    command.Parameters.Add(new SqlParameter("@Telefono", hotel.Telefono));
                    command.Parameters.Add(new SqlParameter("@IdHotel", hotel.IdHotel));
                    command.ExecuteNonQuery();
                }
            }

            hotelModificado = Consultar(hotel.Nombre);
            return hotelModificado;
        }

        public void Eliminar(int idhotel)
        {
            string sql = "DELETE FROM Hotel WHERE IdHotel= @IdHotel";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    command.Parameters.Add(new SqlParameter("@IdHotel", idhotel));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Hotel> Listar()
        {
            List<Hotel> hotelesEncontrados = new List<Hotel>();
            Hotel hotelEncontrado = null;
            string sql = "SELECT * FROM Hotel";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = command.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            hotelEncontrado = new Hotel()
                            {
                                IdHotel = (int)resultado["IdHotel"],
                                Nombre = (string)resultado["Nombre"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"]
                            };
                            hotelesEncontrados.Add(hotelEncontrado);
                        }
                    }
                }

            }
            return hotelesEncontrados;
        }


    }
}