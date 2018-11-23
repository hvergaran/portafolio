using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace CapaNegocio
{
    public class CN_Contratos
    {
        //Encapsular variables
        private CD_Contratos objDato = new CD_Contratos();//instancia a la capa datos de empleado

        public CN_Contratos() { }
        //FUNCIONES O METODOS

        public DataTable MostrarContratos()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
        public void InsertarContrato(string fechaInc, string fechaMeta, string montoMeta, string fechaFinal,string montoActual,string idColegio,string idUsuario,string idEstado)
        {

            objDato.Insertar(fechaInc, fechaMeta, Convert.ToInt32(montoMeta), fechaFinal, Convert.ToInt32(montoActual), Convert.ToInt32(idColegio), Convert.ToInt32(idUsuario), Convert.ToInt32(idEstado));
        }

        public void EditarContrato(string id,string fechaInc, string fechaMeta, string montoMeta, string fechaFinal, string montoActual, string idColegio, string idUsuario, string idEstado)
        {
            objDato.Editar(Convert.ToInt32(id), fechaInc, fechaMeta, Convert.ToInt32(montoMeta), fechaFinal, Convert.ToInt32(montoActual), Convert.ToInt32(idColegio), Convert.ToInt32(idUsuario), Convert.ToInt32(idEstado));
        }

        public void EliminarContrato(string id)
        {

            objDato.Eliminar(Convert.ToInt32(id));
        }

    }
}
