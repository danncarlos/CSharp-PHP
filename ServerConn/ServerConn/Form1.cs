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
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e){
            //String
            char[] delimiter = {'|'};
            
            //Login Action
            string url = "http://localhost/projetologin/login.php";
            WebClient action = new WebClient();
            NameValueCollection formdata = new NameValueCollection();
            formdata["user"] = txtbox_login.Text;
            formdata["pass"] = txtbox_pass.Text;
            
            action.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            byte[] response = action.UploadValues(url, "POST", formdata);
            int pass = 1;
            string responseserver = Encoding.UTF8.GetString(response);
            Console.WriteLine(responseserver);

            string[] data = responseserver.Split('|');
           
            if (responseserver == "false"){
                MessageBox.Show("Login ou senha não conferem...\n" +
                    responseserver);
                pass = 0;
            }
            if(pass == 1){
                Global.username = data[0];
                Global.userpass = txtbox_pass.Text;
                Global.userphoto = data[1];
                Global.usermail = data[2];
                logado win = new logado();
                win.Show();
            }



        }
    }
}
