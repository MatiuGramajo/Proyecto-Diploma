using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class REQUERIMIENTO
    {

        private DAL.MP_RESERVA mpReserva = new DAL.MP_RESERVA();
        private DAL.MP_RECETARIO mpRecetario = new DAL.MP_RECETARIO();
        private DAL.MP_INSUMO mpInsumo = new DAL.MP_INSUMO();
        private DAL.MP_FICHA_TECNICA mpFichaTecnica = new DAL.MP_FICHA_TECNICA();

        public List<BE.REQUERIMIENTO_INSUMO> CalcularRequerimientos(DateTime? fechaDesde, DateTime? fechaHasta, int idReserva)
        {
            List<BE.RESERVA> reservasPlanificadas = mpReserva.ListarEventosPlanificados(fechaDesde, fechaHasta);

            if (idReserva > 0)
            {
                reservasPlanificadas = reservasPlanificadas.Where(r => r.Id_Reserva == idReserva).ToList();
            }

            if (reservasPlanificadas == null || reservasPlanificadas.Count == 0)
            {
                throw new Exception("Sin eventos planificados");
            }

            List<(BE.RESERVA reserva, List<BE.DETALLE_RECETARIO> receta, int comensales)> datosEventos =
                new List<(BE.RESERVA, List<BE.DETALLE_RECETARIO>, int)>();

            foreach (BE.RESERVA reserva in reservasPlanificadas)
            {
                // Obtenemos la Ficha Técnica real del evento
                BE.FICHA_TECNICA ficha = mpFichaTecnica.ObtenerPorReserva(reserva.Id_Reserva);

                if (ficha == null)
                {
                    throw new Exception("Menu sin Recetario");
                }

                // Obtenemos el recetario según el Servicio de Catering real de la Ficha Técnica
                List<BE.DETALLE_RECETARIO> receta = mpRecetario.LeerRecetarioPorServicio(ficha.Id_Servicio);

                if (receta == null || receta.Count == 0)
                {
                    throw new Exception("Menu sin Recetario");
                }

                // Usamos la cantidad de invitados real guardada en la Ficha Técnica
                int cantidadComensales = ficha.Cantidad_Invitados_Final;

                datosEventos.Add((reserva, receta, cantidadComensales));
            }

            List<BE.INSUMO> listaInsumos = mpInsumo.ListarInsumos();

            return ConsolidarDemantaYCalcularFaltantes(datosEventos, listaInsumos);
        }

        private List<BE.REQUERIMIENTO_INSUMO> ConsolidarDemantaYCalcularFaltantes(
            List<(BE.RESERVA reserva, List<BE.DETALLE_RECETARIO> receta, int comensales)> datosEventos,
            List<BE.INSUMO> listaInsumos)
        {
            Dictionary<int, decimal> demandaAcumulada = new Dictionary<int, decimal>();

            foreach (var item in datosEventos)
            {
                int cantidadComensales = item.comensales;

                foreach (BE.DETALLE_RECETARIO detalle in item.receta)
                {
                    decimal cantidadTotalInsumo = detalle.Cantidad_Por_Persona * cantidadComensales;

                    if (demandaAcumulada.ContainsKey(detalle.Id_Insumo))
                    {
                        demandaAcumulada[detalle.Id_Insumo] += cantidadTotalInsumo;
                    }
                    else
                    {
                        demandaAcumulada.Add(detalle.Id_Insumo, cantidadTotalInsumo);
                    }
                }
            }

            List<BE.REQUERIMIENTO_INSUMO> resultado = new List<BE.REQUERIMIENTO_INSUMO>();

            foreach (var kvp in demandaAcumulada)
            {
                int idInsumo = kvp.Key;
                decimal requerida = kvp.Value;

                BE.INSUMO insumoBD = listaInsumos.FirstOrDefault(i => i.Id_Insumo == idInsumo);

                if (insumoBD != null)
                {
                    decimal stock = insumoBD.Stock_Actual;
                    decimal faltante = requerida > stock ? (requerida - stock) : 0;

                    resultado.Add(new BE.REQUERIMIENTO_INSUMO
                    {
                        Id_Insumo = insumoBD.Id_Insumo,
                        Nombre_Insumo = insumoBD.Nombre,
                        Rubro = insumoBD.Rubro,
                        Unidad_Medida = insumoBD.Unidad_Medida,
                        Cantidad_Requerida = requerida,
                        Stock_Actual = stock,
                        Cantidad_Faltante = faltante,
                        Estado_Stock = faltante > 0 ? "Faltante" : "Suficiente"
                    });
                }
            }

            return resultado;
        }


    }
    //    private DAL.MP_RESERVA mpReserva = new DAL.MP_RESERVA();
    //    private DAL.MP_RECETARIO mpRecetario = new DAL.MP_RECETARIO();
    //    private DAL.MP_INSUMO mpInsumo = new DAL.MP_INSUMO();
    //    public List<BE.REQUERIMIENTO_INSUMO> CalcularRequerimientos(DateTime? fechaDesde, DateTime? fechaHasta, int idReserva)
    //    {
    //        List<BE.RESERVA> reservasPlanificadas = mpReserva.ListarEventosPlanificados();

    //        if (idReserva > 0)
    //        {
    //            reservasPlanificadas = reservasPlanificadas.Where(r => r.Id_Reserva == idReserva).ToList();
    //        }
    //        else if (fechaDesde.HasValue && fechaHasta.HasValue)
    //        {
    //            reservasPlanificadas = reservasPlanificadas
    //                .Where(r => r.Fecha_Evento.Date >= fechaDesde.Value.Date && r.Fecha_Evento.Date <= fechaHasta.Value.Date)
    //                .ToList();
    //        }

    //        if (reservasPlanificadas == null || reservasPlanificadas.Count == 0)
    //        {
    //            throw new Exception("Sin eventos planificados()");
    //        }

    //        List<(BE.RESERVA reserva, List<BE.DETALLE_RECETARIO> receta)> datosEventos = new List<(BE.RESERVA, List<BE.DETALLE_RECETARIO>)>();

    //        foreach (BE.RESERVA reserva in reservasPlanificadas)
    //        {
    //            int idServicio = reserva.PresupuestoAsociado != null ? reserva.PresupuestoAsociado.Id_Presupuesto : 1;

    //            List<BE.DETALLE_RECETARIO> receta = mpRecetario.LeerRecetarioPorServicio(idServicio);

    //            if (receta == null || receta.Count == 0)
    //            {
    //                throw new Exception("Menu sin Recetario()");
    //            }

    //            datosEventos.Add((reserva, receta));
    //        }

    //        List<BE.INSUMO> listaInsumos = mpInsumo.ListarInsumos();

    //        return ConsolidarDemantaYCalcularFaltantes(datosEventos, listaInsumos);
    //    }

    //    private List<BE.REQUERIMIENTO_INSUMO> ConsolidarDemantaYCalcularFaltantes(
    //        List<(BE.RESERVA reserva, List<BE.DETALLE_RECETARIO> receta)> datosEventos,
    //        List<BE.INSUMO> listaInsumos)
    //    {
    //        Dictionary<int, decimal> demandaAcumulada = new Dictionary<int, decimal>();

    //        foreach (var item in datosEventos)
    //        {
    //            int cantidadComensales = 100;

    //            foreach (BE.DETALLE_RECETARIO detalle in item.receta)
    //            {
    //                decimal cantidadTotalInsumo = detalle.Cantidad_Por_Persona * cantidadComensales;

    //                if (demandaAcumulada.ContainsKey(detalle.Id_Insumo))
    //                {
    //                    demandaAcumulada[detalle.Id_Insumo] += cantidadTotalInsumo;
    //                }
    //                else
    //                {
    //                    demandaAcumulada.Add(detalle.Id_Insumo, cantidadTotalInsumo);
    //                }
    //            }
    //        }

    //        List<BE.REQUERIMIENTO_INSUMO> resultado = new List<BE.REQUERIMIENTO_INSUMO>();

    //        foreach (var kvp in demandaAcumulada)
    //        {
    //            int idInsumo = kvp.Key;
    //            decimal requerida = kvp.Value;

    //            BE.INSUMO insumoBD = listaInsumos.FirstOrDefault(i => i.Id_Insumo == idInsumo);

    //            if (insumoBD != null)
    //            {
    //                decimal stock = insumoBD.Stock_Actual;
    //                decimal faltante = requerida > stock ? (requerida - stock) : 0;

    //                resultado.Add(new BE.REQUERIMIENTO_INSUMO
    //                {
    //                    Id_Insumo = insumoBD.Id_Insumo,
    //                    Nombre_Insumo = insumoBD.Nombre,
    //                    Rubro = insumoBD.Rubro,
    //                    Unidad_Medida = insumoBD.Unidad_Medida,
    //                    Cantidad_Requerida = requerida,
    //                    Stock_Actual = stock,
    //                    Cantidad_Faltante = faltante,
    //                    Estado_Stock = faltante > 0 ? "Faltante" : "Suficiente"
    //                });
    //            }
    //        }

    //        return resultado;
    //    }
    //}

}
