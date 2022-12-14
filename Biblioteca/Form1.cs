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

        void UpdKeyWord()
        {
            richTextBox1.Text.Trim();
            if(treeView1.SelectedNode.Tag is Book)
            {
                var Word=BehaviorWordKey.GetWordKey(treeView1.SelectedNode.Tag as Book); 
                foreach(var word in Word)
                {
                    richTextBox1.Text += word.Name + ",";
                }
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
                            Number = addInstanse.textBox1.Text,                            
                        }.NewState()
                        );
                    updinstance();
                }
            }else
            {
                MessageBox.Show("??? ?? ?????!");
            }
        }

        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            updinstance();
            UpdKeyWord();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Book)
            {
                AddWord addWord = new AddWord();
                if (addWord.ShowDialog() == DialogResult.OK)
                {
                    BehaviorWordKey.AddWordKey(treeView1.SelectedNode.Tag as Book, addWord.textBox1.Text);
                    UpdKeyWord();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem is InstanceBook)
            {
                TrafficBookForm trafficBook = new TrafficBookForm();
                trafficBook.listBox1.Items.AddRange(
                    BehaviorTraffic.GetTrafficBooks(
                        listBox1.SelectedItem as InstanceBook
                        )
                    );
                trafficBook.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is InstanceBook)
            {
                AddTrafficForm addTrafficForm = new();
                addTrafficForm.comboBox1.Items.AddRange(BehaviorUser.GetUsers());
                addTrafficForm.label1.Text = $"{treeView1.SelectedNode.Tag as Book} ({listBox1.SelectedItem is InstanceBook})";
                if(addTrafficForm.ShowDialog()==DialogResult.OK)
                {
                    var trafficBook = new TrafficBook()
                    {
                         Date = addTrafficForm.dateTimePicker1.Value,
                         User = addTrafficForm.comboBox1.SelectedItem as User,
                         Instance = listBox1.SelectedItem as InstanceBook,
                         TrafficDir = addTrafficForm.radioButton1.Checked?TrafficDir.inUser:TrafficDir.inlibraly

                    };
                    BehaviorTraffic.SetTrafficBook(trafficBook);
                    updinstance();
                }
            }
        }
    }
}