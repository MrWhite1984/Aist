using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aist
{
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveForm_Load(object sender, EventArgs e)
        {
            if(consultationsNum == 0)
            {
                consultationsDocCheckBox.Enabled = false;
                consultationsJsonBheckBox.Enabled = false;
            }
        }
    }
}
