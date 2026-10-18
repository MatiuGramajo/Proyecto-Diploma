using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_FICHA_TECNICA : MAPPER<BE.FICHA_TECNICA>
    {
        public void RegistrarDetallesyActualizarEstado(BE.FICHA_TECNICA datosFicha)
        {
            acceso.Abrir();

            // PRIMER ESCRIBIR(): Guardar la cabecera de la ficha técnica[cite: 9]
            List<SqlParameter> paramFicha = new List<SqlParameter>();
            paramFicha.Add(acceso.CrearParametro("@Id_Reserva", datosFicha.Id_Reserva));
            paramFicha.Add(acceso.CrearParametro("@Cantidad_Invitados_Final", datosFicha.Cantidad_Invitados_Final));
            paramFicha.Add(acceso.CrearParametro("@Tipo_Evento", datosFicha.Tipo_Evento));

            // Asumimos que este SP no devuelve ID para mantener el void() del diagrama
            acceso.Escribir("INSERTAR_FICHA_TECNICA", paramFicha);

            // SEGUNDO ESCRIBIR(): Iterar e insertar proveedores / actualizar estados[cite: 9]
            foreach (var proveedor in datosFicha.ProveedoresAsignados)
            {
                List<SqlParameter> paramProv = new List<SqlParameter>();
                paramProv.Add(acceso.CrearParametro("@Id_Ficha", datosFicha.Id_Ficha));
                paramProv.Add(acceso.CrearParametro("@Id_Proveedor", proveedor.Id_Proveedor));

                acceso.Escribir("ASIGNAR_PROVEEDOR_FICHA", paramProv);
            }

            acceso.Cerrar();
        }
        public override void Alta(FICHA_TECNICA obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(FICHA_TECNICA obj)
        {
            throw new NotImplementedException();
        }

        public override List<FICHA_TECNICA> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(FICHA_TECNICA obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(FICHA_TECNICA obj)
        {
            throw new NotImplementedException();
        }
    }
}
