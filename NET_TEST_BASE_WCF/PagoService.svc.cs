using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NET_TEST_BASE_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IPagosService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PagosDB"].ConnectionString;

        public Pago ConsultarPagoPorId(int idPago)
        {
            Pago pago = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Pagos WHERE Id = @IdPago";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPago", idPago);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            pago = new Pago
                            {
                                Id = (int)reader["Id"],
                                Concepto = reader["Concepto"].ToString(),
                                CantidadProductos = (int)reader["CantidadProductos"],
                                OrdenanteId = (int)reader["OrdenanteId"],
                                BeneficiarioId = (int)reader["BeneficiarioId"],
                                MontoTotal = (decimal)reader["MontoTotal"],
                                Estatus = reader["Estatus"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Manejar la excepción
            }

            return pago;
        }

        public List<Pago> ListarPagos()
        {
            List<Pago> pagos = new List<Pago>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Pagos";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Pago pago = new Pago
                            {
                                Id = (int)reader["Id"],
                                Concepto = reader["Concepto"].ToString(),
                                CantidadProductos = (int)reader["CantidadProductos"],
                                OrdenanteId = (int)reader["OrdenanteId"],
                                BeneficiarioId = (int)reader["BeneficiarioId"],
                                MontoTotal = (decimal)reader["MontoTotal"],
                                Estatus = reader["Estatus"].ToString()
                            };
                            pagos.Add(pago);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Manejar la excepción
            }

            return pagos;
        }

        public string ModificarEstatusPago(int idPago, string nuevoEstatus)
        {
            try
            {
                var listaestatuspermitidos = new List<string>();
                listaestatuspermitidos.Add(Estatuspermitidos.Pendiente.ToString().ToLower());
                listaestatuspermitidos.Add(Estatuspermitidos.Pagado.ToString().ToLower());
                listaestatuspermitidos.Add(Estatuspermitidos.Rechazado.ToString().ToLower());
                if (listaestatuspermitidos.Contains(nuevoEstatus.ToLower()))
                {

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Pagos SET Estatus = @NuevoEstatus WHERE Id = @IdPago";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NuevoEstatus", nuevoEstatus);
                            cmd.Parameters.AddWithValue("@IdPago", idPago);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            return rowsAffected > 0 ? "OK" : "Exeption";
                        }
                    }
                }
                else
                {
                    return "El estatus enviado no es permitido, utilice uno de los estatus permitidos:  Pendiente, Pagado, Rechazado";
                }
            }
            catch (Exception)
            {
                return "Exeption";
            }
        }

        public bool RegistrarPago(string concepto, int cantidadProductos, int OrdenanteId, int BeneficiarioId, decimal montoTotal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Pagos (Concepto, CantidadProductos, OrdenanteId, BeneficiarioId, MontoTotal, Estatus) " +
                                   "VALUES (@Concepto, @CantidadProductos, @OrdenanteId, @BeneficiarioId, @MontoTotal, @Estatus)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Concepto", concepto);
                        cmd.Parameters.AddWithValue("@CantidadProductos", cantidadProductos);
                        cmd.Parameters.AddWithValue("@OrdenanteId", OrdenanteId);
                        cmd.Parameters.AddWithValue("@BeneficiarioId", BeneficiarioId);
                        cmd.Parameters.AddWithValue("@MontoTotal", montoTotal);
                        cmd.Parameters.AddWithValue("@Estatus", Estatuspermitidos.Pendiente.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
