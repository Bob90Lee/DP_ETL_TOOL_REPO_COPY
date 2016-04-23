using DP_ETL_TOOL.Types;
using System.Collections.Generic;

namespace DP_ETL_TOOL.Entities
{
    class JoinEntity
    {
        private Enums.JoinType joinType;
        private List<ColumnPairEntity> joinPairs;
        private TableEntity mainTable;
        private TableEntity childTable;

        public JoinEntity(Enums.JoinType joinType, TableEntity mainTable, TableEntity childTable)
        {
            this.joinType = joinType;
            this.joinPairs = new List<ColumnPairEntity>();
            this.mainTable = mainTable;
            this.childTable = childTable;
        }

        public void AddJoinPair(ColumnPairEntity joinPair)
        {
            this.joinPairs.Add(joinPair);
        }

        public bool RemoveJoinPair(ColumnPairEntity joinPair)
        {
            this.joinPairs.Remove(joinPair);

            return true;
        }

        public List<ColumnPairEntity> GetJoinPairs()
        {
            return this.joinPairs;
        }

        public ColumnPairEntity IsMainJoin(string tableName)
        {
            foreach (ColumnPairEntity columnPair in joinPairs)
            {
                if (columnPair.GetParentTable().GetName().Trim().ToUpper() == tableName.Trim().ToUpper())
                {
                    return columnPair;
                }
            }

            return null;
        }

        public Enums.JoinType GetJoinType()
        {
            return this.joinType;
        }

        public TableEntity GetMainTable()
        {
            return mainTable;
        }

        public TableEntity GetChildTable()
        {
            return childTable;
        }

        public void SetMainTable(TableEntity mainTable)
        {
            this.mainTable = mainTable;
        }

        public void SetChildTable(TableEntity childTable)
        {
            this.childTable = childTable;
        }
    }
}
