using BookService.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookService.Persistencia
{
    public class ReservaDAO
    {
        private string connectionString = "Data Source=.;Initial Catalog=BookService;Integrated Security=True";

        public Reserva Obtener(int idReserva)
        {
            var query = "select * from Reserva where IdReserva = @idReserva";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@idReserva", idReserva));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reserva()
                            {
                                IdReserva = (int)reader["IdReserva"],
                                NuHabitacion = (int)reader["NuHabitacion"],
                                NuPasajeros = (int)reader["NuPasajeros"],
                                TipoHabitacion = reader["TipoHabitacion"].ToString(),
                                PrecioHabitacion = (decimal)reader["PrecioHabitacion"],
                                FechaReservaIn = (DateTime)reader["FechaReservaIn"],
                                FechaReservaOut = (DateTime)reader["FechaReservaOut"],
                                FechaRegistro = (DateTime)reader["FechaRegistro"]
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }

        public Reserva Crear(Reserva reserva)
        {
            var query = "insert into Reserva values (@NuHabitacion, @NuPasajeros, @TipoHabitacion, @PrecioHabitacion, @FechaReservaIn, @FechaReservaOut, @FechaRegistro)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@NuHabitacion", reserva.NuHabitacion));
                    command.Parameters.Add(new SqlParameter("@NuPasajeros", reserva.NuPasajeros));
                    command.Parameters.Add(new SqlParameter("@TipoHabitacion", reserva.TipoHabitacion));
                    command.Parameters.Add(new SqlParameter("@PrecioHabitacion", reserva.PrecioHabitacion));
                    command.Parameters.Add(new SqlParameter("@FechaReservaIn", reserva.FechaReservaIn));
                    command.Parameters.Add(new SqlParameter("@FechaReservaOut", reserva.FechaReservaOut));
                    command.Parameters.Add(new SqlParameter("@FechaRegistro", DateTime.Now));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(reserva.IdReserva);
        }

        public Reserva Modificar(Reserva reserva)
        {
            var query = "UPDATE Reserva SET NuHabitacion = @NuHabitacion, NuPasajeros = @NuPasajeros, TipoHabitacion = @TipoHabitacion, PrecioHabitacion = @PrecioHabitacion, FechaReservaIn = @FechaReservaIn, FechaReservaOut = @FechaReservaOut WHERE IdRserva = @IdRserva";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@NuHabitacion", reserva.NuHabitacion));
                    command.Parameters.Add(new SqlParameter("@NuPasajeros", reserva.NuPasajeros));
                    command.Parameters.Add(new SqlParameter("@TipoHabitacion", reserva.TipoHabitacion));
                    command.Parameters.Add(new SqlParameter("@PrecioHabitacion", reserva.PrecioHabitacion));
                    command.Parameters.Add(new SqlParameter("@FechaReservaIn", reserva.FechaReservaIn));
                    command.Parameters.Add(new SqlParameter("@FechaReservaOut", reserva.FechaReservaOut));        
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(reserva.IdReserva);
        }

        public void Eliminar(int IdReserva)
        {
            var query = "DELETE FROM Reserva WHERE IdReserva = @IdReserva";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdReserva", IdReserva));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reserva> Listar()
        {
            var reservas = new List<Reserva>();
            var query = "SELECT * FROM Reserva";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new Reserva()
                            {
                                IdReserva = (int)reader["IdReserva"],
                                NuHabitacion = (int)reader["NuHabitacion"],
                                NuPasajeros = (int)reader["NuPasajeros"],
                                TipoHabitacion = reader["TipoHabitacion"].ToString(),
                                PrecioHabitacion = (decimal)reader["PrecioHabitacion"],
                                FechaReservaIn = (DateTime)reader["FechaReservaIn"],
                                FechaReservaOut = (DateTime)reader["FechaReservaOut"],
                                FechaRegistro = (DateTime)reader["FechaRegistro"]
                            });
                        }
                    }

                }
            }

            return reservas;
        }
    }
}