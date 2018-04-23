using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Extensions
{
    public static T Next<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + 1;
        return (Arr.Length == j) ? Arr[0] : Arr[j];
    }

    public static T Prev<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) - 1;
        return (-1 == j) ? Arr[Arr.Length - 1] : Arr[j];
    }

    public static string Reverse(this string input)
    {
        return new string(input.ToCharArray().Reverse().ToArray());
    }

    public static string RemoveLast(this string text, string character)
    {
        if (text.Length < 1) return text;
        return text.Remove(text.ToString().LastIndexOf(character), character.Length);
    }

    private static string ToText()
    {
        return "";
    }

    private static readonly String[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };

    private static readonly String[] DECENAS = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};

    private static readonly String[] CENTENAS = {"", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};

    private static Regex r;

    public static String ToText(String numero, bool mayusculas)
    {
        String literal = "";
        String parte_decimal;
        //si el numero utiliza (.) en lugar de (,) -> se reemplaza
        numero = numero.Replace(".", ",");

        //si el numero no tiene parte decimal, se le agrega ,00
        if (numero.IndexOf(",") == -1)
        {
            numero = numero + ",00";
        }
        //se valida formato de entrada -> 0,00 y 999 999 999,00
        r = new Regex(@"\d{1,9},\d{1,2}");
        MatchCollection mc = r.Matches(numero);
        if (mc.Count > 0)
        {
            //se divide el numero 0000000,00 -> entero y decimal
            String[] Num = numero.Split(',');

            //de da formato al numero decimal
            parte_decimal = Num[1] + "/100 SOLES.";
            //se convierte el numero a literal
            if (int.Parse(Num[0]) == 0)
            {//si el valor es cero
                literal = "cero ";
            }
            else if (int.Parse(Num[0]) > 999999)
            {//si es millon
                literal = getMillones(Num[0]);
            }
            else if (int.Parse(Num[0]) > 999)
            {//si es miles
                literal = getMiles(Num[0]);
            }
            else if (int.Parse(Num[0]) > 99)
            {//si es centena
                literal = getCentenas(Num[0]);
            }
            else if (int.Parse(Num[0]) > 9)
            {//si es decena
                literal = getDecenas(Num[0]);
            }
            else
            {//sino unidades -> 9
                literal = getUnidades(Num[0]);
            }
            //devuelve el resultado en mayusculas o minusculas
            if (mayusculas)
            {
                return (literal + parte_decimal).ToUpper();
            }
            else
            {
                return (literal + parte_decimal);
            }
        }
        else
        {//error, no se puede convertir
            return literal = null;
        }
    }

    /* funciones para convertir los numeros a literales */

    private static String getUnidades(String numero)
    {   // 1 - 9
        //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
        String num = numero.Substring(numero.Length - 1);
        return UNIDADES[int.Parse(num)];
    }

    private static String getDecenas(String num)
    {// 99
        int n = int.Parse(num);
        if (n < 10)
        {//para casos como -> 01 - 09
            return getUnidades(num);
        }
        else if (n > 19)
        {//para 20...99
            String u = getUnidades(num);
            if (u.Equals(""))
            { //para 20,30,40,50,60,70,80,90
                return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
            }
            else
            {
                return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
            }
        }
        else
        {//numeros entre 11 y 19
            return DECENAS[n - 10];
        }
    }

    private static String getCentenas(String num)
    {// 999 o 099
        if (int.Parse(num) > 99)
        {//es centena
            if (int.Parse(num) == 100)
            {//caso especial
                return " cien ";
            }
            else
            {
                return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
            }
        }
        else
        {//por Ej. 099
         //se quita el 0 antes de convertir a decenas
            return getDecenas(int.Parse(num) + "");
        }
    }

    private static String getMiles(String numero)
    {// 999 999
     //obtiene las centenas
        String c = numero.Substring(numero.Length - 3);
        //obtiene los miles
        String m = numero.Substring(0, numero.Length - 3);
        String n = "";
        //se comprueba que miles tenga valor entero
        if (int.Parse(m) > 0)
        {
            n = getCentenas(m);
            return n + "mil " + getCentenas(c);
        }
        else
        {
            return "" + getCentenas(c);
        }
    }

    private static String getMillones(String numero)
    { //000 000 000
      //se obtiene los miles
        String miles = numero.Substring(numero.Length - 6);
        //se obtiene los millones
        String millon = numero.Substring(0, numero.Length - 6);
        String n = "";
        if (millon.Length > 1)
        {
            n = getCentenas(millon) + "millones ";
        }
        else
        {
            n = getUnidades(millon) + "millon ";
        }
        return n + getMiles(miles);
    }
}

/// private static string ToText(this int value)

public enum HttpMethod
{
    GET,
    PUT,
    POST,
    DELETE
}//End of http enum

/// <summary>
/// The words
/// </summary>
public static class TWords
{
    public static string SERVICE = "service";
    public static string VARDATA = "data";
    public static string SLASH = "/";
    public static string ONEPARAM = "/{0}";
    public static string EMPTY = "";
}// End of TWords class

public enum DataType
{
    JSON,
    xML,
    HTML,
    PLAIN
}// End of Data types

public enum CamaleonTables
{
    it_tcategory,
    it_titemclass,
    it_tdepartment,
    it_tfamily,
    it_titem,
    it_tmove,
    it_tdetamove,
    it_tclose,
    it_tregister,

    //it_tcompany,
    it_tuser,

    it_tclock,

    it_temployee,
    it_tlanguage,
    nota_credito_type,
    it_taccotype,
    it_taccotypegeneral,
    it_taccount,

    void_items,

    it_ttable,
    ressections,

    docu_type,

    fl_tcustomer,
    it_tcustomer,
    fl_taddress,
    tc_datos,

    Completed,
    p01encdocumento,
    p03validaciones,
    p04anulados,
    p05rechazos,
    TanusCompleted,
}

public enum TanusTables
{
    p01encdocumento,
    p03validaciones,
    p04anulados,
    p05rechazos,
    Completed,
}

public class DoorTime
{
    public DoorTime()
    {
    }

    public DoorTime(DateTime openDoorTime, DateTime closeDoorTime)
    {
        this.openDoorTime = openDoorTime;
        this.closeDoorTime = closeDoorTime;
    }

    public DateTime openDoorTime { get; set; }
    public DateTime closeDoorTime { get; set; }
}