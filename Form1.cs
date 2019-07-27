using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 专治骗子;


namespace QHB_GUI
{
    public partial class 骗骗子神器 : Form
    {
        public List<GeneralBomber> list = new List<GeneralBomber>();
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
        public 骗骗子神器()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
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
            if(listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("没有选择任务", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BomberEdit be = new BomberEdit();
            be.refForm = this;
            be.origObjIndex = listBox1.SelectedIndex;
            be.Updating();
            be.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("没有选择任务", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var bomber = list[listBox1.SelectedIndex];
            BomberPerformer performer = new BomberPerformer(bomber);//创建轰炸实例
            performer.ThreadCount = 128;//128线程
            bomber.OnBomberComplete += Bomber_OnBomberComplete; ;//当请求成功时的事件
            performer.StartBomber();
        }

        private void Bomber_OnBomberComplete(object sender, BomberResultEventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            BomberEdit be = new BomberEdit();
            be.refForm = this;
            be.origObjIndex = list.Count;
            Debug.WriteLine(list.Count);
            be.EditMode = false;
            be.ShowDialog();
            // be.Updating(); This time we'll not use a existing Bomber
        }
    }
}
