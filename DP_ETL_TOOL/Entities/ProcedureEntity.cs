using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class ProcedureEntity
    {
        [DataMember]
        private TableEntity sourceTable;
        [DataMember]
        private TableEntity destinationTable;
        [DataMember]
        private List<WhereConditionEntity> whereConditions;

        public ProcedureEntity()
        {

        }

        public ProcedureEntity(TableEntity sourceTable, TableEntity destinationTable, List<WhereConditionEntity> whereConditions)
        {
            this.sourceTable = sourceTable;
            this.destinationTable = destinationTable;
            this.whereConditions = whereConditions;
        }

        public void SetSourceTable(TableEntity sourceTable)
        {
            this.sourceTable = sourceTable;
        }

        public void SetDestionationTable(TableEntity destinationTable)
        {
            this.destinationTable = destinationTable;
        }

        public bool AddWhereCondition(WhereConditionEntity whereCondition)
        {
            whereConditions.Add(whereCondition);

            return true;
        }

        public bool RemoveWhereCondition(WhereConditionEntity whereCondition)
        {
            whereConditions.Remove(whereCondition);

            return true;
        }

        public TableEntity GetSourceTable()
        {
            return this.sourceTable;
        }

        public TableEntity GetDestinationTable()
        {
            return this.destinationTable;
        }

        public List<WhereConditionEntity> GetWhereCondition()
        {
            return this.whereConditions;
        }
    }
}
