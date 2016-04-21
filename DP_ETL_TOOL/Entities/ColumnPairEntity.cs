namespace DP_ETL_TOOL.Entities
{
    class ColumnPairEntity
    {
        private TableEntity parentTable;
        private TableEntity childTable;
        private ColumnEntity parentColumn;
        private ColumnEntity childColumn;

        public ColumnPairEntity(TableEntity parentTable, TableEntity childTable, ColumnEntity parentColumn, ColumnEntity childColumn)
        {
            this.parentTable = parentTable;
            this.childTable = childTable;
            this.parentColumn = parentColumn;
            this.childColumn = childColumn;
        }

        public void SetParentTable(TableEntity parentTable)
        {
            this.parentTable = parentTable;
        }

        public void SetChildTable(TableEntity childTable)
        {
            this.childTable = childTable;
        }

        public void SetParentColumn(ColumnEntity parentColumn)
        {
            this.parentColumn = parentColumn;
        }

        public void SetChildColumn(ColumnEntity childColumn)
        {
            this.childColumn = childColumn;
        }

        public TableEntity GetParentTable()
        {
            return this.parentTable;
        }

        public TableEntity GetChildTable()
        {
            return this.childTable;
        }

        public ColumnEntity GetParentColumn()
        {
            return this.parentColumn;
        }

        public ColumnEntity GetChildColumn()
        {
            return this.childColumn;
        }
    }
}
