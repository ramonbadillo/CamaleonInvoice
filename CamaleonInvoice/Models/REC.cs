namespace CamaleonInvoice.Models
{
    public class REC
    {
        public string tipoDocId { get; set; }
        public string numeroDocId { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; } //F
        public string provincia { get; set; } //F
        public string distrito { get; set; } //F
        public string codigoPais { get; set; }
        public string telefono { get; set; } //F
        public string correoElectronico { get; set; } //F
    }
}