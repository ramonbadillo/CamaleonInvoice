namespace CamaleonInvoice.SUNAT
{
    using System;
    using System.Threading.Tasks;
    using OpenInvoicePeru.Comun.Dto.Intercambio;
    using OpenInvoicePeru.Comun.Dto.Modelos;
    using OpenInvoicePeru.Firmado;
    using OpenInvoicePeru.Xml;
    using Unity;
    using Microsoft.Practices.Unity;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;

    public class GenerarFactura
    {
        public string RutaArchivo { get; set; }

        public GenerarFactura()
        {
        }

        public string Create(DocumentoElectronico documento)
        {
            string resultado = "";
            try
            {
                var invoice = CFacturaXml.Generar(documento);
                var serializer = new XmlSerializer(invoice.GetType());

                using (var memStr = new MemoryStream())
                {
                    using (var stream = new StreamWriter(memStr))
                    {
                        serializer.Serialize(stream, invoice);
                    }
                    resultado = Convert.ToBase64String(memStr.ToArray());
                }

                RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                        documento.IdDocumento + ".xml");

                File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(resultado));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }
    }
}