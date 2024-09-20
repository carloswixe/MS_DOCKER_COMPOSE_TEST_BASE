using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NET_TEST_BASE_WCF
{
    [ServiceContract]
    public interface IPagosService
    {
        [OperationContract]
        bool RegistrarPago(string concepto, int cantidadProductos, int idOrdenante, int idBeneficiario, decimal montoTotal); [OperationContract]
        List<Pago> ListarPagos();

        [OperationContract]
        Pago ConsultarPagoPorId(int idPago);

        [OperationContract]
        string ModificarEstatusPago(int idPago, string nuevoEstatus);
    }
}
