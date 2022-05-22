using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Mail;
using System.Net;

namespace XFEposta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            epostaGonder(kimeTxt.Text, konuTxt.Text, govdeTxt.Text);
        }

        public void epostaGonderildi(Object sender,EventArgs e)
        {
            durumLbl.Text = "E-Posta Gönderildi";
        }

        public void epostaGonder(String kime,String konu,String govde)
        {
            try
            {
                String kimden = "bozkirmyoprogramlama@gmail.com";
                MailMessage msg = new MailMessage(kimden, kime);
                msg.Subject = konu;
                msg.Body = govde;
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 587;
                sc.SendCompleted += new SendCompletedEventHandler(epostaGonderildi);
                NetworkCredential kimlik = new NetworkCredential(kimden, "bozkirmyo123");
                sc.Credentials = kimlik;
                sc.EnableSsl = true;
                sc.SendAsync(msg, kime);
            }
            catch (Exception err)
            {
                durumLbl.Text = err.Message;
            }           
        }
    }
}
