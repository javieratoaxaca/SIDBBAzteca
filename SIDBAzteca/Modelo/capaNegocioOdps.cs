using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIDBAzteca.Config;
using SIDBAzteca.Data;
using System.Data;

namespace SIDBAzteca.Modelo
{
    class capaNegocioOdps:ConexionBD
    {
        public capaNegocioOdps() { }

        //Metodo para que muestre las Odps que tiene asignado el Becario
        public capaDatosOdps getDatosOdpsCurp(string curp)
        {

            var cdDatosOdpsBecarios = new capaDatosOdps();

            try
            {
                var Query = $"SELECT * FROM odpimp where curpBecario LIKE '{curp}' ";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosOdpsBecarios.AnioOperativo = Int32.Parse(dr["anioOperativo"].ToString());
                    cdDatosOdpsBecarios.FolioFormato = dr["folioFormato"].ToString();
                    cdDatosOdpsBecarios.FolioFormatoConsecutivo = dr["folioFormatoConsecutivo"].ToString();
                    cdDatosOdpsBecarios.IdCita = dr["idCita"].ToString();
                    cdDatosOdpsBecarios.CurpBecario = dr["curpBecario"].ToString();
                    cdDatosOdpsBecarios.Periodo = dr["periodo"].ToString();
                    cdDatosOdpsBecarios.Remesa = dr["remesa"].ToString();
                    cdDatosOdpsBecarios.Programa = dr["programa"].ToString();
                    cdDatosOdpsBecarios.UsuarioImpresion = dr["usuarioImpresion"].ToString();
                    cdDatosOdpsBecarios.FechaImpresion = dr["fechaImpresion"].ToString();
                    cdDatosOdpsBecarios.UsuarioReImpresion = dr["usuarioReImpresion"].ToString();
                    cdDatosOdpsBecarios.FechaReImpresion = dr["fechaReImpresion"].ToString();
                    cdDatosOdpsBecarios.ExpFormato1 = dr["expFormato1"].ToString();
                    cdDatosOdpsBecarios.ExpFormato2 = dr["expFormato2"].ToString();
                    cdDatosOdpsBecarios.ExpFormato3 = dr["expFormato3"].ToString();
                    cdDatosOdpsBecarios.ExpFormato4 = dr["expFormato4"].ToString();
                    cdDatosOdpsBecarios.ExpFormato5 = dr["expFormato5"].ToString();
                    cdDatosOdpsBecarios.ExpFormato6 = dr["expFormato6"].ToString();
                    cdDatosOdpsBecarios.ExpFormato7 = dr["expFormato7"].ToString();
                    cdDatosOdpsBecarios.ExpFormato8 = dr["expFormato8"].ToString();
                    cdDatosOdpsBecarios.ExpFormato9 = dr["expFormato9"].ToString();
                    cdDatosOdpsBecarios.ExpFormato10 = dr["expFormato10"].ToString();

                    cdDatosOdpsBecarios.AtencionFicha = dr["atencionFicha"].ToString();
                    cdDatosOdpsBecarios.FolioFichAtencion = dr["folioFichAtencion"].ToString();
                

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosOdpsBecarios;
        }
        //Metodo para que muestre los datos de la Odp del Becario
        public capaDatosOdps getDatosOdpsBecario(string folioformato)
        {

            var cdDatosOdpsBecarios = new capaDatosOdps();

            try
            {
                var Query = $"SELECT * FROM odpimp where folioFormato LIKE '{folioformato}' and estadoFolioFormatoExp='0'";
                var dr = GetDataReader(Query);
                while (dr.Read())
                {
                    cdDatosOdpsBecarios.AnioOperativo = Int32.Parse(dr["anioOperativo"].ToString());
                    cdDatosOdpsBecarios.FolioFormato = dr["folioFormato"].ToString();
                    cdDatosOdpsBecarios.FolioFormatoConsecutivo = dr["folioFormatoConsecutivo"].ToString();
                    cdDatosOdpsBecarios.IdCita = dr["idCita"].ToString();
                    cdDatosOdpsBecarios.CurpBecario = dr["curpBecario"].ToString();
                    cdDatosOdpsBecarios.Periodo = dr["periodo"].ToString();
                    cdDatosOdpsBecarios.Remesa = dr["remesa"].ToString();
                    cdDatosOdpsBecarios.Programa = dr["programa"].ToString();
                    cdDatosOdpsBecarios.UsuarioImpresion = dr["usuarioImpresion"].ToString();
                    cdDatosOdpsBecarios.FechaImpresion = dr["fechaImpresion"].ToString();
                    cdDatosOdpsBecarios.UsuarioReImpresion = dr["usuarioReImpresion"].ToString();
                    cdDatosOdpsBecarios.FechaReImpresion = dr["fechaReImpresion"].ToString();
                    cdDatosOdpsBecarios.ExpFormato1 = dr["expFormato1"].ToString();
                    cdDatosOdpsBecarios.ExpFormato2 = dr["expFormato2"].ToString();
                    cdDatosOdpsBecarios.ExpFormato3 = dr["expFormato3"].ToString();
                    cdDatosOdpsBecarios.ExpFormato4 = dr["expFormato4"].ToString();
                    cdDatosOdpsBecarios.ExpFormato5 = dr["expFormato5"].ToString();
                    cdDatosOdpsBecarios.ExpFormato6 = dr["expFormato6"].ToString();
                    cdDatosOdpsBecarios.ExpFormato7 = dr["expFormato7"].ToString();
                    cdDatosOdpsBecarios.ExpFormato8 = dr["expFormato8"].ToString();
                    cdDatosOdpsBecarios.ExpFormato9 = dr["expFormato9"].ToString();
                    cdDatosOdpsBecarios.ExpFormato10 = dr["expFormato10"].ToString();

                    cdDatosOdpsBecarios.AtencionFicha = dr["atencionFicha"].ToString();
                    cdDatosOdpsBecarios.FolioFichAtencion = dr["folioFichAtencion"].ToString();


                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return cdDatosOdpsBecarios;
        }

        //Metodo para Actualizar la Documentacion de la ODP del BECARIO
        public bool updateOdpBecario(capaDatosOdps dtOdpBecario)
        {
            string Query = string.Format("UPDATE odpimp SET atencionFicha='{0}',folioFichAtencion='{1}',expFormato1='{2}',expFormato2='{3}',expFormato3='{4}',expFormato4='{5}',expFormato5='{6}',expFormato6='{7}', expFormato7='{8}', expFormato8='{9}',estadoFolioFormatoExp='{10}' WHERE curpBecario='{11}' and folioFormato='{12}'",
                dtOdpBecario.AtencionFicha,
                dtOdpBecario.FolioFichAtencion,
                dtOdpBecario.ExpFormato1,
                dtOdpBecario.ExpFormato2,
                dtOdpBecario.ExpFormato3,
                dtOdpBecario.ExpFormato4,
                dtOdpBecario.ExpFormato5,
                dtOdpBecario.ExpFormato6,
                dtOdpBecario.ExpFormato7,
                dtOdpBecario.ExpFormato8,
                dtOdpBecario.EstadoFolioFormatoExp,
                dtOdpBecario.CurpBecario,
                dtOdpBecario.FolioFormato);
            try
            {
                var result = ExecuteQuery(Query);
                if (result > 0)

                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
    }
}
