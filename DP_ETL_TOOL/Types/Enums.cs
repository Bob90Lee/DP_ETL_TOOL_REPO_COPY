using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_ETL_TOOL.Types
{
    class Enums
    {
        public enum JoinType
        {
            Left,
            Right,
            Inner,
            Full
        };

        public enum ModeType
        {
            Table,
            View,
            Extraction_Procedure
        };

    }
}
