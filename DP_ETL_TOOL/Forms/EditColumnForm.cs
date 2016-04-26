using System.Windows.Forms;

namespace DP_ETL_TOOL.Forms
{
    public partial class EditColumnForm : Form
    {
        public EditColumnForm()
        {
            InitializeComponent();

            chckIsUnique.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
