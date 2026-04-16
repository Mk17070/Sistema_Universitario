using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Projeto_Sistema_Area_Restrita
{
    public partial class Form_Unilus : Form
    {
        public Form_Unilus()
        {
            InitializeComponent();
        }

        private int ImageNumber = 1;

        private void LoadNextImage()
        {
            if (ImageNumber == 6)
            {
                ImageNumber = 1;
            }
            SlidePic.ImageLocation = string.Format(@"Images\{0}.jpg", ImageNumber);
            ImageNumber++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Não Foi Possivel Abrir O Link.", "ATENÇÂO");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink2();
            }
            catch (Exception)
            {
                MessageBox.Show("Não Foi Possivel Abrir O Link.", "ATENÇÂO");
            }
        }

        private void VisitLink()
        {
            if (linkLabel1.LinkVisited == true)
            {
                System.Diagnostics.Process.Start("http://www.unilus.edu.br/newsite/");
            }
        }
        private void VisitLink2()
        {

            if (linkLabel2.LinkVisited == true)
            {
                System.Diagnostics.Process.Start("http://www.unilus.edu.br/unilus/historia/");
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            Form_Login form_Login = new Form_Login();
            form_Login.Show();
        }

    }
}