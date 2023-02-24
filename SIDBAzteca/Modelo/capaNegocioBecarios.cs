using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIDBAzteca.Config;
using SIDBAzteca.Data;
using System.Data;

namespace SIDBAzteca.Modelo
{
    class capaNegocioBecarios : ConexionBD
    {
        public capaNegocioBecarios() { }


        /*Metodo para Buscar los datos a la base de datos*/

        public capaDatosBecarios getDatosBecario(string curp)
        {

            var cdDatosBecarios = new capaDatosBecarios();

            try
            {
                var Query = $"SELECT * FROM nominal where curpBecario LIKE '{curp}' limit 1";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosBecarios.IdSare = dr["idSare"].ToString();
                    cdDatosBecarios.NombreSare = dr["nombreSare"].ToString();
                    cdDatosBecarios.IdRegion = dr["idRegion"].ToString(); 
                    cdDatosBecarios.NombreRegion = dr["nombreRegion"].ToString();
                    cdDatosBecarios.CveLocalidad = dr["cveLocalidad"].ToString();
                    cdDatosBecarios.Cct = dr["cct"].ToString();
                    cdDatosBecarios.NombreCct = dr["nombreCct"].ToString();
                    cdDatosBecarios.CveMun = dr["cveMun"].ToString();
                    cdDatosBecarios.Municipio = dr["municipio"].ToString();
                    cdDatosBecarios.CveLoc = dr["cveLoc"].ToString();
                    cdDatosBecarios.Localidad = dr["localidad"].ToString();
                    cdDatosBecarios.CurpBecario = dr["curpBecario"].ToString();
                    cdDatosBecarios.NombreCompleto = dr["nombreCompleto"].ToString();
                    cdDatosBecarios.NombreBecario = dr["nombreBecario"].ToString();
                    cdDatosBecarios.APBecario = dr["aPBecario"].ToString();
                    cdDatosBecarios.AMBecario = dr["aMBecario"].ToString();

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosBecarios;
        }



        //Metodo para cargar el DataGridView con el dato a buscar en el total de los Registros de la Tabla de estructterritorial
        public void CargarGridBuscarCurp(DataGridView grid,string txtBuscar)
        {
            try
            {
               
                var query = $"SELECT B.curpBecario,B.folioFormato,A.cct FROM nominal as A, odpimp as B  where A.curpBecario = B.curpBecario and B.curpBecario='{txtBuscar}' and B.estadoFolioFormatoExp='0' GROUP BY A.cct,B.curpBecario , B.folioFormato;";//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                var cmd = new MySqlCommand(query, GetConnection());

                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void CargarGridBuscar(DataGridView grid)
        {
            try
            {

                var query = $"SELECT folioFormato,curpBecario,nombreCompleto,cct,nombreCct,periodo,remesa,fechaImpresion FROM nominal";//creamos la consulta a la base 
                //creamos el cmd para que se lleve el query y cargue la conexion con la DB
                var cmd = new MySqlCommand(query, GetConnection());

                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
