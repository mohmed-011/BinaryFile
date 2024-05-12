using System.IO;
using System.Windows.Forms;
using static BinaryFile.InsertForm;

namespace BinaryFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public int current = 0;
        public static List<student> studList = new List<student>();
        public bool less = false;

        public struct student
        {
            public int id;
            public string name;
            public string tel;
            public int year;
            public string gender;

        };
        private void button1_Click(object sender, EventArgs e)
        {
            Info.FileName = "D:\\" + FileNameBox.Text + ".txt";

            if(File.Exists(Info.FileName))
            {
                errorLapel.Visible = true;
            }
            else
            {
                File.CreateText(Info.FileName);
                MessageBox.Show("File is Created Successfully");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Info.FileName = "D:\\" + FileNameBox.Text + ".txt";
            File.Delete(Info.FileName);
            MessageBox.Show(" File is Deleted");
            FileNameBox.Clear();
            errorLapel.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            // new InsertForm().Show();
            InsertForm ss = new InsertForm();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new display().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new search_Delete().Show();
        }
    }
}