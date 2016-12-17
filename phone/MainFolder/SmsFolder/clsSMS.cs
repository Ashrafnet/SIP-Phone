using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;
using Softphone.SettingFolder;
using Softphone.ConfigFolder;
using System.Net.Cache;

namespace Softphone.SmsFolder
{
    public enum SMSBoxType {Inbox,Outbox }
    public class clsSMS
    {
        private static int msgsNo;

        public static string GetSmS(string username, string password, SMSBoxType type)
        {
            string strUrl;
            if (type == SMSBoxType.Inbox) strUrl = "https://sip.nogafone.com/noga/getsms.php?";
            else strUrl = "https://sip.nogafone.com/noga/getsmssent.php?";

            string strPost = "username=" + username + "&password=" + password + "";

            WebClient x = new System.Net.WebClient();
           // x.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            x.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            return x.DownloadString(strUrl + strPost);
        }
        public static bool  DelSmS(string username, string password,string MsgIds, SMSBoxType type)
        {
            try
            {
                string strUrl;
                if (type == SMSBoxType.Inbox) strUrl = "https://sip.nogafone.com/noga/smsdelrec.php?";
                else strUrl = "https://sip.nogafone.com/noga/smsdelsend.php?";

                string strPost = "username=" + username + "&password=" + password + "&smsid=" + MsgIds;

                WebClient x = new System.Net.WebClient();
                x.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                string ret = x.DownloadString(strUrl + strPost);
                return Convert.ToBoolean(int.Parse( ret));
            }
            catch { return false; }
            
        }

        public static  bool SendSmS(string Phones, string msgBody)
        {
            
            //Phones = FormatNos(Phones);
            //msgsNo = NoOfMobiles(Phones);
            int msgsNox = int.Parse(Math.Round(double.Parse((msgBody.Length / 69) + "")) + "")+1;
            msgsNo = msgsNo * msgsNox;
            //if (!HaveEnoughBalance(msgsNo)) return false;

            //string FromTag = clsDB.ExcuteReturnedSQLByReader("select fromtag from sms_users where emp_no="+clsFunctions.emp_no() );
            string strUrl = "https://sip.nogafone.com/noga/sms.php?";
            string strPost = "username=%username%&password=%passwor%&destination=%phones%&message=%MSG%";
           // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create (strUrl );
            WebProxy proxy = new WebProxy();
            if (Settings.Default.UseProxy && Settings.Default.UseProxyAuthentication)
                request.Credentials = new NetworkCredential(GetUserName(), GetPass(), GetDomain());
            else
                request.Credentials = CredentialCache.DefaultCredentials;
            
            
            if (Settings.Default.UseProxy)
            {
                proxy = new WebProxy(GetProxy() + ":80", true);
                proxy.Credentials = request.Credentials;
                request.Proxy = proxy;
            }
            // Set the Method property of the request to POST.
            request.Method = "POST";
            strPost = strPost.Replace("%phones%", (Phones));
            strPost = strPost.Replace("%MSG%", (msgBody));
            strPost = strPost.Replace("%username%", (PhoneConfig.Instance.Accounts[0].UserName));
            strPost = strPost.Replace("%passwor%", (PhoneConfig.Instance.Accounts[0].Password ));
            

            // Create POST data and convert it to a byte array.
            string postData = strPost ;
            byte[] byteArray = Encoding.Default.GetBytes (postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream ();
            // Write the data to the request stream.
            dataStream.Write (byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close ();
            // Get the response.

            WebResponse response = request.GetResponse ();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd ();            
            // Clean up the streams.
            reader.Close ();
            dataStream.Close ();
            response.Close ();

            if (responseFromServer.Contains("1"))
            {                
                return true;
            }
            else
                return false;
            
        }

       
        private static   string FormatNos(string NO)
        {
            
            if (NO.StartsWith("059"))
            {                
                return NO.Replace("059", "97259");
            }                
            else
                return NO;
    
        }
        private static int NoOfMobiles(string Nos)
        {
            int theNo = 0; 
            string[] yy = Nos.Split(',');
            foreach (string  y in yy)
            {
                if (y.Length > 0)
                    theNo += 1;
            }
           
            return theNo;
        }
        
        static string GetProxy()
        {
            try
            {//ISA Server
                return Settings.Default.ProxyAddress;
            }
            catch
            {
                return "";
            }
        }

        static string GetUserName()
        {
            try
            {
                return Settings.Default.ProxyUserName;
            }
            catch
            {
                return "";
            }
        }

        static string GetPass()
        {
            try
            {
                return Settings.Default.ProxyPassword;
            }
            catch
            {
                return "";
            }
        }

        static string GetDomain()
        {
            try
            {
                return Settings.Default.ProxyDomain ;
            }
            catch
            {
                return "";
            }
        }        

        
    }
    
}
