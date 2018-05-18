using CamaleonInvoice.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using OpenInvoicePeru.Comun.Dto.Modelos;
using System.Data;
using System.Windows.Forms;

namespace CamaleonInvoice
{
    public static class GetCamaleon
    {
        /*
        public static List<DetalleDocumento> GetDetalleFromMove(int moveId)
        {
            List<DetalleDocumento> DetallesToRetrieve = new List<DetalleDocumento>();

            MySqlConnection connection = null;

            connection = new MySqlConnection(ConnectionConfig.connectionString);
            Console.WriteLine(ConnectionConfig.connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " +
                                  "it_tdetamove.Move_Deta_ITEM_ID,   " +
                                  "it_titem.ITEM_Sale_Price,  " +
                                  "it_titem.ITEM_Description,    " +
                                  "it_tdetamove.Move_Deta_price,  " +
                                  "it_tdetamove.Move_Deta_price,  " +
                                  "it_tdetamove.Move_Deta_Q, " +
                                  "it_tunit.UNIT_Name,  " +
                                  //"# Cosas para sacar el descuento " +
                                  "it_tdetamove.On_Sale, " +
                                  "it_tdetamove.Discount_Code, " +
                                  "it_tdetamove.Move_REG_price, " +
                                  //"# it_tdetamove.Move_Deta_price - it_tdetamove.Move_REG_price " +
                                  "it_tdetamove.Move_Deta_Tax_Value, " +
                                  "it_tdetamove.Move_Deta_Tax2_Value,  " +
                                  "(it_tdetamove.Move_Deta_Q * it_titem.ITEM_Sale_Price) AS 'Total', " +
                                  "(it_tdetamove.Move_Deta_Q * it_titem.ITEM_Sale_Price) -it_tdetamove.Move_Deta_Tax_Value-it_tdetamove.Move_Deta_Tax2_Value AS 'Suma' " +
                                  "FROM it_tdetamove " +
                                  "INNER JOIN it_titem ON it_tdetamove.Move_Deta_ITEM_ID = it_titem.ITEM_ID " +
                                  "INNER JOIN it_tunit ON it_tunit.UNIT_ID = it_titem.ITEM_Unit_ID " +
                                  "WHERE  it_tdetamove.modi = 0 " +
                                  "AND it_tdetamove.Subitem_of = 0 " +
                                  "AND it_tdetamove.Move_Deta_Move_ID = " + moveId + ";";
            MySqlDataReader Reader;
            Console.WriteLine(command.CommandText);
            connection.Open();
            Reader = command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                string Move_Deta_ID = Reader.GetString("Move_Deta_ITEM_ID");
                string Descripcion = Reader.GetString("ITEM_Description");
                decimal PrecioUnitario = Reader.GetInt32("Move_Deta_price");
                decimal PrecioReferencial = Reader.GetInt32("Move_Deta_price");
                decimal Cantidad = Reader.GetInt32("Move_Deta_Q");
                string UnidadMedida = Reader.GetString("UNIT_Name");
                //AQUI CALCULA
                decimal Descuento = Reader.GetInt32("Move_Deta_Q");

                decimal Impuesto = Reader.GetInt32("Move_Deta_Tax_Value");
                decimal OtroImpuesto = Reader.GetInt32("Move_Deta_Tax2_Value");
                decimal TotalVenta = Reader.GetInt32("Total");
                decimal Suma = Reader.GetInt32("Suma");

                DetalleDocumento deta = new DetalleDocumento()
                {
                    Id = i++,
                    CodigoItem = Move_Deta_ID,
                    Descripcion = Descripcion,
                    PrecioUnitario = PrecioUnitario,
                    PrecioReferencial = PrecioReferencial,
                    TipoPrecio = "01: Precio unitario Incluye IGV",
                    Cantidad = Cantidad,

                    UnidadMedida = UnidadMedida,
                    Descuento = Descuento,
                    Impuesto = Impuesto, //IGV
                    TipoImpuesto = "10: Gravado - Operación Onerosa",
                    //ImpuestoSelectivo = 1.0m, //ISC
                    OtroImpuesto = OtroImpuesto, // RC
                    TotalVenta = TotalVenta,
                    Suma = Suma, // precio unitario * cantidad
                };
                DetallesToRetrieve.Add(deta);
            }

            Reader.Close();

            return DetallesToRetrieve;
        }*/

