using System.Collections.Generic;
using System.Data.SqlClient;
using WCFMember.Dominio;

namespace WCFMember.Persistencia
{
    public class MiembroDAO
    {
        private string connectionString = "Data Source=.;Initial Catalog=Miembros;Integrated Security=True";

        public Miembro Obtener(string dni)
        {
            var query = "select * from Miembro where dni = @dni";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@dni", dni));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Miembro()
                            {
                                MiembroId = (int)reader["MiembroId"],
                                Nombres = reader["Nombres"].ToString(),
                                ApellidoPaterno = reader["Ape_Paterno"].ToString(),
                                ApellidoMaterno = reader["Ape_Materno"].ToString(),
                                Dni = reader["Dni"].ToString(),
                                Edad = (int)reader["Edad"],
                                Activo = (bool)reader["Activo"]
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

        public Miembro Crear(Miembro miembro)
        {
            var query = "insert into Miembro values (@nombres, @ape_paterno, @ape_materno, @dni, @edad, @activo)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@nombres", miembro.Nombres));
                    command.Parameters.Add(new SqlParameter("@ape_paterno", miembro.ApellidoPaterno));
                    command.Parameters.Add(new SqlParameter("@ape_materno", miembro.ApellidoMaterno));
                    command.Parameters.Add(new SqlParameter("@dni", miembro.Dni));
                    command.Parameters.Add(new SqlParameter("@edad", miembro.Edad));
                    command.Parameters.Add(new SqlParameter("@activo", miembro.Activo));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(miembro.Dni);
        }

        public Miembro Modificar(Miembro miembro)
        {
            var query = "UPDATE Miembro SET Nombres = @nombres, Ape_Paterno = @ape_paterno, Ape_Materno = @ape_materno, Edad = @edad, Activo = @activo WHERE Dni = @dni";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@nombres", miembro.Nombres));
                    command.Parameters.Add(new SqlParameter("@ape_paterno", miembro.ApellidoPaterno));
                    command.Parameters.Add(new SqlParameter("@ape_materno", miembro.ApellidoMaterno));
                    command.Parameters.Add(new SqlParameter("@dni", miembro.Dni));
                    command.Parameters.Add(new SqlParameter("@edad", miembro.Edad));
                    command.Parameters.Add(new SqlParameter("@activo", miembro.Activo));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(miembro.Dni);
        }

        public void Eliminar(string dni)
        {
            var query = "DELETE FROM Miembro WHERE Dni = @dni";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@dni", dni));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Miembro> Listar()
        {
            var miembros = new List<Miembro>();
            var query = "SELECT * FROM Miembro";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            miembros.Add(new Miembro()
                            {
                                MiembroId = (int)reader["MiembroId"],
                                Nombres = reader["Nombres"].ToString(),
                                ApellidoPaterno = reader["Ape_Paterno"].ToString(),
                                ApellidoMaterno = reader["Ape_Materno"].ToString(),
                                Dni = reader["Dni"].ToString(),
                                Edad = (int)reader["Edad"],
                                Activo = (bool)reader["Activo"]
                            });
                        }
                    }

                }
            }

            return miembros;
        }
    }
}