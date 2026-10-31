using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RECETARIO
    {
        private DAL.MP_RECETARIO mpRecetario = new DAL.MP_RECETARIO();
        private DAL.MP_SERVICIO_CATERING mpServicioCatering = new DAL.MP_SERVICIO_CATERING();
        private DAL.MP_INSUMO mpInsumo = new DAL.MP_INSUMO();
        public (List<BE.SERVICIO_CATERING> servicios, List<BE.INSUMO> insumos) ObtenerDatosIniciales()
        {
            List<BE.SERVICIO_CATERING> servicios = mpServicioCatering.Listar();
            List<BE.INSUMO> insumos = mpInsumo.Listar();

            return (servicios, insumos);
        }
        public List<BE.DETALLE_RECETARIO> ObtenerRecetarioPorServicio(int idServicio)
        {
            return mpRecetario.LeerRecetarioPorServicio(idServicio);
        }
        public void GuardarRecetario(int idServicio, List<BE.DETALLE_RECETARIO> listaDetalles)
        {
            mpRecetario.EliminarPorServicio(idServicio);

            foreach (BE.DETALLE_RECETARIO detalle in listaDetalles)
            {
                detalle.Id_Servicio = idServicio;
                mpRecetario.Alta(detalle);
            }
        }
    }
}
