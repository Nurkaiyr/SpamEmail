using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

namespace SpamEmail
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isFileAttached = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.Credentials = new NetworkCredential("smtptesteritstep@gmail.com", "167AEq!!");

            int success = 0;
            try
            {
                mail.From = new MailAddress("smtptesteritstep@gmail.com","Nurkaiyr");
                mail.To.Add(toTxtBlock.Text);
                mail.Subject = themeTxtBlock.Text;
                mail.Body = messageTxtBlock.Text;

                if(isFileAttached == true)
                {
                Attachment attachment;
                attachment = new Attachment(txtAttachment.Text);
                mail.Attachments.Add(attachment);
                }
                SmtpServer.SendMailAsync(mail);   
                success++;
            }
            catch
            {
                MessageBox.Show("Ошибка при отправке!");
            }
            if(success >= 1)
            MessageBox.Show("Почта отправлена!");
        }

        public void Button_Click_Attachment(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            MailMessage mail = new MailMessage();
            openFileDialog1.ShowDialog();
            Attachment attachment;

            attachment = new Attachment(openFileDialog1.FileName);
            mail.Attachments.Add(attachment);

            txtAttachment.Text = openFileDialog1.FileName;
            isFileAttached = true;
        }
    }
}
