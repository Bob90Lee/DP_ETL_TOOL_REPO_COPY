using System;
using System.Collections.Generic;

namespace DP_ETL_TOOL.Entities
{
    class IndexEntity
    {
        private String indexName;
        private String indexType;
        private List<ColumnEntity> indexColumns;

        public IndexEntity(String name, String type, List<ColumnEntity> columns)
        {
            this.indexName = name.ToUpper();
            this.indexType = type.ToUpper();
            this.indexColumns = new List<ColumnEntity>();
            this.indexColumns = columns;
        }

        public String GetIndexName()
        {
            return this.indexName;
        }

        public String getIndesType()
        {
            return this.indexType;
        }

        public List<ColumnEntity> getIndexColumns()
        {
            return this.indexColumns;
        }
    }
}
