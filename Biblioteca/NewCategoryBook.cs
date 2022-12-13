using ModelBiblioteca.behavior;
using ModelBiblioteca.Models;
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
    public partial class NewCategoryBook : Form
    {
        public enum TypeObj
        {
            Book,
            Category
        }
        TypeObj TypeCat { get; set; }
        Category category;
        Category Category {
            get
            {
                return category;
            }
            set
            {
                category = value;
                if (category == null) return;
                switch(category)
                {
                    case Book book:

                        break;

                    case Category cat:

                        break;
                }
            }
        }
        public NewCategoryBook(TypeObj typeObj,Category category=null)
        {
           
            InitializeComponent();
            TypeCat = typeObj;
            Category = category;
            if (typeObj == TypeObj.Category)
                panel1.Visible = false;
            comboBox1.Items.AddRange(BehavorBook.GetCategory());
            //if(typeObj == TypeObj.Book)
            //    comboBox2.Items.AddRange(BehavorBook.);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Tag = GetCategory();
        }

        Category GetCategory()
        {
            switch(TypeCat)
            {
                case TypeObj.Book:

                    return new Book()
                    {
                        Categor = comboBox1.SelectedItem as Category,
                        Name=textBox1.Text,
                        Autor=comboBox2.SelectedItem as Autor,
                        Title=richTextBox1.Text,
                        PublicDate =dateTimePicker1.Value
                    };

                case TypeObj.Category:

                    return new Category()
                    {
                        Categor = comboBox1.SelectedItem as Category,
                        Name = textBox1.Text
                    };

                    default:                    
                    throw new Exception("Не верный параметр");
                   
            }
        }
    }
}
