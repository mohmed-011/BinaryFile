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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BinaryFile
{
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();

           
        }

        public struct student
        {
            public int id;
            public string name;
            public string tel;
            public int year;
            public string gender;


        };

        public static List<student> studList = new List<student>();
        public bool less = false;
        public int current = 0;
        public int length = 0;

        public void clearPrint()
        {
           MessageBox.Show("Student is added Successfully", "Done",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
           ID.Clear(); Namee.Clear(); Tel.Clear(); Year.Clear(); Gender.Clear();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (!studList.Any())
            {
                MessageBox.Show("Empty List ☹ ", "Oops");
            }
            else
            {
                BinaryWriter bw = new BinaryWriter(File.Open(Info.FileName, FileMode.Open, FileAccess.Write));

                length = (int)bw.BaseStream.Length;

                foreach (student item in studList)
                {
                    bw.Write(item.id);      

                    item.name.PadRight(9); 
                    bw.Write(item.name.Substring(0, 9));

                    item.tel.PadRight(11); 
                    bw.Write(item.tel.Substring(0, 11));

                    bw.Write(item.year );  

                    bw.Write(item.gender.Substring(0, 1)); 
                }
                bw.Close();
                MessageBox.Show("Student List Saved 😊 ");
            }
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Info.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {

            student s;
            
            s.id = int.Parse(ID.Text);
            s.name = Namee.Text.PadRight(9);
            s.tel = Tel.Text.PadRight(11);
            s.year = int.Parse(Year.Text);
            s.gender = Gender.Text;



        if (!studList.Any())
        {
             studList.Add(s);
             clearPrint();
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
                clearPrint();
            }
            else
            {
                studList.Insert(current, s);//insert before current id
                clearPrint();
                less = false;
            }
        }
            

        }
    }
}
