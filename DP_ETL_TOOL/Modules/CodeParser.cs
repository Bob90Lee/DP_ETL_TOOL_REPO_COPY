using DP_ETL_TOOL.Controls;
using DP_ETL_TOOL.Entities;
using DP_ETL_TOOL.Types;
using System.Collections.Generic;
using System.Text;

namespace DP_ETL_TOOL.Modules
{
    class CodeParser
    {
        private string code;
        private List<TableControl> tables;
        private List<JoinControl> joins;

        public CodeParser(Enums.ModeType mode, List<TableControl> tables, List<JoinControl> joins)
        {
            if (mode == Enums.ModeType.View)
            {
                this.tables = tables;
                this.joins = joins;
                this.code = GenerateViewCode(this.tables, this.joins);
            }

            else if (mode == Enums.ModeType.Table)
            {
                this.tables = tables;
                this.joins = null;
                this.code = GenerateTableCode(this.tables);
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

                sb.AppendLine("CREATE TABLE " + te.GetSchema() + te.GetName());
                sb.AppendLine("(");

                foreach (ColumnEntity ce in te.GetColumns())
                {
                    sb.Append("\t" + ce.GetColumnName() + "\t\t\t\t" + ce.GetColumnType() + "(" + ce.GetColumnLength() + ")");
                    if (i < tables.Count)
                    {
                        sb.AppendLine(",");
                    }
                    else {
                        sb.AppendLine();
                    }
                }

                sb.AppendLine(");\n\n / \n\n");

            }

            return sb.ToString();
        }

        public string GetCode()
        {
            return this.code;
        }

    }
}
