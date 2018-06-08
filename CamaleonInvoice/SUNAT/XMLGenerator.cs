namespace CamaleonInvoice.SUNAT
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CamaleonInvoice.Properties;
    using OpenInvoicePeru.Comun.Dto.Intercambio;
    using OpenInvoicePeru.Comun.Dto.Modelos;
    using OpenInvoicePeru.Datos;
    using OpenInvoicePeru.Firmado;
    using OpenInvoicePeru.Xml;
    using Microsoft.Practices.Unity;

    public class XMLGenerator
    {
        private DocumentoElectronico documento2;

        public DocumentoElectronico GenerateDocumentFromIttmove(int moveId)
        {
            Contribuyente emisor = new Contribuyente()
            {
                Departamento = Settings.Default.emDepartamento,
                Direccion = Settings.Default.emDireccion,
                Distrito = Settings.Default.emDistrito,
                NombreComercial = Settings.Default.emNombreComercial,
                NombreLegal = Settings.Default.emNombreLegal,
                NroDocumento = Settings.Default.emRUC,
                Provincia = Settings.Default.emProvincia,
                Ubigeo = Settings.Default.emUbigeo,
                Urbanizacion = Settings.Default.emUrbanizacion,
                TipoDocumento = "01",//TIPO DE DOCUMENTO
            };

            Contribuyente receptor = new Contribuyente()
            {
                Departamento = "",
                Direccion = "",
                Distrito = "",
                NombreComercial = "",
                NombreLegal = "",
                NroDocumento = "",
                Provincia = "",
                Ubigeo = "",
                Urbanizacion = "",
                TipoDocumento = "",//TIPO DE DOCUMENTO
            };

            List<DetalleDocumento> detaMoves = new List<DetalleDocumento>();

            DetalleDocumento deta = new DetalleDocumento()
            {
                Id = 1,
                CodigoItem = "",
                Descripcion = "",
                PrecioUnitario = 1.0m,
                PrecioReferencial = 1.0m,
                TipoPrecio = "Precio Incluye IGV",
                Cantidad = 1.0m,
                UnidadMedida = "",
                Descuento = 10.0m,
                Impuesto = 1.0m, //IGV
                TipoImpuesto = "Operacion Algo",
                ImpuestoSelectivo = 1.0m, //ISC
                OtroImpuesto = 1.0m,
                TotalVenta = 100.0m,
                Suma = 100.0m, // precio unitario * cantidad
            };

            detaMoves.Add(deta);

            DocumentoElectronico documento = new DocumentoElectronico()
            {
                TipoDocumento = "01",
                CalculoIgv = 1.0m,
                CalculoIsc = 1.0m,
                CalculoDetraccion = 1.0m,
                Emisor = emisor,
                Receptor = receptor,

                IdDocumento = "FF11-00001",
                FechaEmision = "2018-04-25",
                Moneda = "PEN",
                TipoOperacion = "10",
                MontoEnLetras = Extensions.ToText("100.25", false),
                MontoPercepcion = 1.0m,
                MontoDetraccion = 12.0m,

                Items = detaMoves,

                Gravadas = 1.0m,
                Exoneradas = 1.0m,
                Inafectas = 1.0m,
                Gratuitas = 1.0m,

                TotalIgv = 18.0m,
                TotalIsc = 1.0m,
                TotalOtrosTributos = 1.0m,
                TotalVenta = 100.0m,
            };

            return documento;
        }

        public XMLGenerator()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
            GenerarFactura gen = new GenerarFactura();
            //documento2 = GenerateDocumentFromIttmove(123);
            //
            //Console.WriteLine(asd);
            //documento2 = GetCamaleon.GetDocumentoFromMove(43166);
            //string asd = gen.Create(documento2);
            //FirmadoRequest des = new FirmadoRequest()
            //{
            //    TramaXmlSinFirma = asd,
            //    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.sunatCertPath)),
            //    PasswordCertificado = Settings.Default.sunatCertPass,
            //    UnSoloNodoExtension = false
            //};

            //FirmadoResponse res = Certificador.FirmarXml(des);

            //File.WriteAllBytes($"XMLFirmado\\" + documento2.IdDocumento + ".xml",
            //                    Convert.FromBase64String(res.TramaXmlFirmado));
        }
    }
}