using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIDBAzteca.Config;
//using System.Windows.Forms;
using SIDBAzteca.Data;
using System.Data;

namespace SIDBAzteca.Modelo
{
    class capaNegocioExpediente : ConexionBD
    {
        public capaNegocioExpediente() { }
        private string _addSQL;



        public bool setExpedienteCapturaBecario(capaDatosExpediente dtExpedienteCaptura)
        {
            // string respuesta = dtApdmCapturaOdp.Respuesta.Replace("'","");
            string Query = string.Format("INSERT INTO expediente(cveExpediente,folioFormato,fechaExpediente)VALUES('{0}','{1}','{2}')",
                                         dtExpedienteCaptura.CveExpediente, dtExpedienteCaptura.FolioFormato, dtExpedienteCaptura.FechaExpediente);
            try
            {
                int result = ExecuteQuery(Query);
                if (result > 0)
                    return true;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return false;
        }






        public string AddSQL
        {
            get
            {
                return _addSQL;
            }
            set
            {
                _addSQL = value;

            }
        }
        public bool Procesar()
        {
            try
            {
                var result = ExecuteQuery(AddSQL);
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
