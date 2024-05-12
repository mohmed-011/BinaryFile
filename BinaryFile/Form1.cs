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

            if(!File.Exists(Info.FileName))
            {
                File.CreateText(Info.FileName);
                MessageBox.Show("File is Created Successfully");
                
            }
            else
            {
                errorLapel.Visible = true;
            }

            student s;

            BinaryReader br = new BinaryReader(File.Open(Info.FileName, FileMode.Open, FileAccess.Read));

            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                s.id = br.ReadInt32();
                s.name = br.ReadString();
                s.tel = br.ReadString();
                s.year = br.ReadInt32();
                s.gender = br.ReadString();

                if (!studList.Any())
                {
                    studList.Add(s);
                }

                else
                {

                    foreach (student x in studList)
                    {
                        if (s.id < x.id)//check if the id to insert less than the any id saved in list

                        {
                            current = studList.LastIndexOf(x);//save the index
                            less = true;
                            break;
                        }
                    }
                    if (!less)//if the id to insert greater than the last id saved in list

                    {
                        studList.Add(s);//insert in the end of list

                    }
                    else
                    {
                        studList.Insert(current, s);//insert before current id
                        less = false;
                    }
                }
            }
            br.Close();

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