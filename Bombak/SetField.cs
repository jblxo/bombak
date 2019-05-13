using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombak
{
    public partial class SetField : Form
    {
        private int x;
        private int y;

        public SetField()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            x = (int) numericUpDownX.Value;
            y = (int) numericUpDownY.Value;
            Settings.Instance.fieldSize.Width = x;
            Settings.Instance.fieldSize.Height = y;

            openMainForm();
        }

        private void openMainForm()
        {
            MainForm mainForm = new MainForm();

            mainForm.FormClosing += mainFormClosing;

            mainForm.Show();
            mainForm.Focus();
            this.Hide();
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            this.Focus();
        }
    }
}
