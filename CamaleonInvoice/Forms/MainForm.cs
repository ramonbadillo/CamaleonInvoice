namespace CamaleonInvoice
{
    using CamaleonInvoice.Properties;
    using OpenInvoicePeru.Comun.Dto.Intercambio;
    using OpenInvoicePeru.Comun.Dto.Modelos;
    using OpenInvoicePeru.Datos;
    using OpenInvoicePeru.Entidades;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Windows.Forms;

    using OpenInvoicePeru.Comun.Dto.Modelos;

    using System.Collections.Generic;
    using OpenInvoicePeru.Servicio;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.LoadConfig();
        }

        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Seleccione el certificado";
                    ofd.Filter = "Certificados Digitales (*.cer;*.pfx;*.p7b)|*.cer;*.pfx;*.p7b";
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtCertPath.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            var consultaTicketRequest = new ConsultaTicketRequest
            {
                Ruc = txtRUC.Text,
                UsuarioSol = txtUsuarioSol.Text,
                ClaveSol = txtClaveSol.Text,
                EndPointUrl = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService",
                IdDocumento = txtNoDoc.Text
            };
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ConnectionConfig.GetDataBases(cbDatabase, txtServer.Text, txtPort.Text, txtUser.Text, txtPass.Text))
            {
                cbDatabase.Enabled = true;

                //btnSave.Enabled = true;
            }
        }

        public CamaleonInvoice.SUNAT.XMLGenerator myGenerator = new CamaleonInvoice.SUNAT.XMLGenerator();

        private void btnHide_Click(object sender, EventArgs e)
        {
            //List<DetalleDocumento> detalles = GetCamaleon.GetDetalleFromMove(1242);
            GetCamaleon.GetDocumentoFromMove(10);
            //MessageBox.Show(detalles[0].Descripcion);
            //MessageBox.Show(Conversores.NumeroALetras(25.35m));
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            //// FIRMADO TAB
            Settings.Default.sunatUsuarioSOL = txtUsuarioSol.Text;
            Settings.Default.sunatClaveSOL = txtClaveSol.Text;
            Settings.Default.sunatCertPath = txtCertPath.Text;
            Settings.Default.sunatCertPass = txtPassCert.Text;
            Settings.Default.sunatEndPoint = txtSunatEndPoint.Text;

            //// CAMALEON TAB
            Settings.Default.localServer = txtServer.Text;
            Settings.Default.localPort = txtPort.Text;
            Settings.Default.localUser = txtUser.Text;
            Settings.Default.localPassword = txtPass.Text;
            Settings.Default.localDatabase = cbDatabase.Text;

            //// EMISOR TAB
            Settings.Default.emRUC = txtRUC.Text;
            Settings.Default.emNombreLegal = txtNombreLegal.Text;
            Settings.Default.emNombreComercial = txtNombreComercial.Text;
            Settings.Default.emUrbanizacion = txtUrbanizacion.Text;
            Settings.Default.emDepartamento = txtDepartamento.Text;
            Settings.Default.emProvincia = txtProvincia.Text;
            Settings.Default.emDistrito = txtDistrito.Text;
            Settings.Default.emUbigeo = txtUbigeo.Text;

            Settings.Default.Save();
            lblDatabase.Text = cbDatabase.Text;

            MessageBox.Show("Configuracion Guardada");
        }

        private void LoadConfig()
        {
            //// FIRMADO TAB
            txtUsuarioSol.Text = Settings.Default.sunatUsuarioSOL;
            txtClaveSol.Text = Settings.Default.sunatClaveSOL;
            txtCertPath.Text = Settings.Default.sunatCertPath;
            txtPassCert.Text = Settings.Default.sunatCertPass;
            txtSunatEndPoint.Text = Settings.Default.sunatEndPoint;

            //// CAMALEON TAB
            txtServer.Text = Settings.Default.localServer;
            txtPort.Text = Settings.Default.localPort;
            txtUser.Text = Settings.Default.localUser;
            txtPass.Text = Settings.Default.localPassword;
            cbDatabase.Text = Settings.Default.localDatabase;

            //// EMISOR TAB
            txtRUC.Text = Settings.Default.emRUC;
            txtNombreLegal.Text = Settings.Default.emNombreLegal;
            txtNombreComercial.Text = Settings.Default.emNombreComercial;
            txtDireccion.Text = Settings.Default.emNombreComercial;
            txtUrbanizacion.Text = Settings.Default.emUrbanizacion;
            txtDepartamento.Text = Settings.Default.emDepartamento;
            txtProvincia.Text = Settings.Default.emProvincia;
            txtDistrito.Text = Settings.Default.emDistrito;
            txtUbigeo.Text = Settings.Default.emUbigeo;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnGenerateXML_Click(object sender, EventArgs e)
        {
        }

        private void btnSignXML_Click(object sender, EventArgs e)
        {
        }

        private void btnGetStatus_Click_1(object sender, EventArgs e)
        {
            SUNAT.CheckStatusDocumentos checar = new SUNAT.CheckStatusDocumentos(
                new ParametrosConexion
                {
                    Ruc = Settings.Default.emRUC,
                    UserName = Settings.Default.sunatUsuarioSOL,
                    Password = Settings.Default.sunatClaveSOL,
                    EndPointUrl = Settings.Default.sunatEndPoint
                }
            );

            var resultado = checar.ConsultarTicket(txtNoDoc.Text);

            Console.WriteLine(resultado.ConstanciaDeRecepcion);
            Console.WriteLine(resultado.Exito);
            Console.WriteLine(resultado.MensajeError);
        }
    }
}