using System.Collections.Generic;
using System.Data.SqlClient;
using WCFMember.Dominio;

namespace WCFMember.Persistencia
{
    public class MiembroDAO
    {
        private string connectionString = @"Data Source=LTPVASS019\SQLEXPRESS;Initial Catalog=Miembros;Integrated Security=True";
        //private string connectionString = "Server=JAIME-PC;Database=Miembros;User ID=JaimePC;pwd=face15PIER";

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
                                Correo = reader["Correo"].ToString(),
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

        public Miembro ObtenerPorDniYContrasena(string dni, string contrasena)
        {
            var query = "select * from Miembro where (dni = @dni and Contrasena = @Contrasena)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@dni", dni));
                    command.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

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
                                Correo = reader["Correo"].ToString(),
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
            var query = "insert into Miembro (Nombres, Ape_Paterno, Ape_Materno, Dni, Edad, Correo, Contrasena, Activo) values (@Nombres, @Ape_Paterno, @Ape_Materno, @Dni, @Edad, @Correo, @Contrasena, @Activo)";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Nombres", miembro.Nombres));
                    command.Parameters.Add(new SqlParameter("@Ape_Paterno", miembro.ApellidoPaterno));
                    command.Parameters.Add(new SqlParameter("@Ape_Materno", miembro.ApellidoMaterno));
                    command.Parameters.Add(new SqlParameter("@Dni", miembro.Dni));
                    command.Parameters.Add(new SqlParameter("@Edad", miembro.Edad));
                    command.Parameters.Add(new SqlParameter("@Correo", miembro.Correo));
                    command.Parameters.Add(new SqlParameter("@Contrasena", miembro.Password));
                    command.Parameters.Add(new SqlParameter("@Activo", 1));
                    command.ExecuteNonQuery();
                }
            }

            return Obtener(miembro.Dni);
        }

        public Miembro Modificar(Miembro miembro)
        {
            var query = "UPDATE Miembro SET Nombres = @nombres, Ape_Paterno = @ape_paterno, Ape_Materno = @ape_materno, Edad = @edad, Correo = @correo, Activo = @activo WHERE Dni = @dni";
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
                    command.Parameters.Add(new SqlParameter("@correo", miembro.Correo));
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
                                Correo = reader["Correo"].ToString(),
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