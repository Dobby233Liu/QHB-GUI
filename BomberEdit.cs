using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 专治骗子;

namespace QHB_GUI
{
    public partial class BomberEdit : Form
    {
        public Boolean EditMode = true;
        public int origObjIndex = 0;
        public 骗骗子神器 refForm;

        public BomberEdit()
        {
            InitializeComponent();
        }

        private void BomberEdit_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 1;
        }

        public void Updating()
        {
            if (EditMode) return;
            var o = refForm.list[origObjIndex];
            // comboBox1.SelectedIndex = (o.GetType().Name.Equals("GeneralBomberWithAdditional") ? 1 : 0);
            comboBox2.SelectedIndex = (o.HttpMethod.ToUpper().Equals("POST") ? 1 : 0);
            textBox5.Text = o.UserKey; //username key
            textBox2.Text = o.PassowordKey; //password key
            //if(comboBox1.SelectedIndex == 1)
            //{
                // todo
            //}
        }
    }
}
