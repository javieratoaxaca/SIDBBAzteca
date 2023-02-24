using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIDBAzteca.Modelo;
using SIDBAzteca.Data;
using SIDBAzteca.Config;

namespace SIDBAzteca.Vista
{
    public partial class frmBecarios : Form
    {
        readonly capaNegocioBecarios cmBecarios;
        readonly capaNegocioOdps cmOdpsBecarios;
        readonly capaNegocioExpediente cmExpedienteBecarios;
        readonly capaDatosBecarios cdBecario ;
        readonly capaDatosOdps cdOdpsBecarios;
        readonly ConexionBD cnx;

        string fechaExpediente = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        string Expediente_fecha = "";
        string lblFolioFormatoString = "";
        string lblCurpBecarioString = "";
        string statusFolioFormatoExp ="1";
        public frmBecarios()
        {
            InitializeComponent();
            cmBecarios = new capaNegocioBecarios();
            cmOdpsBecarios = new capaNegocioOdps();
            cmExpedienteBecarios = new capaNegocioExpediente();
            cdBecario = new capaDatosBecarios();
            cdOdpsBecarios = new capaDatosOdps();
            cnx = new ConexionBD();
        }

        private void frmBecarios_Load(object sender, EventArgs e)
        {
            cnx.GetConnection();
            //cargarBecarios();
            dtgvExpediente.Columns.Add("expediente","Expediente");
            dtgvExpediente.Columns.Add("folioformato", "Folio_Formato");
            dtgvExpediente.Columns.Add("fechaexpediente", "Fecha_Expediente");
           
        }

        private void btnSearchAvanzada_Click(object sender, EventArgs e)
        {
            var cdBecario = new capaDatosBecarios();

            if (string.IsNullOrEmpty(txtSearchCurp.Text))
            {
                //var result = OLMessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cargarBecarios();
                //MessageBox.Show("Datos No Encontrados,\n Por Favor de Ingresar Curp o Nombre Tutora", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblRegion.Text = "";
            }
            else
            {
                
                cmBecarios.CargarGridBuscarCurp(dtgvBecarios, txtSearchCurp.Text);
                cdBecario = cmBecarios.getDatosBecario(txtSearchCurp.Text);
                txtCveLocalidad.Text = cdBecario.CveLocalidad;
                txtMunicipio.Text = cdBecario.Municipio;
                txtLocalidad.Text = cdBecario.Localidad;
                txtIdRegion.Text = cdBecario.IdRegion;
                txtRegion.Text = cdBecario.NombreRegion;
                txtIdSare.Text = cdBecario.IdSare;
                txtSare.Text = cdBecario.NombreSare;
                txtCveMun.Text = cdBecario.CveMun;
                txtCveLoc.Text = cdBecario.CveLoc;
                txtNombreCompleto.Text= cdBecario.NombreCompleto;
                txtCurpBecario.Text = cdBecario.CurpBecario;
                txtCct.Text = cdBecario.Cct;
                txtNameCct.Text = cdBecario.NombreCct;
                //txtIdCita.Text = cdBecario.id;
                //txtRemesa.Text = cdBecario;
                //txtPeriodo.Text=cdBecario;



                //cmDatosTerritoriales.CargarGridBuscar(dtgvListadoTutora, txtSearchNameFull.Text);
                //lblFamiliaId.Text = dtgvListadoTutora.CurrentRow.Cells[0].Value.ToString();

            }

        }

        private void cargarBecarios()
        {
            cmBecarios.CargarGridBuscar(dtgvBecarios);
        }

        private void subPnlContentIncorporaciones_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void dtgvBecarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cdOdpsBecarios = new capaDatosOdps();

            lblFolioFormato.Text= dtgvBecarios.CurrentRow.Cells[1].Value.ToString();
            lblCurp.Text = dtgvBecarios.CurrentRow.Cells[0].Value.ToString();
            lblFolioFormatoString = lblFolioFormato.Text.ToString();
            lblCurpBecarioString = lblCurp.Text;
            cdOdpsBecarios = cmOdpsBecarios.getDatosOdpsBecario(lblFolioFormato.Text);
            txtDoc1.Text = cdOdpsBecarios.ExpFormato1;
            txtDoc2.Text = cdOdpsBecarios.ExpFormato2;
            txtDoc3.Text = cdOdpsBecarios.ExpFormato3;
            txtDoc4.Text = cdOdpsBecarios.ExpFormato4;
            txtDoc5.Text = cdOdpsBecarios.ExpFormato5;
            txtDoc6.Text = cdOdpsBecarios.ExpFormato6;
            txtDoc7.Text = cdOdpsBecarios.ExpFormato7;
            txtDoc8.Text = cdOdpsBecarios.ExpFormato8;
            txtDocFicha.Text= cdOdpsBecarios.AtencionFicha;
            txtFolioFicha.Text=cdOdpsBecarios.FolioFichAtencion;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            habilitarExpedientes();
            
        }

