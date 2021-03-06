﻿using System;
using System.Net;
using System.Net.Mail;

namespace Email_Test.console
{
    class MainClass
    {
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = "islam.ibrahim@medafinvestment.com"; //Sender Email Address  
        static string password = "Serious!1"; //Sender Password  
        static string emailToAddress = "i_gad_@hotmail.com"; //Receiver Email Address  
        static string subject = "Hello";
        static string body = "Hello, This is Email sending test using gmail.";

        public static void Main(string[] args)
        {
            GmailSender.SendEmail(emailFromAddress, password, emailToAddress, subject, body, null);
        }

        public static void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
