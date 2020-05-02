using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;

namespace Ideas.Smtp
{
    public class Mail
    {
        // Atributos

        // autenticação
        private string _smtp; 
        private string _usuario; 
        private string _senha; 
        private int _porta;
        private string _rementente;
        private bool _ssl;
        
        // objeto das classes de e-mails
        private MailMessage objMail;
        private SmtpClient objSMTP;

        // corpo público
        public string Assunto { get; set; }
        public string Destinatario { get; set; }

        public Stream Anexo { get; set; }
           
      
        
        //Construtores
        public Mail()
        {
            objMail = new MailMessage();
            objSMTP = new SmtpClient();
            _smtp = IdeasConfig.Default.SmtpHost; 
            _usuario =  IdeasConfig.Default.SmtpUser; 
            _senha =  IdeasConfig.Default.SmtpPassword;
            _porta = IdeasConfig.Default.SmtpPort;
            _ssl = IdeasConfig.Default.SmtpSSL;
            _rementente = IdeasConfig.Default.SmtpSender;
        }
       
        public void EnviaEmail(string body)
        {
            objSMTP.Host = _smtp;
            objSMTP.Credentials = new NetworkCredential(this._usuario, this._senha);
            objSMTP.Port = _porta;
            objSMTP.EnableSsl = _ssl; // false; // gmail = TRUE
            objMail.BodyEncoding = Encoding.UTF8;
            objMail.Priority = MailPriority.Normal;
            
            
            objMail.To.Add(this.Destinatario); // destinatário de e-mail
           
            objMail.From = new MailAddress(this._usuario, this._rementente, Encoding.UTF8);
            //objMail.CC.Add("pedro@ideasfor.com.br");
            //objMail.CC.Add("jorge@ideasfor.com.br");
            objMail.Subject = this.Assunto;
            objMail.SubjectEncoding = Encoding.UTF8;
            objMail.IsBodyHtml = true;
            objMail.Body = body;

            if(Anexo != null)
            {
                objMail.Attachments.Add(new Attachment(Anexo, "attachment"));
            }
           


            objSMTP.Send(this.objMail);
        }

        public static bool Evalido(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email))
                return true;
            else
                return false;
        }
    }
}
