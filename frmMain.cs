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
using TinyChat.settings;


namespace TinyChat
{
    
    public partial class frmMain : Form
    {
        public static ApplicationSettings appSettings;

        public frmMain()
        {
            InitializeComponent();
            appSettings = ApplicationSettings.load();
            fillAccountDetails();
        }

        // Open the account manager
        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAccounts accountManager = new frmAccounts();

            if (accountManager.ShowDialog() == DialogResult.OK)
            {
                accountManager.Hide();
                fillAccountDetails();
            }

            accountManager = null;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        // Fills the drop down box with the list of saved accounts
        private void fillAccountDetails()
        {
            cmbAccounts.Items.Clear();
            foreach(Account item in appSettings.SavedAccounts)
            {
                cmbAccounts.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Make sure we have a selected account from the drop down before we do anything.
            if (cmbAccounts.SelectedItem == null)
            {
                MessageBox.Show(
                    "You must select a saved account from the drop down. Click the edit button to add a new account", 
                    "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            // Get a handle on our services
            Account loginDetails = (Account)cmbAccounts.SelectedItem;
            AuthService authService = new AuthService();


            // Try to log in with the selected account
            try
            {
                if (authService.login(loginDetails.Username, loginDetails.Password))
                {
                    loginDetails.AuthStatus = AuthenticationStatus.Authenticated;
                    tssConnection.Text = "Authenticated";
                }
                else
                {
                    MessageBox.Show(
                        "The username or password was incorrect",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            // Check to make sure we didn't throw an exception somewhere along the way, and that
            // we didn't accidently nuke a username or a password
            catch (AuthException)
            {
                MessageBox.Show(
                    "The username or password was incorrect",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                tssConnection.Text = "Disconnected";
            } 
            catch (ValidationException)
            {
                MessageBox.Show(
                    "The username or password was empty for this account",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                tssConnection.Text = "Disconnected";
            }
        }
    }
}
