using RoomService.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RoomService.Persistencia
{
    public class HabitacionDAO
    {
        //private string connectionString = @"Data Source=LTPVASS019\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True";
        private string connectionString = "Server=JAIME-PC;Database=Habitaciones;User ID=JaimePC;pwd=face15PIER";

        public Habitacion Obtener(int habitacionId)
        {
            var query = "select * from Habitaciones where HabitacionId = @HabitacionId";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@HabitacionId", habitacionId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Habitacion()
                            {
                                HabitacionId = (int)reader["HabitacionId"],
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Numero = (int)reader["Numero"],
                                CantidadCamas = (int)reader["CantidadCamas"],
                                Codigoimagen = reader["Codigoimagen"].ToString(),
                                Disponible = (bool)reader["Disponible"],
                                Activo = (bool)reader["Activo"]
                            };
                        }
                        else
                        { return null; }
                    }
                }
            }

        }

        public Habitacion ObtenerPorHotelYNumeroHabitacion(string codigoHotel, int numeroHabitacion)
        {
            var query = "select * from Habitaciones where (CodigoHotel = @CodigoHotel and  Numero = @Numero)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CodigoHotel", codigoHotel));
                    command.Parameters.Add(new SqlParameter("@Numero", numeroHabitacion));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Habitacion()
                            {
                                HabitacionId = (int)reader["HabitacionId"],
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Numero = (int)reader["Numero"],
                                CantidadCamas = (int)reader["CantidadCamas"],
                                Codigoimagen = reader["Codigoimagen"].ToString(),
                                Disponible = (bool)reader["Disponible"],
                                Activo = (bool)reader["Activo"]
                            };
                        }
                        else
                        { return null; }
                    }
                }
            }

        }

        public Habitacion Crear(Habitacion habitacion)
        {
            var query = "insert into Habitaciones values (@CodigoHabitacion, @CodigoHotel, @Descripcion, @Precio, @Numero, @CantidadCamas, @Codigoimagen, @Disponible, @Activo); SELECT CAST(scope_identity() AS int)";
            var habitacionId = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CodigoHabitacion", habitacion.CodigoHabitacion));
                    command.Parameters.Add(new SqlParameter("@CodigoHotel", habitacion.CodigoHotel));
                    command.Parameters.Add(new SqlParameter("@Descripcion", habitacion.Descripcion));
                    command.Parameters.Add(new SqlParameter("@Precio", habitacion.Precio));
                    command.Parameters.Add(new SqlParameter("@Numero", habitacion.Numero));
                    command.Parameters.Add(new SqlParameter("@CantidadCamas", habitacion.CantidadCamas));
                    command.Parameters.Add(new SqlParameter("@Codigoimagen", habitacion.Codigoimagen));
                    command.Parameters.Add(new SqlParameter("@Disponible", 1));
                    command.Parameters.Add(new SqlParameter("@Activo", 1));
                    habitacionId = (int)command.ExecuteScalar();
                }
            }

            return Obtener(habitacionId);
        }

        public Habitacion Modificar(Habitacion habitacion)
        {
            var query = "UPDATE Habitaciones SET CodigoHabitacion = @CodigoHabitacion, CodigoHotel = @CodigoHotel, Descripcion = @Descripcion, Precio = @Precio, Numero = @Numero, CantidadCamas = @CantidadCamas, Codigoimagen = @Codigoimagen, Disponible = @Disponible, Activo = @Activo WHERE HabitacionId = @HabitacionId";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@HabitacionId", habitacion.HabitacionId));
                    command.Parameters.Add(new SqlParameter("@CodigoHabitacion", habitacion.CodigoHabitacion));
                    command.Parameters.Add(new SqlParameter("@CodigoHotel", habitacion.CodigoHotel));
                    command.Parameters.Add(new SqlParameter("@Descripcion", habitacion.Descripcion));
                    command.Parameters.Add(new SqlParameter("@Precio", habitacion.Precio));
                    command.Parameters.Add(new SqlParameter("@Numero", habitacion.Numero));
                    command.Parameters.Add(new SqlParameter("@CantidadCamas", habitacion.CantidadCamas));
                    command.Parameters.Add(new SqlParameter("@Codigoimagen", habitacion.Codigoimagen));
                    command.Parameters.Add(new SqlParameter("@Disponible", habitacion.Disponible));
                    command.Parameters.Add(new SqlParameter("@Activo", habitacion.Activo));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(habitacion.HabitacionId);
        }

        public int Eliminar(int habitacionId)
        {
            var query = "DELETE FROM Habitaciones WHERE HabitacionId = @HabitacionId";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@HabitacionId", habitacionId));
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<Habitacion> Listar()
        {
            var habitaciones = new List<Habitacion>();
            var query = "SELECT * FROM Habitaciones";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            habitaciones.Add(new Habitacion()
                            {
                                HabitacionId = (int)reader["HabitacionId"],
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Numero = (int)reader["Numero"],
                                CantidadCamas = (int)reader["CantidadCamas"],
                                Codigoimagen = reader["Codigoimagen"].ToString(),
                                Disponible = (bool)reader["Disponible"],
                                Activo = (bool)reader["Activo"]
                            });
                        }
                    }

                }
            }

            return habitaciones;
        }

        public List<Habitacion> ListarPorHotel(string codigoHotel)
        {
            var habitaciones = new List<Habitacion>();
            var query = "SELECT * FROM Habitaciones WHERE CodigoHotel = @CodigoHotel";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CodigoHotel", codigoHotel));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            habitaciones.Add(new Habitacion()
                            {
                                HabitacionId = (int)reader["HabitacionId"],
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Numero = (int)reader["Numero"],
                                CantidadCamas = (int)reader["CantidadCamas"],
                                Codigoimagen = reader["Codigoimagen"].ToString(),
                                Disponible = (bool)reader["Disponible"],
                                Activo = (bool)reader["Activo"]
                            });
                        }
                    }
                }
            }

            return habitaciones;
        }
    }
}