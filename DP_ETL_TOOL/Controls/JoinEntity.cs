using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_ETL_TOOL.Controls
{
    class JoinEntity
    {
        private TableEntity mainTable;
        private TableEntity childTable;

        public JoinEntity()
        {
            
        }

        public void setMainTable(TableEntity te)
        {
            mainTable = te;
        }

        public void setChildEntity(TableEntity te)
        {
            childTable = te;
        }

        public TableEntity getMainTable()
        {
            return mainTable;
        }

        public TableEntity getChildTable()
        {
            return childTable;
        }
    }
}