        private void habilitarExpedientes()
        {
            txtDoc1.Enabled = true;
            txtDoc2.Enabled = true;
            txtDoc3.Enabled = true;
            txtDoc4.Enabled = true;
            txtDoc5.Enabled = true;
            txtDoc6.Enabled = true;
            txtDoc7.Enabled = true;
            txtDoc8.Enabled = true;
            txtDocFicha.Enabled = true;
            txtFolioFicha.Enabled = true;
            btnGuardarExpediente.Enabled = true;
            dtgvExpediente.Enabled = true;
            btnGenerarExpediente.Enabled = false;
            btnAgregarExp.Enabled = true;
        }

        private void deshabilitarExpedientes()
        {
            txtDoc1.Enabled = false;
            txtDoc2.Enabled = false;
            txtDoc3.Enabled = false;
            txtDoc4.Enabled = false;
            txtDoc5.Enabled = false;
            txtDoc6.Enabled = false;
            txtDoc7.Enabled = false;
            txtDoc8.Enabled = false;
            txtDocFicha.Enabled = false;
            txtFolioFicha.Enabled = false;
            btnGuardarExpediente.Enabled = false;
            dtgvExpediente.Enabled = false;
            btnGenerarExpediente.Enabled = true;
            btnAgregarExp.Enabled = false;
        }

        private void limpiarcajas()
        {
            txtDoc1.Text = "";
            txtDoc2.Text = "";
            txtDoc3.Text = "";
            txtDoc4.Text = "";
            txtDoc5.Text = "";
            txtDoc6.Text = "";
            txtDoc7.Text = "";
            txtDoc8.Text = "";
            txtDocFicha.Text = "";
            txtFolioFicha.Text = "";
            dtgvExpediente.Rows.Clear();
            btnGenerarExpediente.Enabled = true;
        }

        private void btnGuardarExpediente_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarExp_Click(object sender, EventArgs e)
        {
            string fechaExpediente2 = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            //string Expediente_fecha = "";
            saveOdpBecario();
            Expediente_fecha = lblCurpBecarioString + "-" + fechaExpediente;
            dtgvExpediente.Rows.Add(Expediente_fecha, lblFolioFormatoString, fechaExpediente2);
            cmBecarios.CargarGridBuscarCurp(dtgvBecarios, txtSearchCurp.Text);

        }

        private void btnGuardarExpediente_Click_1(object sender, EventArgs e)
        {

            EnviarExpediente();
            deshabilitarExpedientes();
            limpiarcajas();
        }

        //Metodo para enviar los datos al modelo para la tabla de Expediente
        private void EnviarExpediente()
        {

            capaDatosExpediente dtExpedienteBecario = new capaDatosExpediente();
            capaNegocioExpediente smCapturaExpediente = new capaNegocioExpediente();
            //ModeloOrdenPago smOrdenPago = new ModeloOrdenPago();

            try
            {
                for (int i = 0; i <= dtgvExpediente.RowCount; i++)
                {
                    dtExpedienteBecario.CveExpediente= dtgvExpediente.Rows[i].Cells[0].Value.ToString();
                    dtExpedienteBecario.FolioFormato = dtgvExpediente.Rows[i].Cells[1].Value.ToString();
                    dtExpedienteBecario.FechaExpediente = dtgvExpediente.Rows[i].Cells[2].Value.ToString();

                    smCapturaExpediente.setExpedienteCapturaBecario(dtExpedienteBecario);
                }
                bool resultado = smCapturaExpediente.Procesar();
                MessageBox.Show(resultado ? "Se guardaron exitosamente" : "Error al guardar los datos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Metodo que guarda los datos en la Tabla de Region de la BD
        private void saveOdpBecario()
        {
            var cdOdpsBecarios = new capaDatosOdps();

            try
            {
                cdOdpsBecarios.AtencionFicha = txtDocFicha.Text.ToString();
                cdOdpsBecarios.FolioFichAtencion = txtFolioFicha.Text;
                cdOdpsBecarios.ExpFormato1 = txtDoc1.Text;
                cdOdpsBecarios.ExpFormato2 = txtDoc2.Text;
                cdOdpsBecarios.ExpFormato3 = txtDoc3.Text;
                cdOdpsBecarios.ExpFormato4 = txtDoc4.Text;
                cdOdpsBecarios.ExpFormato5 = txtDoc5.Text;
                cdOdpsBecarios.ExpFormato6 = txtDoc6.Text;
                cdOdpsBecarios.ExpFormato7 = txtDoc7.Text;
                cdOdpsBecarios.ExpFormato8 = txtDoc8.Text;
                cdOdpsBecarios.CurpBecario = lblCurp.Text;
                cdOdpsBecarios.FolioFormato = lblFolioFormato.Text;
                cdOdpsBecarios.EstadoFolioFormatoExp = statusFolioFormatoExp;


                if (cmOdpsBecarios.updateOdpBecario(cdOdpsBecarios))
                {
                    MessageBox.Show("Se Actualizacion Exitosamente");
                    //mdlRegion.llenarGrid(dtgvRegiones);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dtgvBecarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
