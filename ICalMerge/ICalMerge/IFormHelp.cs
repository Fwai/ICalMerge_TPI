using System;
using System.Windows.Forms;

namespace ICalMerge
{
    public partial class IFormHelp : Form
    {
        public IFormHelp()
        {
            InitializeComponent();
            SourceComponents scExample = new SourceComponents(pnlSource, 0, pnlSource, this, ofdExample);
        }

        private void BtnCloseHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
