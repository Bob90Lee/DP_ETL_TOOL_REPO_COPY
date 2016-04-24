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

        public enum TableType
        {
            Source_Table,
            Extraction_Table,
            Load_Table,
            Destination_Table
        }

    }
}
