using CamaleonInvoice.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CamaleonInvoice
{
    public static class GetCamaleon
    {
        public static List<it_tmove> GetMovesToSync(int lastId, int limit)
        {
            List<it_tmove> movesToSync = new List<it_tmove>();
            MySqlConnection connection = null;

            connection = new MySqlConnection(ConnectionConfig.connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "  SELECT * FROM it_tmove WHERE Move_ID > " + lastId + " LIMIT " + limit + " ;";
            MySqlDataReader Reader;

            connection.Open();
            Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                int Move_ID = Reader.GetInt32("Move_ID");
                string Ticket_count = HelpersDatabase.GetString(Reader, "Ticket_count");
                int Move_Cust_ID = Reader.GetInt16("Move_Cust_ID");
                int Move_Oper_ID = Reader.GetInt16("Move_Oper_ID");
                string Move_Date = HelpersDatabase.GetDateTime(Reader, "Move_Date");
                string Move_Due_Date = HelpersDatabase.GetDateTime(Reader, "Move_Due_Date");
                string Move_Fiscal_Date = HelpersDatabase.GetDate(Reader, "Move_Fiscal_Date");
                string Driver_time_out = HelpersDatabase.GetDateTime(Reader, "Driver_time_out");
                string Driver_Delivered_Time = HelpersDatabase.GetDateTime(Reader, "Driver_Delivered_Time");
                string Move_Order_Created = HelpersDatabase.GetDateTime(Reader, "Move_Order_Created");
                int Move_Completed = Reader.GetInt16("Move_Completed");
                string Move_msg = HelpersDatabase.GetString(Reader, "Move_msg");
                string Move_Regi_name = Reader.GetString("Move_Regi_name");
                string Move_User_Login = Reader.GetString("Move_User_Login");
                string Cuenta_Name = Reader.GetString("Cuenta_Name");
                int Move_host = Reader.GetInt16("Move_host");
                decimal Move_Credit_Value = Reader.GetDecimal("Move_Credit_Value");
                decimal Move_Cash_Value = Reader.GetDecimal("Move_Cash_Value");
                decimal Move_Debit_Value = Reader.GetDecimal("Move_Debit_Value");
                decimal Move_Check_Value = Reader.GetDecimal("Move_Check_Value");
                decimal Move_Stamp_Value = Reader.GetDecimal("Move_Stamp_Value");
                decimal Move_wic_Value = Reader.GetDecimal("Move_wic_Value");
                decimal Money_Conv = Reader.GetDecimal("Money_Conv");
                decimal Move_Gift_Value = Reader.GetDecimal("Move_Gift_Value");
                decimal move_onaccount_Value = Reader.GetDecimal("move_onaccount_Value");
                decimal Move_CRNOTE_Value = Reader.GetDecimal("Move_CRNOTE_Value");
                decimal move_tip_Value = Reader.GetDecimal("move_tip_Value");
                decimal grat_cc_tip = Reader.GetDecimal("grat_cc_tip");
                decimal move_Delivery_Value = Reader.GetDecimal("move_Delivery_Value");
                decimal Move_amount_Tender = Reader.GetDecimal("Move_amount_Tender");
                decimal Credit_tip = Reader.GetDecimal("Credit_tip");
                int Move_cashier = Reader.GetInt16("Move_cashier");
                int Tax_Exempt = Reader.GetInt16("Tax_Exempt");
                int Move_preClose_ID = Reader.GetInt16("Move_preClose_ID");
                int Move_Close = Reader.GetInt16("Move_Close");
                int Move_Close_ID = Reader.GetInt16("Move_Close_ID");
                string Move_refer = HelpersDatabase.GetString(Reader, "Move_refer");
                int Dine_type = Reader.GetInt16("Dine_type");
                string Table_name = HelpersDatabase.GetString(Reader, "Table_name");
                int Cust_Id = Reader.GetInt16("Cust_Id");
                int recipient_id = Reader.GetInt16("recipient_id");
                int add_id = Reader.GetInt16("add_id");
                int Billadd_id = Reader.GetInt16("Billadd_id");
                string MOD_Date = HelpersDatabase.GetDateTime(Reader, "MOD_Date");
                int MOD_empl = Reader.GetInt16("MOD_empl");
                int Driver = Reader.GetInt16("Driver");
                int move_people = Reader.GetInt32("move_people");
                int ticket_id = Reader.GetInt32("ticket_id");
                int Payment_id = Reader.GetInt16("Payment_id");
                int Pay_inFull = Reader.GetInt16("Pay_inFull");
                int cc_name_id = Reader.GetInt16("cc_name_id");
                int Docu_type_ID = Reader.GetInt16("Docu_type_ID");
                int Salestype_id = Reader.GetInt16("Salestype_id");
                string note_credit = Reader.GetString("note_credit");
                int EZway_order = Reader.GetInt16("EZway_order");
                int Salesper_id = Reader.GetInt16("Salesper_id");
                string e_id = Reader.GetString("e_id");
                int pago_id = Reader.GetInt16("pago_id");
                int sunat_sent = Reader.GetInt16("sunat_sent");
                string e_filename = Reader.GetString("e_filename");
                string e_document = HelpersDatabase.GetString(Reader, "e_document");
                string e_documentdet = HelpersDatabase.GetString(Reader, "e_documentdet");
                string e_signature = HelpersDatabase.GetString(Reader, "e_signature");
                int e_approved = Reader.GetInt16("e_approved");
                string bday_entered = HelpersDatabase.GetDate(Reader, "bday_entered");
                int sunat_resent = Reader.GetInt16("sunat_resent");
                int move_layaway_id = Reader.GetInt16("move_layaway_id");
                string camaleon_ver = Reader.GetString("camaleon_ver");
                int notacr_code = Reader.GetInt16("notacr_code");
                string packlist_id = HelpersDatabase.GetString(Reader, "packlist_id");
                decimal Onaccount_tip = Reader.GetDecimal("Onaccount_tip");
                int group_id = Reader.GetInt16("group_id");

                movesToSync.Add(new it_tmove(Move_ID, Ticket_count, Move_Cust_ID, Move_Oper_ID, Move_Date, Move_Due_Date,
                                Move_Fiscal_Date, Driver_time_out, Driver_Delivered_Time, Move_Order_Created, Move_Completed,
                                Move_msg, Move_Regi_name, Move_User_Login, Cuenta_Name, Move_host, Move_Credit_Value,
                                Move_Cash_Value, Move_Debit_Value, Move_Check_Value, Move_Stamp_Value, Move_wic_Value,
                                Money_Conv, Move_Gift_Value, move_onaccount_Value, Move_CRNOTE_Value, move_tip_Value,
                                grat_cc_tip, move_Delivery_Value, Move_amount_Tender, Credit_tip, Move_cashier, Tax_Exempt,
                                Move_preClose_ID, Move_Close, Move_Close_ID, Move_refer, Dine_type, Table_name, Cust_Id,
                                recipient_id, add_id, Billadd_id, MOD_Date, MOD_empl, Driver, move_people, ticket_id, Payment_id,
                                Pay_inFull, cc_name_id, Docu_type_ID, Salestype_id, note_credit, EZway_order, Salesper_id, e_id,
                                pago_id, sunat_sent, e_filename, e_document, e_documentdet, e_signature, e_approved, bday_entered,
                                sunat_resent, move_layaway_id, camaleon_ver, notacr_code, packlist_id, Onaccount_tip, group_id,
                                Settings.Default.locationId));
            }

            Reader.Close();

            return movesToSync;
        }

        public static List<it_tdetamove> GetDetaMovesToSync(int lastId, int limit)
        {
            List<it_tdetamove> detamovesToSync = new List<it_tdetamove>();
            MySqlConnection connection = null;
            //try
            //{
            connection = new MySqlConnection(ConnectionConfig.connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM it_tdetamove WHERE Move_Deta_ID > " + lastId + " LIMIT " + limit + " ";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                int Move_Deta_ID = Reader.GetInt32("Move_Deta_ID");
                int Move_Deta_Move_ID = Reader.GetInt32("Move_Deta_Move_ID");
                string Move_Deta_ITEM_ID = Reader.GetString("Move_Deta_ITEM_ID");
                int Subitem_of = Reader.GetInt32("Subitem_of");
                double Move_Deta_Q = Reader.GetDouble("Move_Deta_Q");
                double Move_Deta_Ori_Q = HelpersDatabase.GetDouble(Reader, "Move_Deta_Ori_Q");
                string Move_deta_UM = Reader.GetString("Move_deta_UM");
                decimal Move_Deta_K = Reader.GetDecimal("Move_Deta_K");
                decimal Move_Deta_price = Reader.GetDecimal("Move_Deta_price");
                decimal Move_Deta_Tax_Value = Reader.GetDecimal("Move_Deta_Tax_Value");
                decimal Move_Deta_Tax2_Value = Reader.GetDecimal("Move_Deta_Tax2_Value");
                decimal Move_Deta_Tax3_Value = Reader.GetDecimal("Move_Deta_Tax3_Value");
                decimal Move_REG_price = HelpersDatabase.GetDecimal(Reader, "Move_REG_price");
                int detamove_incl_tax = Reader.GetInt16("detamove_incl_tax");
                int sold_mode = Reader.GetInt16("sold_mode");
                int Note = Reader.GetInt16("Note");
                string Detalles = HelpersDatabase.GetString(Reader, "Detalles");
                int On_Sale = Reader.GetInt16("On_Sale");
                int Item_complete = Reader.GetInt16("Item_complete");
                string Date_complete = HelpersDatabase.GetDateTime(Reader, "Date_complete");
                int Order_ID = Reader.GetInt16("Order_ID");
                string Order_Table_name = Reader.GetString("Order_Table_name");
                string Chair_ID = Reader.GetString("Chair_ID");
                int order_host = Reader.GetInt16("order_host");
                int man_apprid = Reader.GetInt16("man_apprid");
                string Serial_Num = HelpersDatabase.GetString(Reader, "Serial_Num");
                string expi_date = HelpersDatabase.GetDate(Reader, "expi_date");
                int rentaldays = Reader.GetInt16("rentaldays");
                int rental = Reader.GetInt16("rental");
                string Returned_id = Reader.GetString("Returned_id");
                int Stock_Room = Reader.GetInt16("Stock_Room");
                string Discount_Code = Reader.GetString("Discount_Code");
                int modi = Reader.GetInt16("modi");
                string Order_Regi_name = HelpersDatabase.GetString(Reader, "Order_Regi_name");
                int Inv_Close_ID = Reader.GetInt16("Inv_Close_ID");
                int Move_Deta_Guia_ID = Reader.GetInt16("Move_Deta_Guia_ID");
                decimal Commicost = Reader.GetDecimal("Commicost");
                int Commipaid_id = Reader.GetInt16("Commipaid_id");
                int sent_to = Reader.GetInt16("sent_to");
                int gift_id = Reader.GetInt16("gift_id");
                int Vendor_id = HelpersDatabase.GetInt16(Reader, "Vendor_id");
                int origi_cuentaID = Reader.GetInt32("origi_cuentaID");
                string Order_Time_in = HelpersDatabase.GetDateTime(Reader, "Order_Time_in");
                string Order_Item_PREFERENCE = HelpersDatabase.GetString(Reader, "Order_Item_PREFERENCE");
                string Pr_sp_id_code = Reader.GetString("Pr_sp_id_code");
                string Date_Rented = HelpersDatabase.GetDateTime(Reader, "Date_Rented");

                detamovesToSync.Add(new it_tdetamove(Move_Deta_ID, Move_Deta_Move_ID, Move_Deta_ITEM_ID, Subitem_of, Move_Deta_Q, Move_Deta_Ori_Q, Move_deta_UM,
                                                    Move_Deta_K, Move_Deta_price, Move_Deta_Tax_Value, Move_Deta_Tax2_Value, Move_Deta_Tax3_Value, Move_REG_price,
                                                    detamove_incl_tax, sold_mode, Note, Detalles, On_Sale, Item_complete, Date_complete, Order_ID, Order_Table_name,
                                                    Chair_ID, order_host, man_apprid, Serial_Num, expi_date, rentaldays, rental, Returned_id, Stock_Room,
                                                    Discount_Code, modi, Order_Regi_name, Inv_Close_ID, Move_Deta_Guia_ID, Commicost, Commipaid_id, sent_to,
                                                    gift_id, Vendor_id, origi_cuentaID, Order_Time_in, Order_Item_PREFERENCE, Pr_sp_id_code, Date_Rented,
                                                    Settings.Default.locationId));
            }

            Reader.Close();
            connection.Close();
            /*}
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }*/
            return detamovesToSync;
        }
    }
}