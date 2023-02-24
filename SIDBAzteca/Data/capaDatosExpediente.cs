using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDBAzteca.Data
{
    class capaDatosExpediente
    {
       private int idExpediente;
       private string cveExpediente;
       private string folioFormato;
       private string fechaExpediente;

        public int IdExpediente
        {
            get
            {
                return idExpediente;
            }

            set
            {
                idExpediente = value;
            }
        }

        public string CveExpediente
        {
            get
            {
                return cveExpediente;
            }

            set
            {
                cveExpediente = value;
            }
        }

        public string FolioFormato
        {
            get
            {
                return folioFormato;
            }

            set
            {
                folioFormato = value;
            }
        }

        public string FechaExpediente
        {
            get
            {
                return fechaExpediente;
            }

            set
            {
                fechaExpediente = value;
            }
        }
    }
}
