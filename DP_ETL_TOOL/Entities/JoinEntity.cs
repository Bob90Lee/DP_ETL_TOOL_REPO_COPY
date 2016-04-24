using DP_ETL_TOOL.Types;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class JoinEntity
    {
        [DataMember]
        private Enums.JoinType joinType;
        [DataMember]
        private List<ColumnPairEntity> joinPairs;
        [IgnoreDataMember]
        private TableEntity mainTable;
        [IgnoreDataMember]
        private TableEntity childTable;
        [DataMember]
        private string mainTableName;
        [DataMember]
        private string childTableName;
        [DataMember]
        private GUICoordsEntity coords;

        public JoinEntity()
        {

        }

        public JoinEntity(Enums.JoinType joinType, TableEntity mainTable, TableEntity childTable)
        {
            this.joinType = joinType;
            this.joinPairs = new List<ColumnPairEntity>();
            this.mainTable = mainTable;
            this.childTable = childTable;
            this.coords = new GUICoordsEntity();
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

        public bool IsJoinPairsEmpty()
        {
            if (joinPairs.Count > 0)
            {
                return false;
            }

            return true;
        }

        public bool FindExistingJoinPair(string mainTableColumnName, string childTableColumnName)
        {
            if (IsJoinPairsEmpty())
            {
                return false;
            }
            else
            {
                foreach (ColumnPairEntity ce in joinPairs)
                {
                    if (ce.GetParentColumn().GetColumnName() == mainTableColumnName.Trim().ToUpper() && ce.GetChildColumn().GetColumnName() == childTableColumnName.Trim().ToUpper())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void RefreshNames()
        {
            this.mainTableName = mainTable.GetName();
            this.childTableName = childTable.GetName();
        }

        public GUICoordsEntity GetCoords()
        {
            return this.coords;
        }

        public string GetMainTableName()
        {
            return this.mainTableName;
        }

        public string GetChildTableName()
        {
            return this.childTableName;
        }
    }
}
