using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyChat.src.Controllers;
using TinyChat.src.Exceptions;
using TinyChat.src.Models;
using TinyChat.src.Services;

namespace TinyChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserController controller = new UserController();
            Account authenticatedUser = controller.authenticate(txtUsername.Text, txtPassword.Text);
        }
    }
}
