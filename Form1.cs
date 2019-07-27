using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 专治骗子;


namespace QHB_GUI
{
    public partial class 骗骗子神器 : Form
    {
        public List<GeneralBomber> list;
        public MemoryStream st;
        public StreamWriter sw;
        public StreamReader streamReader;
        public 骗骗子神器()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            st = new MemoryStream();
            sw = new StreamWriter(st);
            streamReader = new StreamReader(st);
            Console.SetOut(sw);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("user open aboutbox");
            new AboutBox().ShowDialog();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (GeneralBomber i in list)
            {
                listBox1.Items.Add(i.GetType() + "(url:" + i.BaseUrl + ")");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new BomberEdit().ShowDialog();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("tick");
            string str = streamReader.ReadLine();
            if (str != null)
            {
                textBox1.Text += str;
                textBox1.Text += "\n";
                Debug.WriteLine("tick: writeline");
            }
            Debug.WriteLine("tick: end");
        }
    }
}
