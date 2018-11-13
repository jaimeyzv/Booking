using System.Collections.Generic;
using System.Data.SqlClient;
using RoomService.Dominio;

namespace RoomService.Persistencia
{
    public class HabitacionDAO
    {
        private string connectionString = @"Data Source=LTPVASS019\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True";

        public Habitacion Obtener(int numero)
        {
            var query = "select * from habitacion where numero = @numero";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@numero", numero));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Habitacion()
                            {
                                id = (int)reader["id"],
                                numero = (int)reader["numero"],
                                camas = (int)reader["camas"],
                                descripcion = reader["descripcion"].ToString(),
                                disponibilidad = (bool)reader["disponibilidad"]
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
            var query = "insert into Habitacion values (@numero, @camas, @descripcion, @disponibilidad)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@numero", habitacion.numero));
                    command.Parameters.Add(new SqlParameter("@camas", habitacion.camas));
                    command.Parameters.Add(new SqlParameter("@descripcion", habitacion.descripcion));
                    command.Parameters.Add(new SqlParameter("@disponibilidad", habitacion.disponibilidad));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(habitacion.numero);
        }
        public Habitacion Modificar(Habitacion habitacion)
        {
            var query = "UPDATE Habitacion SET Camas = @camas, Descripcion = @descripcion, Disponibilidad = @disponibilidad WHERE Numero = @numero";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@numero", habitacion.numero));
                    command.Parameters.Add(new SqlParameter("@camas", habitacion.camas));
                    command.Parameters.Add(new SqlParameter("@descripcion", habitacion.descripcion));
                    command.Parameters.Add(new SqlParameter("@disponibilidad", habitacion.disponibilidad));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(habitacion.numero);
        }
        public void Eliminar(int numero)
        {
            var query = "DELETE FROM Habitacion WHERE Numero = @numero";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@numero", numero));
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Habitacion> Listar()
        {
            var habitaciones = new List<Habitacion>();
            var query = "SELECT * FROM Habitacion";

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
                                id = (int)reader["id"],
                                numero = (int)reader["numero"],
                                camas = (int)reader["camas"],
                                descripcion = reader["descripcion"].ToString(),
                                disponibilidad = (bool)reader["disponibilidad"]
                            });
                        }
                    }

                }
            }

            return habitaciones;
        }
    }
}