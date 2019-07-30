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
            comboBox1.SelectedIndex = 1;
        }

        public void Updating()
        {
            if (!EditMode) return;
            var o = refForm.list[origObjIndex];
            comboBox1.SelectedIndex = (o.GetType().Name.Equals("GeneralBomberWithAdditional") ? 1 : 0);
            comboBox2.SelectedIndex = (o.HttpMethod.ToUpper().Equals("POST") ? 1 : 0);
            textBox5.Text = o.UserKey; //username key
            textBox2.Text = o.PassowordKey; //password key
            textBox1.Text = o.BaseUrl; // url
            if(comboBox1.SelectedIndex == 1)
            {
                var oWithAdditional = (GeneralBomberWithAdditional)o;
                // textBox3=add key, textBox4=add val
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox3.Text = oWithAdditional.AdditionalKeyValue.First().Key;
                textBox4.Text = oWithAdditional.AdditionalKeyValue.First().Value; // todo: if muitl AKVs, how 2 handle?
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (EditMode)
                {
                    refForm.list[origObjIndex] = new GeneralBomber(textBox1.Text, textBox5.Text, textBox2.Text, comboBox2.Text);
                }
                else
                {
                    refForm.list.Add(new GeneralBomber(textBox1.Text, textBox5.Text, textBox2.Text, comboBox2.Text));
                }
            } else if (comboBox1.SelectedIndex == 1)
            {
                if (EditMode)
                {
                    refForm.list[origObjIndex] = new GeneralBomberWithAdditional(textBox1.Text, textBox5.Text, textBox2.Text, comboBox2.Text, new KeyValuePair<string, string>(textBox3.Text, textBox4.Text));
                }
                else
                {
                    refForm.list.Add(new GeneralBomberWithAdditional(textBox1.Text, textBox5.Text, textBox2.Text, comboBox2.Text, new KeyValuePair<string, string>(textBox3.Text, textBox4.Text)));
                }
            } else
            {
                MessageBox.Show("类型无效", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refForm.UpdateList();
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0) // toggle editablity
            {
                textBox3.Enabled = false;
                textBox3.ReadOnly = true;
                textBox4.Enabled = false;
                textBox4.ReadOnly = true;
            }
        }
    }
}