        public static List<DetalleDocumento> GetDETFromMove(int moveId)
        {
            List<DetalleDocumento> DetallesToRetrieve = new List<DetalleDocumento>();

            MySqlConnection connection = null;

            connection = new MySqlConnection(ConnectionConfig.connectionString);
            Console.WriteLine(ConnectionConfig.connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " +
                                  "it_tdetamove.Move_Deta_ITEM_ID,   " +
                                  "it_titem.ITEM_Sale_Price,  " +
                                  "it_titem.ITEM_Description,    " +
                                  "it_tdetamove.Move_Deta_price,  " +
                                  "it_tdetamove.Move_Deta_price,  " +
                                  "it_tdetamove.Move_Deta_Q, " +
                                  "it_tunit.UNIT_Name,  " +
                                  //"# Cosas para sacar el descuento " +
                                  "it_tdetamove.On_Sale, " +
                                  "it_tdetamove.Discount_Code, " +
                                  "it_tdetamove.Move_REG_price, " +
                                  //"# it_tdetamove.Move_Deta_price - it_tdetamove.Move_REG_price " +
                                  "it_tdetamove.Move_Deta_Tax_Value, " +
                                  "it_tdetamove.Move_Deta_Tax2_Value,  " +
                                  "(it_tdetamove.Move_Deta_Q * it_titem.ITEM_Sale_Price) AS 'Total', " +
                                  "(it_tdetamove.Move_Deta_Q * it_titem.ITEM_Sale_Price) -it_tdetamove.Move_Deta_Tax_Value-it_tdetamove.Move_Deta_Tax2_Value AS 'Suma' " +
                                  "FROM it_tdetamove " +
                                  "INNER JOIN it_titem ON it_tdetamove.Move_Deta_ITEM_ID = it_titem.ITEM_ID " +
                                  "INNER JOIN it_tunit ON it_tunit.UNIT_ID = it_titem.ITEM_Unit_ID " +
                                  "WHERE  it_tdetamove.modi = 0 " +
                                  "AND it_tdetamove.Subitem_of = 0 " +
                                  "AND it_tdetamove.Move_Deta_Move_ID = " + moveId + ";";
            MySqlDataReader Reader;
            Console.WriteLine(command.CommandText);
            connection.Open();
            Reader = command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                string Move_Deta_ID = Reader.GetString("Move_Deta_ITEM_ID");
                string Descripcion = Reader.GetString("ITEM_Description");
                decimal PrecioUnitario = Reader.GetInt32("Move_Deta_price");
                decimal PrecioReferencial = Reader.GetInt32("Move_Deta_price");
                decimal Cantidad = Reader.GetInt32("Move_Deta_Q");
                string UnidadMedida = Reader.GetString("UNIT_Name");
                //AQUI CALCULA
                decimal Descuento = Reader.GetInt32("Move_Deta_Q");

                decimal Impuesto = Reader.GetInt32("Move_Deta_Tax_Value");
                decimal OtroImpuesto = Reader.GetInt32("Move_Deta_Tax2_Value");
                decimal TotalVenta = Reader.GetInt32("Total");
                decimal Suma = Reader.GetInt32("Suma");

                DetalleDocumento deta = new DetalleDocumento()
                {
                    Id = i++,
                    CodigoItem = Move_Deta_ID,
                    Descripcion = Descripcion,
                    PrecioUnitario = PrecioUnitario,
                    PrecioReferencial = PrecioReferencial,
                    TipoPrecio = "01: Precio unitario Incluye IGV",
                    Cantidad = Cantidad,

                    UnidadMedida = UnidadMedida,
                    Descuento = Descuento,
                    Impuesto = Impuesto, //IGV
                    TipoImpuesto = "10: Gravado - Operación Onerosa",
                    //ImpuestoSelectivo = 1.0m, //ISC
                    OtroImpuesto = OtroImpuesto, // RC
                    TotalVenta = TotalVenta,
                    Suma = Suma, // precio unitario * cantidad
                };
                DetallesToRetrieve.Add(deta);
            }

            Reader.Close();

            return DetallesToRetrieve;
        }

