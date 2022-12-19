using ModelBiblioteca.behavior;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class AddTrafficForm : Form
    {
        public AddTrafficForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUserForm addUserForm = new();
            if(addUserForm.ShowDialog()== DialogResult.OK)
            {
                BehaviorUser.AddUser(
                    new ModelBiblioteca.Models.User()
                    {
                        BirthDay = addUserForm.dateTimePicker1.Value,
                        CreatedDate = DateTime.Now,
                         FirstName = addUserForm.textBox1.Text,
                          LastName = addUserForm.textBox2.Text
                    }
                    );
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(BehaviorUser.GetUsers());
            }


        }
    }
}
