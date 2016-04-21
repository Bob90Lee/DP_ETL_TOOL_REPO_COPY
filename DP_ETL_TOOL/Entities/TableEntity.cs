using System;
using System.Collections.Generic;

namespace DP_ETL_TOOL.Entities
{
    class TableEntity
    {
        private String tableName;
        private String tableSchema;
        private List<ColumnEntity> tableColumns = new List<ColumnEntity>();
        private List<IndexEntity> tableIndexes = new List<IndexEntity>();

        public TableEntity()
        {
            this.tableName = "TableNEW" + new Random().Next(10, 99);
        }

        public TableEntity(String tableName)
        {
            this.tableName = tableName;
            this.tableColumns = new List<ColumnEntity>();
            this.tableIndexes = new List<IndexEntity>();
        }

        public void SetTableName(String tableName)
        {
            this.tableName = tableName.ToUpper();
        }

        public void SetSchemaName(String schemaName)
        {
            this.tableSchema = schemaName.ToUpper();
        }

        public bool AddColumn(String columnName, String columnType, int columnLength, bool columnIsUnique)
        {
            ColumnEntity exists = null;

            foreach (ColumnEntity ce in tableColumns)
            {
                if (ce.GetColumnName() == columnName.ToUpper().Trim())
                {
                    exists = ce;
                }
            }

            if (exists == null)
            {
                ColumnEntity ce = new ColumnEntity(columnName.ToUpper().Trim(), columnType.ToUpper().Trim(), columnLength, columnIsUnique);
                tableColumns.Add(ce);
                return true; // ColumnEntity was added
            }
            else
            {
                return false; // ColumnEntity wasnt added because it already exists
            }

        }

        public bool AddIndex(String indexName, String indexType, List<ColumnEntity> indexColumns)
        {
            IndexEntity exists = null;

            foreach (IndexEntity index in tableIndexes)
            {
                if (index.GetIndexName() == indexName.ToUpper().Trim())
                {
                    exists = index;
                }
            }

            if (exists == null)
            {
                IndexEntity i = new IndexEntity(indexName.ToUpper().Trim(), indexType.ToUpper().Trim(), indexColumns);
                tableIndexes.Add(i);
                return true; // index was added
            }
            else
            {
                return false; // index wasnt added because it already exists
            }

        }

        public void RemoveColumn(String columnName)
        {
            if (tableColumns != null)
            {
                foreach (ColumnEntity ColumnEntity in tableColumns)
                {
                    if (ColumnEntity.GetColumnName() == columnName.ToUpper().Trim())
                    {
                        tableColumns.Remove(ColumnEntity);
                    }
                }
            }
        }

        public void RemoveIndex(String indexName)
        {
            foreach (IndexEntity index in tableIndexes)
            {
                if (index.GetIndexName() == indexName.ToUpper().Trim())
                {
                    tableIndexes.Remove(index);
                }
            }
        }

        public String GetName()
        {
            return tableName;
        }

        public String GetSchema()
        {
            return tableSchema;
        }

        public List<ColumnEntity> GetColumns()
        {
            return tableColumns;
        }

        public List<IndexEntity> GetIndexes()
        {
            return tableIndexes;
        }
    }
}