        public static DocumentoElectronico GetDocumentoFromMove(int moveId)
        {
            DocumentoElectronico documento = new DocumentoElectronico();

            Contribuyente emisor = new Contribuyente();

            Contribuyente receptor = new Contribuyente();

            MySqlConnection connection = null;

            connection = new MySqlConnection(ConnectionConfig.connectionString);
            Console.WriteLine(ConnectionConfig.connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " +
                                    "it_tmove.Docu_type_ID AS 'TipoDocumento', " +
                                    //Receptor
                                    "fl_tcustomer.TaxExemptNo, " +
                                    "fl_tcustomer.SS_NO, " +
                                    "idtypes.Codigo AS 'Tipo_Doc_Receptor', " +
                                    "Company_Name, " +
                                    "Cust_name, " +
                                    "it_tmove.Move_wic_Value, " +
                                    "it_tmove.Money_Conv, " +
                                    "it_tmove.Ticket_count AS 'IdDocumento', " +
                                    "it_tmove.Move_Date AS 'FechaEmision', " +
                                    "SUM(it_tdetamove.Move_Deta_Tax_Value) AS 'TotalIgv', " +
                                    "SUM(it_tdetamove.Move_Deta_Tax2_Value) AS 'TotalIsc', " +
                                    "SUM((it_tdetamove.Move_Deta_Q * it_tdetamove.Move_Deta_price)) AS 'TotalVenta' " +
                                    "FROM it_tmove " +
                                    "LEFT JOIN fl_tcustomer ON it_tmove.Cust_Id = fl_tcustomer.Cust_ID " +
                                    "INNER JOIN it_tdetamove ON it_tdetamove.Move_Deta_Move_ID = it_tmove.Move_ID " +
                                    "LEFT JOIN idtypes ON idtypes.TYPE_ID =  fl_tcustomer.IDType " +
                                    "WHERE it_tmove.Move_ID = " + moveId + " " +
                                    "GROUP BY NULL;";
            MySqlDataReader Reader;
            Console.WriteLine(command.CommandText);
            connection.Open();
            Reader = command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                string TipoDocumento = Reader.GetString("TipoDocumento");
                string TaxExemptNo = Reader.GetString("TaxExemptNo");
                string SS_NO = Reader.GetString("SS_NO");
                string Tipo_Doc_Receptor = Reader.GetString("Tipo_Doc_Receptor");
                string Company_Name = Reader.GetString("Company_Name");
                string Cust_name = Reader.GetString("Cust_name");

                decimal PrecioUnitario = HelpersDatabase.GetInt(Reader, "Move_wic_Value");
                decimal Money_Conv = HelpersDatabase.GetInt(Reader, "Money_Conv");
                string IdDocumento = HelpersDatabase.GetString(Reader, "IdDocumento");
                string FechaEmision = HelpersDatabase.GetDate(Reader, "FechaEmision");

                decimal TotalIgv = Reader.GetInt32("TotalIgv");
                decimal TotalIsc = Reader.GetInt32("TotalIsc");
                decimal TotalVenta = Reader.GetInt32("TotalVenta");

                string NombreLegal;
                string NroDocumento;
                if (string.IsNullOrEmpty(Company_Name) && string.IsNullOrEmpty(TaxExemptNo))
                {
                    NombreLegal = Cust_name;
                    NroDocumento = SS_NO;
                }
                else
                {
                    NombreLegal = Company_Name;
                    NroDocumento = TaxExemptNo;
                }

                string Moneda;
                if (PrecioUnitario == 0 && Money_Conv == 0)
                    Moneda = "PEN";
                else
                {
                    Moneda = "USD";
                }

                emisor = new Contribuyente()
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
                    TipoDocumento = TipoDocumento,//TIPO DE DOCUMENTO
                };

                receptor = new Contribuyente()
                {
                    //Departamento = "",
                    //Direccion = "",
                    //Distrito = "",
                    //NombreComercial = "",
                    NombreLegal = NombreLegal,
                    NroDocumento = NroDocumento,
                    //Provincia = "",
                    //Ubigeo = "",
                    //Urbanizacion = "",
                    TipoDocumento = Tipo_Doc_Receptor,//TIPO DE DOCUMENTO
                };

                documento = new DocumentoElectronico()
                {
                    TipoDocumento = TipoDocumento,
                    CalculoIgv = 0.18m,
                    CalculoIsc = 0.10m,
                    CalculoDetraccion = 0.04m,
                    Emisor = emisor,
                    Receptor = receptor,

                    IdDocumento = IdDocumento,
                    FechaEmision = FechaEmision,
                    Moneda = Moneda,
                    TipoOperacion = "10",
                    MontoEnLetras = Extensions.ToText(TotalVenta.ToString(), false),
                    //MontoPercepcion = 1.0m,
                    //MontoDetraccion = 12.0m,

                    Items = GetDETFromMove(moveId),

                    Gravadas = TotalVenta,
                    //Exoneradas = 1.0m,
                    //Inafectas = 1.0m,
                    //Gratuitas = 1.0m,

                    TotalIgv = TotalIgv,
                    TotalIsc = TotalIsc,
                    //TotalOtrosTributos = 1.0m,
                    TotalVenta = TotalVenta,
                };
            }

            Reader.Close();

            return documento;
        }

