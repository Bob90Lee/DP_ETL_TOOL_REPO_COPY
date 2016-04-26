using DP_ETL_TOOL.Controls;
using DP_ETL_TOOL.Entities;
using DP_ETL_TOOL.Types;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DP_ETL_TOOL.Modules
{
    class CodeParser
    {
        private string code;
        private List<TableControl> tables;
        private List<JoinControl> joins;

        public CodeParser(Enums.ModeType mode, List<Control> ctrls, LayerMemberEntity objectEntity)
        {
            tables = new List<TableControl>();
            joins = new List<JoinControl>();

            ClassifyControlTypes(ctrls);

            if (mode == Enums.ModeType.Transformation_View)
            {
                this.code = GenerateViewCode(this.tables, this.joins);
            }

            else if (mode == Enums.ModeType.Table)
            {
                this.code = GenerateTableCode(this.tables);
            }

            else if (mode == Enums.ModeType.Extraction_Procedure)
            {
                this.code = GenerateExtractionProcedureCode(this.tables, objectEntity);
            }

            else
            {
                this.code = "";
            }

        }

        private string GenerateViewCode(List<TableControl> tables, List<JoinControl> joins)
        {


            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CREATE OR REPLACE VIEW");
            sb.AppendLine("AS");
            sb.AppendLine("SELECT");
            //sb.Append("\t");
            sb.AppendLine("\t*");
            sb.Append("FROM ");

            int i = 0;

            foreach (TableControl t in tables)
            {
                i++;

                TableEntity te = t.GetTableEntity();
                sb.Append(te.GetSchema());
                sb.Append(".");

                if (i < tables.Count)
                {
                    sb.AppendLine(te.GetName());
                    sb.Append("JOIN ");
                }
                else
                {
                    sb.Append(te.GetName());
                }
            }

            sb.Append(";");

            return sb.ToString();

        }

        private string GenerateTableCode(List<TableControl> tables)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;

            foreach (TableControl t in tables)
            {
                i++;

                TableEntity te = t.GetTableEntity();

                if (te.GetSchema() == null)
                {
                    sb.AppendLine("CREATE TABLE " + te.GetName());
                }
                else
                {
                    sb.AppendLine("CREATE TABLE " + te.GetSchema() + "." + te.GetName());
                }
                sb.AppendLine("(");

                foreach (ColumnEntity ce in te.GetColumns())
                {
                    sb.Append("\t" + ce.GetColumnName() + "\t\t" + ce.GetColumnType() + "(" + ce.GetColumnLength() + ")");
                    if (i == tables.Count)
                    {
                        sb.AppendLine();

                    }
                    else {
                        sb.AppendLine(",");
                    }
                }

                sb.AppendLine(");\n\n / \n\n");

            }

            return sb.ToString();
        }

        private string GenerateExtractionProcedureCode(List<TableControl> tables, LayerMemberEntity procedure)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;

            sb.AppendLine("CREATE OR REPLACE PROCEDURE " + procedure.GetMemberName() + "( IMPORT_ID IN NUMBER )");
            sb.AppendLine("IS");
            sb.AppendLine("BEGIN");

            //
            sb.AppendLine("/* here will be the control procedure start call */");
            //

            //
            sb.AppendLine("/* here will be the control procedure finish call */");
            //

            sb.AppendLine("EXCEPTION");
            sb.AppendLine("\t WHEN OTHERS THEN NULL; -- exception handling");

            sb.AppendLine("END;");

            return sb.ToString();
        }

        public string GetCode()
        {
            return this.code;
        }

        private void ClassifyControlTypes(List<Control> controls)
        {
            tables.Clear();
            joins.Clear();

            foreach (Control c in controls)
            {
                if (c.GetType() == typeof(TableControl))
                {
                    tables.Add((TableControl)c);
                }
                else if (c.GetType() == typeof(JoinControl))
                {
                    joins.Add((JoinControl)c);
                }
            }
        }

    }
}
