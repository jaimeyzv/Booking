using System.Collections.Generic;
using System.Data.SqlClient;
using WcfHotel.Dominio;

namespace WcfHotel.Persistencia
{
    public class HotelDAO
    {

        //private string connectionString = "Data Source=.;Initial Catalog=Hoteles;Integrated security=true";
        private string connectionString = "Server=JAIME-PC;Database=Hoteles;User ID=JaimePC;pwd=face15PIER";

        public Hotels ObtenerPorCodigo(string codigo)
        {
            string sql = "select * from Hoteles where Codigo = @Codigo";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    command.Parameters.Add(new SqlParameter("@Codigo", codigo));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Hotels()
                            {
                                HotelId = (int)reader["HotelId"],
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                CodigoImagen = reader["CodigoImagen"].ToString(),
                                Estrellas = (int)reader["Estrellas"],
                                Activo = (bool)reader["Activo"]
                            };
                        }
                        else{ return null; }
                    }
                }
            }
        }
        
        public Hotels Crear(Hotels hotel)
        {
            Hotels hotelCreado = null;

            string sql = "insert into Hoteles values (@Codigo, @Nombre, @Descripcion, @Direccion, @Telefono, @CodigoImagen, @Estrellas, @Activo)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    command.Parameters.Add(new SqlParameter("@Codigo", hotel.Codigo));
                    command.Parameters.Add(new SqlParameter("@Nombre", hotel.Nombre));
                    command.Parameters.Add(new SqlParameter("@Descripcion", hotel.Descripcion));
                    command.Parameters.Add(new SqlParameter("@Direccion", hotel.Direccion));
                    command.Parameters.Add(new SqlParameter("@Telefono", hotel.Telefono));
                    command.Parameters.Add(new SqlParameter("@CodigoImagen", hotel.CodigoImagen));
                    command.Parameters.Add(new SqlParameter("@Estrellas", hotel.Estrellas));
                    command.Parameters.Add(new SqlParameter("@Activo", 1));
                    command.ExecuteNonQuery();
                }
            }

            hotelCreado = ObtenerPorCodigo(hotel.Codigo);
            return hotelCreado;
        }

        public Hotels Modificar(Hotels hotel)
        {
            string query = "UPDATE Hoteles SET Nombre = @Nombre, Descripcion = @Descripcion, Direccion = @Direccion, Telefono = @Telefono, CodigoImagen = @CodigoImagen, Estrellas = @Estrellas, Activo = @Activo WHERE  Codigo= @Codigo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Codigo", hotel.Codigo));
                    command.Parameters.Add(new SqlParameter("@Nombre", hotel.Nombre));
                    command.Parameters.Add(new SqlParameter("@Descripcion", hotel.Descripcion));
                    command.Parameters.Add(new SqlParameter("@Direccion", hotel.Direccion));
                    command.Parameters.Add(new SqlParameter("@Telefono", hotel.Telefono));
                    command.Parameters.Add(new SqlParameter("@CodigoImagen", hotel.CodigoImagen));
                    command.Parameters.Add(new SqlParameter("@Estrellas", hotel.Estrellas));
                    command.Parameters.Add(new SqlParameter("@Activo", 1));
                    command.ExecuteNonQuery();
                }
            }

            return ObtenerPorCodigo(hotel.Codigo);
        }

        public int Eliminar(string codigo)
        {
            string sql = "DELETE FROM Hoteles WHERE Codigo= @Codigo";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    command.Parameters.Add(new SqlParameter("@Codigo", codigo));
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<Hotels> Listar()
        {
            var hoteles = new List<Hotels>();
            string sql = "SELECT * FROM Hoteles";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hoteles.Add(new Hotels()
                            {
                                HotelId = (int)reader["HotelId"],
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                CodigoImagen = reader["CodigoImagen"].ToString(),
                                Estrellas = (int)reader["Estrellas"],
                                Activo = (bool)reader["Activo"]
                            });
                        }
                    }
                }
            }

            return hoteles;
        }
    }
}