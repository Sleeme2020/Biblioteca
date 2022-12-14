using ModelBiblioteca.Models;
using ModelBiblioteca.behavior;
using System.ComponentModel;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            StartThreeLoad();
        }

        void StartThreeLoad()
        {
            treeView1.Nodes.Clear();
            Category[] categories = BehavorBook.GetCatalog().Where(u=>u.Categor==null).ToArray();
            foreach (Category category in categories)
            {
                TreeNode treeNode = new TreeNode() {  Text = category.ToString(),Tag = category};
                LoadThree(treeNode, category);
                treeView1.Nodes.Add(treeNode);
            }
            
        }


        void LoadThree(TreeNode treeNode,Category categor)
        {
            Category[] categories = BehavorBook.GetCatalogs(categor);
            
                foreach(Category category in categories)
                {
                    TreeNode treeNode1 = new TreeNode() { Text = category.ToString(), Tag = category };
                    LoadThree(treeNode1, category);
                    treeNode.Nodes.Add(treeNode1);
                }
                        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                NewCategoryBook newCategoryBook = new NewCategoryBook(NewCategoryBook.TypeObj.Category);
                if (newCategoryBook.ShowDialog() == DialogResult.OK)
                {
                    BehaviorCatalog.add(newCategoryBook.Tag as Category);
                    StartThreeLoad();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NewCategoryBook newCategoryBook = new NewCategoryBook(NewCategoryBook.TypeObj.Book);
                if (newCategoryBook.ShowDialog() == DialogResult.OK)
                {
                    BehaviorCatalog.add(newCategoryBook.Tag as Category);
                    StartThreeLoad();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                NewCategoryBook newCategoryBook = new NewCategoryBook(NewCategoryBook.TypeObj.Book,treeView1.SelectedNode.Tag as Category);
                if (newCategoryBook.ShowDialog() == DialogResult.OK)
                {
                    BehaviorCatalog.Update(newCategoryBook.Tag as Category);
                    StartThreeLoad();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        void updinstance()
        {
            listBox1.Items.Clear();
            if (treeView1.SelectedNode.Tag is Book)
            {
                listBox1.Items.AddRange(BehaviorInstanse.GetInstanceBooks());
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Book)
            {
                AddInstanse addInstanse = new();
                if (addInstanse.ShowDialog() == DialogResult.OK)
                {
                    BehaviorInstanse.Add(
                        new InstanceBook()
                        {
                            Book = treeView1.SelectedNode.Tag as Book,
                            Number = addInstanse.textBox1.Text
                        }
                        );
                    updinstance();
                }
            }else
            {
                MessageBox.Show("Это не книга!");
            }
        }

        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            updinstance();
        }
    }
}