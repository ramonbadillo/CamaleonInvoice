namespace CamaleonInvoice
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

    public class XMLGenerator
    {
        private DocumentoElectronico documento2;

        //private readonly IDocumentoXml _documentoXml;
        //private readonly ISerializador _serializador;

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
                TipoDocumento = "",//TIPO DE DOCUMENTO
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
                TipoPrecio = "",
                Cantidad = 1.0m,
                UnidadMedida = "",
                Descuento = 10.0m,
                Impuesto = 1.0m, //IGV
                TipoImpuesto = "",
                ImpuestoSelectivo = 1.0m, //ISC
                OtroImpuesto = 1.0m,
                TotalVenta = 100.0m,
                Suma = 100.0m, // precio unitario * cantidad
            };

            detaMoves.Add(deta);

            DocumentoElectronico documento = new DocumentoElectronico()
            {
                TotalVenta = 100.0M,
                TotalIgv = 18.0M,
                Moneda = "PEN",
                Emisor = emisor,
                Receptor = receptor,
                Items = detaMoves,

                FechaEmision = "",
                Gravadas = 20.0M,

                MontoEnLetras = Extensions.ToText("100.25", false),
            };

            return documento;
        }

        public XMLGenerator()
        {
            /*
            documento2 = GenerateDocumentFromIttmove(123);

            var invoice = _documentoXml.Generar(documento2);
            var response = new DocumentoResponse();
            var task = Task.Run(async () => await _serializador.GenerarXml(invoice));
            response.TramaXmlSinFirma = task.Result;
            */
        }
    }
}