namespace DP_ETL_TOOL.Types
{
    class Enums
    {
        public enum JoinType
        {
            NULL,
            Left,
            Right,
            Inner,
            Full
        };

        public enum ModeType
        {
            NULL,
            Table,
            Transformation_View,
            Destination_View,
            Extraction_Procedure,
            Transformation_Procedure
        };

        public enum TableType
        {
            NULL,
            Source_Table,
            Extraction_Table,
            Load_Table,
            Destination_Table
        }

        public enum Layer
        {
            NULL,
            Extraction_Layer,
            Transformation_Layer,
            Load_Layer
        }

    }
}
