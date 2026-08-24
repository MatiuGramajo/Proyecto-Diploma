using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PERMISO
    {
        DAL.MP_PERMISO mapperPermiso = new DAL.MP_PERMISO();

        public void GuardarComponente(BE.COMPONENTE componente)
        {
            mapperPermiso.Alta(componente);
        }

        public void Modificar(BE.COMPONENTE componente)
        {
            mapperPermiso.Modificar(componente);
        }

        public void Baja(BE.COMPONENTE componente)
        {
            if (!componente.EsCompuesto)
            {
                throw new Exception("Por seguridad del sistema, no se pueden eliminar las acciones base, solo los roles.");
            }
            if (mapperPermiso.ValidarRolEnUso(componente.Id))
            {
                throw new Exception("Acción denegada: Hay usuarios que tienen este rol asignado. Desvincule a los usuarios primero.");
            }

            mapperPermiso.Baja(componente);
        }
        public void GuardarRelacion(BE.COMPONENTE padre, BE.COMPONENTE hijo)
        {
            try
            {
                if (padre.Id == hijo.Id)
                {
                    throw new Exception("Un componente no puede ser hijo de sí mismo.");
                }
                if (padre.TienePermiso(hijo.Nombre))
                {
                    throw new Exception("Este componente ya existe dentro del rol");
                }
                if (ExisteReferenciaCircular(padre.Id, hijo.Id))
                {
                    throw new Exception("Asignar este rol generaría una referencia circular infinita.");
                }
                padre.AgregarHijo(hijo);
                
                mapperPermiso.GuardarRelacion(padre.Id, hijo.Id);

            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        private bool ExisteReferenciaCircular(int idPadreDestino, int idHijoAAgregar)
        {
            DataTable tablaRelaciones = mapperPermiso.ObtenerTablaRelacionesAuxiliar();
            return BuscarCicloRecursivo(idHijoAAgregar, idPadreDestino, tablaRelaciones);
        }

        private bool BuscarCicloRecursivo(int idActual, int idBuscado, DataTable relaciones)
        {
            var hijos = from DataRow fila in relaciones.Rows
                        where int.Parse(fila["Id_Padre"].ToString()) == idActual
                        select int.Parse(fila["Id_Hijo"].ToString());

            foreach (int idHijo in hijos)
            {
                if (idHijo == idBuscado)
                {
                    return true;
                }
                if (BuscarCicloRecursivo(idHijo, idBuscado, relaciones))
                {
                    return true;
                }
            }

            return false;
        }

        public void BorrarRelacion(BE.COMPONENTE padre, BE.COMPONENTE hijo)
        {
            try
            {
                padre.BorrarHijo(hijo);
                mapperPermiso.BorrarRelacion(padre.Id, hijo.Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        


        public List<BE.COMPONENTE> Listar()
        {
            return mapperPermiso.Listar();
        }

        public List<BE.COMPONENTE> ObtenerArbolCompleto()
        {
            List<BE.COMPONENTE> todosLosPermisos = mapperPermiso.Listar();
            DataTable tablaRelaciones = mapperPermiso.ObtenerTablaRelacionesAuxiliar();
            foreach (var nodo in todosLosPermisos)
            {
                var filasHijos = from DataRow fila in tablaRelaciones.Rows
                                 where int.Parse(fila["Id_Padre"].ToString()) == nodo.Id
                                 select fila;

                foreach (DataRow fila in filasHijos)
                {
                    int idHijo = int.Parse(fila["Id_Hijo"].ToString());

                    BE.COMPONENTE hijoEncontrado = (from p in todosLosPermisos
                                                    where p.Id == idHijo
                                                    select p).FirstOrDefault();

                    if (hijoEncontrado != null)
                    {
                        nodo.AgregarHijo(hijoEncontrado);
                    }
                }
            }

            List<BE.COMPONENTE> raices = new List<BE.COMPONENTE>();
            foreach (var p in todosLosPermisos)
            {
                bool esHijoDeAlguien = (from DataRow fila in tablaRelaciones.Rows
                                        where int.Parse(fila["Id_Hijo"].ToString()) == p.Id
                                        select fila).Any();

                if (!esHijoDeAlguien)
                {
                    raices.Add(p);
                }
            }

            return raices;

        }

        public List<BE.COMPONENTE> ObtenerPermisosUsuario(int idUsuario)
        {
            List<int> idsAsignados = mapperPermiso.ObtenerIdsPermisosUsuario(idUsuario);

            List<BE.COMPONENTE> permisosDelUsuario = new List<BE.COMPONENTE>();

            if (idsAsignados.Count == 0) return permisosDelUsuario;

            List<BE.COMPONENTE> todosLosPermisos = mapperPermiso.Listar();
            DataTable tablaRelaciones = mapperPermiso.ObtenerTablaRelacionesAuxiliar();

            foreach (var nodo in todosLosPermisos)
            {
                var filasHijos = from DataRow fila in tablaRelaciones.Rows
                                 where int.Parse(fila["Id_Padre"].ToString()) == nodo.Id
                                 select fila;
                foreach (DataRow fila in filasHijos)
                {
                    int idHijo = int.Parse(fila["Id_Hijo"].ToString());
                    BE.COMPONENTE hijo = todosLosPermisos.Find(p => p.Id == idHijo);

                    if (hijo != null)
                    {
                        nodo.AgregarHijo(hijo);
                    }
                }
            }

            foreach (int id in idsAsignados)
            {
                BE.COMPONENTE componenteAsignado = todosLosPermisos.Find(p => p.Id == id);
                if (componenteAsignado != null)
                {
                    permisosDelUsuario.Add(componenteAsignado);
                }
            }

            return permisosDelUsuario;
        }
    }
}
