using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace ServerConn{
    public partial class logado : Form{
        public logado(){
            InitializeComponent();


        }

        private void btn_exit_Click(object sender, EventArgs e){
            System.Environment.Exit(1);
            
        }

        private void logado_Load(object sender, EventArgs e){
            var imagesource = WebRequest.Create(Global.baseurl+Global.userphoto);
            using (var response = imagesource.GetResponse())
                using(var stream = response.GetResponseStream()){
                pictureBox1.Image = Bitmap.FromStream(stream);
                

            }

            txtbox_name.Text = Global.username;
            txtbox_email.Text = Global.usermail;
            txtbox_pass.Text = Global.userpass;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e){
            if(checkBox1.Checked == true){
                txtbox_pass.PasswordChar = '\0';
            }
            else{
                txtbox_pass.PasswordChar = '•';
            }

            
        }
    }
}
