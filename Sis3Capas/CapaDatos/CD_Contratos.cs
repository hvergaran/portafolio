using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace CapaDatos
{
    public class CD_Contratos
    {
        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        System.Data.DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();


        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from contrato");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string fechaInc, string fechaMeta, int montoMeta, string fechaFinal, int montoActual, int idColegio, int idUsuario, int idEstado)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into contrato(id_contrato,fecha_incorporacion,fecha_meta,monto_meta,fecha_final,monto_actual_contrato,colegio_id_colegio,fk_id_usuario,fk_id_estado_contrato)" +
                " values(CONTRATO_SEQ.nextval,TO_DATE(:fechaInc, 'DD/MM/YYYY'),TO_DATE(:fechaMeta, 'DD/MM/YYYY'),:montoMeta,TO_DATE(:fechaFinal, 'DD/MM/YYYY'),:montoActual,:idColegio,:idUsuario,:idEstado)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":fechaInc", fechaInc);
            comando.Parameters.Add(":fechaMeta", fechaMeta);
            comando.Parameters.Add(":montoMeta", montoMeta);
            comando.Parameters.Add(":fechaFinal", fechaFinal);
            comando.Parameters.Add(":montoActual", montoActual);
            comando.Parameters.Add(":idColegio", idColegio);
            comando.Parameters.Add(":idUsuario", idUsuario);
            comando.Parameters.Add(":idEstado", idEstado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

           /* OracleCommand comando = new OracleCommand("insert into contrato(id_contrato,fecha_incorporacion,fecha_meta,monto_meta,fecha_final,monto_actual_contrato,colegio_id_colegio,fk_id_usuario,fk_id_estado_contrato)" +
                " values(5,TO_DATE(:fechaInc, 'DD/MM/YYYY HH24:MI:SS'),TO_DATE(:fechaMeta, 'DD/MM/YYYY HH24:MI:SS'),:montoMeta,TO_DATE(:fechaFinal, 'DD/MM/YYYY HH24:MI:SS'),:montoActual,:idColegio,:idUsuario,:idEstado)");
            */

        }

        public void Editar(int id,string fechaInc, string fechaMeta, int montoMeta, string fechaFinal, int montoActual, int idColegio, int idUsuario, int idEstado)
        {


            OracleCommand comando = new OracleCommand("update contrato set FECHA_INCORPORACION=TO_DATE(:fechaInc, 'DD/MM/YYYY'),FECHA_META=TO_DATE(:fechaMeta, 'DD/MM/YYYY'),MONTO_META=:montoMeta,FECHA_FINAL=TO_DATE(:fechaFinal, 'DD/MM/YYYY'),MONTO_ACTUAL_CONTRATO=:montoActual,COLEGIO_ID_COLEGIO=:idColegio,FK_ID_USUARIO=:idUsuario,FK_ID_ESTADO_CONTRATO=:idEstado where ID_CONTRATO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":fechaInc", fechaInc);
            comando.Parameters.Add(":fechaMeta", fechaMeta);
            comando.Parameters.Add(":montoMeta", montoMeta);
            comando.Parameters.Add(":fechaFinal", fechaFinal);
            comando.Parameters.Add(":montoActual", montoActual);
            comando.Parameters.Add(":idColegio", idColegio);
            comando.Parameters.Add(":idUsuario", idUsuario);
            comando.Parameters.Add(":idEstado", idEstado);
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from colegio where id_colegio=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}

