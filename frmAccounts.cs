using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyChat.src.Models;

namespace TinyChat
{
    public partial class frmAccounts : Form
    {
        public frmAccounts()
        {
            InitializeComponent();
            DrawAccounts();

        }

        private void DrawAccounts()
        {
            listView1.Items.Clear();
            foreach (Account account in frmMain.appSettings.SavedAccounts)
            {
                string[] columns = new string[2] { account.Username, account.Password };

                ListViewItem item = new ListViewItem(columns);
                item.Tag = account;

                listView1.Items.Add(item);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAddAccount addAccounts = new frmAddAccount();

            if (addAccounts.ShowDialog() == DialogResult.OK)
            {
                frmMain.appSettings.SavedAccounts.Add((Account)addAccounts.Tag);
                frmMain.appSettings.save();
            }

            this.DrawAccounts();

            addAccounts = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void frmAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }


            foreach(ListViewItem item in listView1.SelectedItems)
            {
                frmMain.appSettings.SavedAccounts.Remove((Account)item.Tag);
            }

            DrawAccounts();
            frmMain.appSettings.save();
        }
    }
}
