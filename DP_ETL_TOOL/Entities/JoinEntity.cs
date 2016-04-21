using DP_ETL_TOOL.Types;
using System.Collections.Generic;

namespace DP_ETL_TOOL.Entities
{
    class JoinEntity
    {
        private Enums.JoinType joinType;
        private List<ColumnPairEntity> joinPairs;

        public JoinEntity(Enums.JoinType joinType)
        {
            this.joinType = joinType;
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
    }
}
