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
using System.Windows.Forms.Design.Behavior;

namespace Biblioteca
{
    public partial class AddAutors : Form
    {
        public AddAutors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BehaviorAutor.AddAutor(new ModelBiblioteca.Models.Autor()
            {
                 FirstName = textBox1.Text,
                 Name = textBox2.Text,
                 LastName = textBox3.Text,
                 BirthDay = dateTimePicker1.Value
            }
            );
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
