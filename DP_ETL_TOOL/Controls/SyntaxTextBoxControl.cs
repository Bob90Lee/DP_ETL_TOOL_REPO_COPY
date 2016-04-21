using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DP_ETL_TOOL.Controls
{
    public partial class SyntaxTextBoxControl : RichTextBox
    {

        XDocument doc = new XDocument();
        string words = "";

        Font basicFont = new Font("Times", 8, FontStyle.Regular);
        Font specialFont = new Font("Times", 8, FontStyle.Bold);

        Color basicColor = Color.Black;
        Color specialColor = Color.DarkBlue;

        bool controlState = false;

        public SyntaxTextBoxControl()
        {
            InitializeComponent();

            this.Font = basicFont;
            this.ForeColor = Color.Black;

            this.ShortcutsEnabled = true;

            doc = LoadDictionary();
            words = ParseDictionaryToString(doc);
        }

        
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (char.IsLetterOrDigit((char)e.KeyCode) && !controlState)
            {
                SyntaxHighlight(this, false, words);
            }


            if (e.KeyCode == Keys.Control)
            {
                controlState = false;
            }


        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.ControlKey)
            {
                controlState = true;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int position = this.SelectionStart;

            base.OnKeyPress(e);

            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                string s = this.Text;
                s = s.Substring(0, s.Length);
                this.Clear();
                this.AppendText(s);
                SyntaxHighlight(this, true, words);

                this.SelectionStart = position;
                this.Select(position, 0);
            }
            else if (char.IsLetterOrDigit(e.KeyChar))
            {
                SyntaxHighlight(this, false, words);

                this.SelectionStart = position;
                this.Select(position, 0);
            }

        }
        
        public void SyntaxHighlight(SyntaxTextBoxControl control, bool full, string words)
        {
            string dictionaryWords = words; // "(SELECT|AS|FROM|WHERE|GROUP|BY|ORDER|ASC|DESC|LEFT|RIGHT|INNER|JOIN)";

            Regex regex = new Regex(words);

            MatchCollection collection = regex.Matches(control.Text);

            int StartCursorPosition = control.SelectionStart;

            foreach (Match m in collection)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;

                if (full)
                {
                    control.Select(startIndex, StopIndex);
                    control.SelectionColor = specialColor;
                    control.SelectionFont = specialFont;
                    control.SelectionStart = StartCursorPosition;
                    control.SelectionColor = basicColor;
                }
                else {
                    if (startIndex >= control.SelectionStart - StopIndex - 1)
                    {
                        if (control.SelectionStart < control.TextLength)
                        {
                            control.SelectionColor = basicColor;
                        }

                        control.Select(startIndex, StopIndex);
                        control.SelectionColor = specialColor;
                        control.SelectionFont = specialFont;
                        control.SelectionStart = StartCursorPosition;
                        control.SelectionColor = basicColor;
                        control.SelectionFont = basicFont;

                    }

                    control.SelectionColor = basicColor;
                    control.SelectionFont = basicFont;

                }

                control.SelectionColor = basicColor;
                control.SelectionFont = basicFont;
                control.Select(control.SelectionStart, 0);
            }
        }

        private XDocument LoadDictionary()
        {
            XDocument doc = XDocument.Load(@"C:\Users\BORIS\Documents\Visual Studio 2015\Projects\DP_ETL_TOOL\DP_ETL_TOOL\Modules\Dictionaries\dic_orcl.xml");

            return doc;
        }

        private string ParseDictionaryToString(XDocument doc)
        {
            string output = "";

            StringBuilder sb = new StringBuilder();

            foreach (XElement element in doc.Root.Element("basic_words").Elements("word"))
            {
                //sb.Append(@"\s*");
                sb.Append(element.Value);
                //sb.Append(@"\s+");
                sb.Append("|");
            }

            output = sb.ToString();
            output += output.ToLower();
            output = output.Substring(0, output.Length - 1);

            // add coloring of comments

            return output;
        }

        public void RefreshSyntax()
        {
            SyntaxHighlight(this, true, words);
        }

    }
}
