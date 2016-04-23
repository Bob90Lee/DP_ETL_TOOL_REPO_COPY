using System.Runtime.Serialization;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class ColumnPairEntity
    {
        [DataMember]
        private ColumnEntity parentColumn;
        [DataMember]
        private ColumnEntity childColumn;

        public ColumnPairEntity()
        {

        }

        public ColumnPairEntity(ColumnEntity parentColumn, ColumnEntity childColumn)
        {
            this.parentColumn = parentColumn;
            this.childColumn = childColumn;
            //this.parentTableName = parentTable.GetName();
            //this.childTableName = childTable.GetName();
        }

        public void SetParentColumn(ColumnEntity parentColumn)
        {
            this.parentColumn = parentColumn;
        }

        public void SetChildColumn(ColumnEntity childColumn)
        {
            this.childColumn = childColumn;
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
