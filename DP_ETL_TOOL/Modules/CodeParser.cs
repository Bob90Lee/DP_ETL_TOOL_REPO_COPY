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

        public CodeParser(Enums.ModeType mode, List<TableControl> tables, List<JoinControl> joins )
        {
            if (mode == Enums.ModeType.View)
            {
                this.tables = tables;
                this.joins = joins;
                this.code = GenerateViewCode(this.tables, this.joins);
            }
        }

        private string GenerateViewCode(List<TableControl> tables, List<JoinControl> joins)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CREATE OR REPLACE VIEW");
            sb.AppendLine("AS");
            sb.AppendLine("SELECT");
            sb.Append("\t");
            sb.AppendLine("*");
            sb.Append("FROM ");

            int i = 0;

            foreach (TableControl t in tables)
            {
                i++;

                TableEntity te = t.getTableEntity();
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

        public string GetCode()
        {
            return this.code;
        }

    }
}
