using CamaleonInvoice.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// Http Service implementation
/// </summary>
public class HttpService : IHttpService
{
    public object ConfigurationManager { get; private set; }

    /// <summary>
    /// Create url
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public string CreateUrl(string model)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(Settings.Default.serviceEndPoint).
            Append(model);
        return sb.ToString();
    }// End of Create Url function

    /// <summary>
    /// Get authentication string
    /// </summary>
    /// <returns></returns>
    public string GetAuthenticationString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Basic ")
            .Append(Base64Encode(Settings.Default.username + ":" + Settings.Default.password));
        return sb.ToString();
    }// End of Get Authentication String function

    /// <summary>
    /// JSON HTTP Pettition generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="method"></param>
    /// <param name="model"></param>
    /// <param name="req_data"></param>
    /// <returns></returns>
    public IList<T> JSONHttpPettitionList<T>(HttpMethod method, string model, string req_data)
    {
        try
        {
            //Init request
            HttpWebRequest request = WebRequest.Create(CreateUrl(model)) as HttpWebRequest;
            //Get data serialized
            var data = Encoding.UTF8.GetBytes(TWords.EMPTY);
            //Validate req_data
            if (req_data != null)
            {
                data = Encoding.UTF8.GetBytes(req_data);
            }
            // Request configuration
            request.Headers[Resources.auth] = GetAuthenticationString();
            request.Method = method.ToString();
            request.ContentType = Resources.app_json;
            // if there is no data to send
            if (data.Length > 0)
            {
                request.ContentLength = data.Length;
                //Stream the data to the request
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }//End of stream use
            }
            // Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //Verify if it is a right pettition
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("API RESPONSE: " + response.StatusCode + response.StatusDescription);
                    throw new Exception(String.Format(Resources.server_error, response.StatusCode, response.StatusDescription));
                }
                //Get the serialized object on a dictionary

                Dictionary<string, List<T>> data_Var = JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(new StreamReader(response.GetResponseStream()).ReadToEnd());

                //Return data
                return data_Var[TWords.VARDATA];
            }//End of response use
        }
        catch (Exception e)
        {
            // Manage the exceptions
            Console.WriteLine(e.Message);
            return default(List<T>);
        }
    }// End of HttpPettition function

    /// <summary>
    /// JSON Http pettition object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="method"></param>
    /// <param name="model"></param>
    /// <param name="req_data"></param>
    /// <returns></returns>
    public T JSONHttpPettitionObject<T>(HttpMethod method, string model, string req_data)
    {
        try
        {
            Console.WriteLine(CreateUrl(model));
            //Init request
            HttpWebRequest request = WebRequest.Create(CreateUrl(model)) as HttpWebRequest;
            //Request configuration
            var data = Encoding.UTF8.GetBytes(TWords.EMPTY);
            //Validate req_data
            if (req_data != null)
            {
                data = Encoding.UTF8.GetBytes(req_data);
            }
            // Request configuration
            request.Headers[Resources.auth] = GetAuthenticationString();
            // Requested Method
            request.Method = method.ToString();
            // Data type
            request.ContentType = Resources.app_json;
            // if there is no data to send
            if (data.Length > 0)
            {
                request.ContentLength = data.Length;
                // Stream the data to the request
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }// End of stream use
            }
            // Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Verify if it is a right pettition
                if (response.StatusCode == HttpStatusCode.OK && method == HttpMethod.GET)
                {
                    //Get the serialized object on a dictionary
                    Dictionary<string, T> data_Var = JsonConvert.DeserializeObject<Dictionary<string, T>>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                    //Return data
                    return data_Var[TWords.VARDATA];
                }
                else if (response.StatusCode == HttpStatusCode.Created && method == HttpMethod.POST)
                {
                    // Return of the serialized object
                    return JsonConvert.DeserializeObject<T>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                }
                else if (response.StatusCode == HttpStatusCode.OK && method == HttpMethod.PUT)
                {
                    // Return of the serialized object
                    return JsonConvert.DeserializeObject<T>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                }
                else if (response.StatusCode == HttpStatusCode.OK && method == HttpMethod.POST)
                {
                    // Return of the serialized object
                    return JsonConvert.DeserializeObject<T>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                }
                else if (response.StatusCode == HttpStatusCode.NoContent && method == HttpMethod.DELETE)
                {
                    // Object deleted
                }
                else if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format(Resources.server_error, response.StatusCode, response.StatusDescription));
                }
                return default(T);
            }//End of response use
        }
        catch (Exception e)
        {
            // Manage the exceptions
            Console.WriteLine(e.Message);
            return default(T);
        }
    }// End of JSONHttpPettitionObject function

    /// <summary>
    /// Base 64 encode
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }// End of Base64Encode function

    /// <summary>
    /// Base 64 decode
    /// </summary>
    /// <param name="base64EncodedData"></param>
    /// <returns></returns>
    public string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }// End of Base64Decode function
}// End of HttpPettitions