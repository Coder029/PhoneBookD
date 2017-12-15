using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhoneBookD
{
    public partial class PhoneBook : Form
    {
        public PhoneBook()
        {
            InitializeComponent();
        }

        private void PhoneBook_Load(object sender, EventArgs e)
        {
            string fileName = string.Format("{0}\\data.xml", Application.StartupPath);
            if (File.Exists(fileName))
                App.PhoneBook.ReadXml(fileName);

            phoneBookBindingSource.DataSource = App.PhoneBook;
            mainPanel.Enabled = false;
        }

        static AppData db;
        protected static AppData App
        {
            get
            {
                if (db == null)
                    db = new AppData();
                return db;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            try
            {
                mainPanel.Enabled = true;
                App.PhoneBook.AddPhoneBookRow(App.PhoneBook.NewPhoneBookRow());
                phoneBookBindingSource.MoveLast();
                textPhone.Focus();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App.PhoneBook.RejectChanges();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            mainPanel.Enabled = true;
            textPhone.Focus();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                phoneBookBindingSource.EndEdit();
                App.PhoneBook.AcceptChanges();
                App.PhoneBook.WriteXml(string.Format("{0}\\data.xml", Application.StartupPath));
                mainPanel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App.PhoneBook.RejectChanges();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            phoneBookBindingSource.ResetBindings(false);
            mainPanel.Enabled = false;
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete this contact?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    phoneBookBindingSource.RemoveCurrent();
            }
        }

        private void functiecarenufacenimic()
        {
            /*
             lskdgfhksdfsd
             \fsd
             fsd
             fsd
             fs
             df
             sdf
             sdf
             sd*/
        }
    }
}