        /*
        public static DocumentoElectronico GetDocumentoFromMove(int moveId)
        {
            DocumentoElectronico documento = new DocumentoElectronico();

            Contribuyente emisor = new Contribuyente();

            Contribuyente receptor = new Contribuyente();

            MySqlConnection connection = null;

            connection = new MySqlConnection(ConnectionConfig.connectionString);
            Console.WriteLine(ConnectionConfig.connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " +
                                    "it_tmove.Docu_type_ID AS 'TipoDocumento', " +
                                    //Receptor
                                    "fl_tcustomer.TaxExemptNo, " +
                                    "fl_tcustomer.SS_NO, " +
                                    "idtypes.Codigo AS 'Tipo_Doc_Receptor', " +
                                    "Company_Name, " +
                                    "Cust_name, " +
                                    "it_tmove.Move_wic_Value, " +
                                    "it_tmove.Money_Conv, " +
                                    "it_tmove.Ticket_count AS 'IdDocumento', " +
                                    "it_tmove.Move_Date AS 'FechaEmision', " +
                                    "SUM(it_tdetamove.Move_Deta_Tax_Value) AS 'TotalIgv', " +
                                    "SUM(it_tdetamove.Move_Deta_Tax2_Value) AS 'TotalIsc', " +
                                    "SUM((it_tdetamove.Move_Deta_Q * it_tdetamove.Move_Deta_price)) AS 'TotalVenta' " +
                                    "FROM it_tmove " +
                                    "LEFT JOIN fl_tcustomer ON it_tmove.Cust_Id = fl_tcustomer.Cust_ID " +
                                    "INNER JOIN it_tdetamove ON it_tdetamove.Move_Deta_Move_ID = it_tmove.Move_ID " +
                                    "LEFT JOIN idtypes ON idtypes.TYPE_ID =  fl_tcustomer.IDType " +
                                    "WHERE it_tmove.Move_ID = " + moveId + " " +
                                    "GROUP BY NULL;";
            MySqlDataReader Reader;
            Console.WriteLine(command.CommandText);
            connection.Open();
            Reader = command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                string TipoDocumento = Reader.GetString("TipoDocumento");
                string TaxExemptNo = Reader.GetString("TaxExemptNo");
                string SS_NO = Reader.GetString("SS_NO");
                string Tipo_Doc_Receptor = Reader.GetString("Tipo_Doc_Receptor");
                string Company_Name = Reader.GetString("Company_Name");
                string Cust_name = Reader.GetString("Cust_name");

                decimal PrecioUnitario = HelpersDatabase.GetInt(Reader, "Move_wic_Value");
                decimal Money_Conv = HelpersDatabase.GetInt(Reader, "Money_Conv");
                string IdDocumento = HelpersDatabase.GetString(Reader, "IdDocumento");
                string FechaEmision = HelpersDatabase.GetDate(Reader, "FechaEmision");

                decimal TotalIgv = Reader.GetInt32("TotalIgv");
                decimal TotalIsc = Reader.GetInt32("TotalIsc");
                decimal TotalVenta = Reader.GetInt32("TotalVenta");

                string NombreLegal;
                string NroDocumento;
                if (string.IsNullOrEmpty(Company_Name) && string.IsNullOrEmpty(TaxExemptNo))
                {
                    NombreLegal = Cust_name;
                    NroDocumento = SS_NO;
                }
                else
                {
                    NombreLegal = Company_Name;
                    NroDocumento = TaxExemptNo;
                }

                string Moneda;
                if (PrecioUnitario == 0 && Money_Conv == 0)
                    Moneda = "PEN";
                else
                {
                    Moneda = "USD";
                }

                emisor = new Contribuyente()
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
                    TipoDocumento = TipoDocumento,//TIPO DE DOCUMENTO
                };

                receptor = new Contribuyente()
                {
                    //Departamento = "",
                    //Direccion = "",
                    //Distrito = "",
                    //NombreComercial = "",
                    NombreLegal = NombreLegal,
                    NroDocumento = NroDocumento,
                    //Provincia = "",
                    //Ubigeo = "",
                    //Urbanizacion = "",
                    TipoDocumento = Tipo_Doc_Receptor,//TIPO DE DOCUMENTO
                };

                documento = new DocumentoElectronico()
                {
                    TipoDocumento = TipoDocumento,
                    CalculoIgv = 0.18m,
                    CalculoIsc = 0.10m,
                    CalculoDetraccion = 0.04m,
                    Emisor = emisor,
                    Receptor = receptor,

                    IdDocumento = IdDocumento,
                    FechaEmision = FechaEmision,
                    Moneda = Moneda,
                    TipoOperacion = "10",
                    MontoEnLetras = Extensions.ToText(TotalVenta.ToString(), false),
                    //MontoPercepcion = 1.0m,
                    //MontoDetraccion = 12.0m,

                    Items = GetDETFromMove(moveId),

                    Gravadas = TotalVenta,
                    //Exoneradas = 1.0m,
                    //Inafectas = 1.0m,
                    //Gratuitas = 1.0m,

                    TotalIgv = TotalIgv,
                    TotalIsc = TotalIsc,
                    //TotalOtrosTributos = 1.0m,
                    TotalVenta = TotalVenta,
                };
            }

            Reader.Close();

            return documento;
        }

    */
    }
}