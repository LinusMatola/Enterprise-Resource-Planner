namespace KFCPortal
{
    using NAVWS;
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;
    using System.IO;
    using NAVODATA;

    public class WSConfig
    {
        public static NAV ReturnNav()
        {
            NAV nAV = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]));
            nAV.Credentials = ((ICredentials)new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]));
            return nAV;
        }

        public static portal ObjNav
        {
            get
            {
                portal portals = new portal();
                try
                {
                    NetworkCredential networkCredential = (NetworkCredential)(portals.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]));
                    portals.PreAuthenticate = true;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return portals;
            }
        }
        public static bool MailFunction(string body, string recepient, string subject)
        {
            bool result = false;
            try
            {
                //var GenarateStartKeyLink = "/Register/SetPassword/";
                //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateStartKeyLink);
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(recepient);
                mailMessage.Subject = subject;
                mailMessage.From = new MailAddress("linus2769@gmail.com");

                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;


                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("linus2769@gmail.com", "32645000Linus");
                smtp.EnableSsl = true;

                SmtpClient smtpClient2 = smtp;
                smtpClient2.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return result;
        }

        public class Utility
        {
            public static void WriteLog(Exception text)
            {
                try
                {
                    //set up a filestream
                    string strPath = @"C:\Logs\web";
                    string fileName = DateTime.Now.ToString("MMddyyyy") + "_logs.txt";
                    string filenamePath = strPath + '\\' + fileName;
                    Directory.CreateDirectory(strPath);
                    FileStream fs = new FileStream(filenamePath, FileMode.OpenOrCreate, FileAccess.Write);
                    //set up a streamwriter for adding text
                    StreamWriter sw = new StreamWriter(fs);
                    //find the end of the underlying filestream
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    //add the text
                    sw.WriteLine(text);
                    //add the text to the underlying filestream
                    sw.Flush();
                    //close the writer
                    sw.Close();
                }
                catch (Exception ex)
                {
                    //throw;
                    ex.Data.Clear();
                }
            }

        }
    }
}

