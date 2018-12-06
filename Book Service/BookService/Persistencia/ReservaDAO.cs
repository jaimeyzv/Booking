using BookService.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookService.Persistencia
{
    public class ReservaDAO
    {
        //private string connectionString = @"Data Source=LTPVASS019\SQLEXPRESS;Initial Catalog=Reservas;Integrated Security=True";
        private string connectionString = "Server=JAIME-PC;Database=Reservas;User ID=JaimePC;pwd=face15PIER";

        public Reserva Obtener(int reservaId)
        {
            var query = "select * from Reserva where ReservaId = @ReservaId";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ReservaId", reservaId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reserva()
                            {
                                ReservaId = (int)reader["ReservaId"],
                                Codigo = reader["Codigo"].ToString(),
                                DniMiembro = reader["DniMiembro"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                NumeroHabitacion = (int)reader["NumeroHabitacion"],
                                PrecioHotel = (decimal)reader["PrecioHotel"],
                                CantidadPersonas = (int)reader["CantidadPersonas"],
                                FechaCheckIn = (DateTime)reader["FechaCheckIn"],
                                FechaCheckOut = (DateTime)reader["FechaCheckOut"],
                                FechaRegistro = (DateTime)reader["FechaRegistro"],
                                Estado = reader["Estado"].ToString()
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
            var query = "insert into Reserva values (@Codigo, @DniMiembro, @CodigoHotel, @CodigoHabitacion, @NumeroHabitacion, @PrecioHotel, @CantidadPersonas, @FechaCheckIn, @FechaCheckOut, @FechaRegistro, @Estado); SELECT CAST(scope_identity() AS int)";
            var reservaId = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Codigo", reserva.Codigo));
                    command.Parameters.Add(new SqlParameter("@DniMiembro", reserva.DniMiembro));
                    command.Parameters.Add(new SqlParameter("@CodigoHotel", reserva.CodigoHotel));
                    command.Parameters.Add(new SqlParameter("@CodigoHabitacion", reserva.CodigoHabitacion));
                    command.Parameters.Add(new SqlParameter("@NumeroHabitacion", reserva.NumeroHabitacion));
                    command.Parameters.Add(new SqlParameter("@PrecioHotel", reserva.PrecioHotel));
                    command.Parameters.Add(new SqlParameter("@CantidadPersonas", reserva.CantidadPersonas));
                    command.Parameters.Add(new SqlParameter("@FechaCheckIn", reserva.FechaCheckIn));
                    command.Parameters.Add(new SqlParameter("@FechaCheckOut", reserva.FechaCheckOut));
                    command.Parameters.Add(new SqlParameter("@FechaRegistro", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@Estado", reserva.Estado));
                    reservaId = (int)command.ExecuteScalar();
                }
            }

            return Obtener(reservaId);
        }

        public Reserva Modificar(Reserva reserva)
        {
            var query = "UPDATE Reserva SET Codigo = @Codigo, DniMiembro = @DniMiembro, CodigoHotel = @CodigoHotel, CodigoHabitacion = @CodigoHabitacion, NumeroHabitacion = @NumeroHabitacion, PrecioHotel = @PrecioHotel, CantidadPersonas = @CantidadPersonas, FechaCheckIn = @FechaCheckIn, FechaCheckOut = @FechaCheckOut, FechaRegistro = @FechaRegistro, Estado = @Estado WHERE ReservaId = @ReservaId";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ReservaId", reserva.ReservaId));
                    command.Parameters.Add(new SqlParameter("@Codigo", reserva.Codigo));
                    command.Parameters.Add(new SqlParameter("@DniMiembro", reserva.DniMiembro));
                    command.Parameters.Add(new SqlParameter("@CodigoHotel", reserva.CodigoHotel));
                    command.Parameters.Add(new SqlParameter("@CodigoHabitacion", reserva.CodigoHabitacion));
                    command.Parameters.Add(new SqlParameter("@NumeroHabitacion", reserva.NumeroHabitacion));
                    command.Parameters.Add(new SqlParameter("@PrecioHotel", reserva.PrecioHotel));
                    command.Parameters.Add(new SqlParameter("@CantidadPersonas", reserva.CantidadPersonas));
                    command.Parameters.Add(new SqlParameter("@FechaCheckIn", reserva.FechaCheckIn));
                    command.Parameters.Add(new SqlParameter("@FechaCheckOut", reserva.FechaCheckOut));
                    command.Parameters.Add(new SqlParameter("@FechaRegistro", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@Estado", reserva.Estado));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(reserva.ReservaId);
        }

        public void Eliminar(int reservaId)
        {
            var query = "DELETE FROM Reserva WHERE ReservaId = @ReservaId";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ReservaId", reservaId));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reserva> ListarPorMiembro(string dni)
        {
            var reservas = new List<Reserva>();
            var query = "SELECT * FROM Reserva WHERE DniMiembro = @DniMiembro";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DniMiembro", dni));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new Reserva()
                            {
                                ReservaId = (int)reader["ReservaId"],
                                Codigo = reader["Codigo"].ToString(),
                                DniMiembro = reader["DniMiembro"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                NumeroHabitacion = (int)reader["NumeroHabitacion"],
                                PrecioHotel = (decimal)reader["PrecioHotel"],
                                CantidadPersonas = (int)reader["CantidadPersonas"],
                                FechaCheckIn = (DateTime)reader["FechaCheckIn"],
                                FechaCheckOut = (DateTime)reader["FechaCheckOut"],
                                FechaRegistro = (DateTime)reader["FechaRegistro"],
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }

                }
            }

            return reservas;
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
                                ReservaId = (int)reader["ReservaId"],
                                Codigo = reader["Codigo"].ToString(),
                                DniMiembro = reader["DniMiembro"].ToString(),
                                CodigoHotel = reader["CodigoHotel"].ToString(),
                                CodigoHabitacion = reader["CodigoHabitacion"].ToString(),
                                NumeroHabitacion = (int)reader["NumeroHabitacion"],
                                PrecioHotel = (decimal)reader["PrecioHotel"],
                                CantidadPersonas = (int)reader["CantidadPersonas"],
                                FechaCheckIn = (DateTime)reader["FechaCheckIn"],
                                FechaCheckOut = (DateTime)reader["FechaCheckOut"],
                                FechaRegistro = (DateTime)reader["FechaRegistro"],
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }

                }
            }

            return reservas;
        }
    }
}