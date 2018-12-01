using System.Collections.Generic;
using System.Data.SqlClient;
using MobilityService.Dominio;

namespace MobilityService.Persistencia
{
    public class MovilidadDAO
    {
        private string connectionString = @"Data Source=LTPVASS019\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True";
        //private string connectionString = "Server=JAIME-PC;Database=Miembros;User ID=JaimePC;pwd=face15PIER";

        public Movilidad Obtener(int codigo)
        {
            var query = "select * from Movilidad where codigo = @codigo";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@codigo", codigo));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Movilidad()
                            {
                                id = (int)reader["id"],
                                codigo = (int)reader["codigo"],
                                tipoMovilidad = (int)reader["tipoMovilidad"],
                                numeroPasajeros = (int)reader["numeroPasajeros"],
                                costoPorTramo = (decimal)reader["costoPorTramo"],
                                descripcion = reader["descripcion"].ToString(),
                                disponibilidad = (bool)reader["disponibilidad"]
                            };
                        }
                        else { return null; }
                    }
                }
            }
        }

        public Movilidad ObtenerPorCodigoYTipoMovilidad(int codigo, int tipoMovilidad)
        {
            var query = "select * from Movilidad where (codigo = @codigo and tipoMovilidad = @tipoMovilidad)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@codigo", codigo));
                    command.Parameters.Add(new SqlParameter("@tipoMovilidad", tipoMovilidad));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Movilidad()
                            {
                                id = (int)reader["id"],
                                codigo = (int)reader["codigo"],
                                tipoMovilidad = (int)reader["tipoMovilidad"],
                                numeroPasajeros = (int)reader["numeroPasajeros"],
                                costoPorTramo = (decimal)reader["costoPorTramo"],
                                descripcion = reader["descripcion"].ToString(),
                                disponibilidad = (bool)reader["disponibilidad"]
                            };
                        }
                        else { return null; }
                    }
                }
            }
        }

        public Movilidad Crear(Movilidad movilidad)
        {
            var query = "insert into Movilidad (codigo, tipoMovilidad, numeroPasajeros, costoPorTramo, descripcion, disponibilidad) values (@codigo, @tipoMovilidad, @numeroPasajeros, @costoPorTramo, @descripcion, @disponibilidad)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@codigo", movilidad.codigo));
                    command.Parameters.Add(new SqlParameter("@tipoMovilidad", movilidad.tipoMovilidad));
                    command.Parameters.Add(new SqlParameter("@numeroPasajeros", movilidad.numeroPasajeros));
                    command.Parameters.Add(new SqlParameter("@costoPorTramo", movilidad.costoPorTramo));
                    command.Parameters.Add(new SqlParameter("@descripcion", movilidad.descripcion));
                    command.Parameters.Add(new SqlParameter("@disponibilidad", 1));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(movilidad.codigo);
        }

        public Movilidad Modificar(Movilidad movilidad)
        {
            var query = "UPDATE Movilidad SET codigo = @codigo, tipoMovilidad = @tipoMovilidad, numeroPasajeros = @numeroPasajeros, costoPorTramo = @costoPorTramo, descripcion = @descripcion, disponibilidad = @disponibilidad WHERE id = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", movilidad.id));
                    command.Parameters.Add(new SqlParameter("@codigo", movilidad.codigo));
                    command.Parameters.Add(new SqlParameter("@tipoMovilidad", movilidad.tipoMovilidad));
                    command.Parameters.Add(new SqlParameter("@numeroPasajeros", movilidad.numeroPasajeros));
                    command.Parameters.Add(new SqlParameter("@costoPorTramo", movilidad.costoPorTramo));
                    command.Parameters.Add(new SqlParameter("@descripcion", movilidad.descripcion));
                    command.Parameters.Add(new SqlParameter("@disponibilidad", movilidad.disponibilidad));
                    command.ExecuteNonQuery();
                }
            }
            return Obtener(movilidad.codigo);
        }

        public int Eliminar(int codigo)
        {
            var query = "DELETE FROM Movilidad WHERE codigo = @codigo";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@codigo", codigo));
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<Movilidad> Listar()
        {
            var movilidades = new List<Movilidad>();
            var query = "SELECT * FROM Movilidad";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movilidades.Add(new Movilidad()
                            {
                                id = (int)reader["id"],
                                codigo = (int)reader["codigo"],
                                tipoMovilidad = (int)reader["tipoMovilidad"],
                                numeroPasajeros = (int)reader["numeroPasajeros"],
                                costoPorTramo = (decimal)reader["costoPorTramo"],
                                descripcion = reader["descripcion"].ToString(),
                                disponibilidad = (bool)reader["disponibilidad"]
                            });
                        }
                    }
                }
            }
            return movilidades; 
        }
    }
}