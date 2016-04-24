using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DP_ETL_TOOL.Types;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class TableEntity
    {
        [DataMember]
        private String tableName;
        [DataMember]
        private String tableSchema;
        [DataMember]
        private List<ColumnEntity> tableColumns = new List<ColumnEntity>();
        [DataMember]
        private List<IndexEntity> tableIndexes = new List<IndexEntity>();
        [DataMember]
        private List<JoinEntity> tableJoins = new List<JoinEntity>();
        [DataMember]
        private GUICoordsEntity coords;
        [DataMember]
        private Enums.TableType tableType;

        public TableEntity(Enums.TableType tableType)
        {
            this.tableName = "TableNEW" + new Random().Next(10, 99);
            this.coords = new GUICoordsEntity();
            this.tableType = tableType;
        }

        public TableEntity(String tableName, Enums.TableType tableType)
        {
            this.tableName = tableName;
            this.coords = new GUICoordsEntity();
            this.tableType = tableType;
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

        public ColumnEntity GetColumnByName(string columnName)
        {
            if (tableColumns != null)
            {
                foreach (ColumnEntity column in tableColumns)
                {
                    if (column.GetColumnName() == columnName.ToUpper().Trim())
                    {
                        return column;
                    }
                }
            }

            return null;
        }

        public List<IndexEntity> GetIndexes()
        {
            return tableIndexes;
        }

        public List<JoinEntity> GetJoins()
        {
            return tableJoins;
        }

        public void AddJoinEntity(JoinEntity join)
        {
            tableJoins.Add(join);
        }

        public GUICoordsEntity GetCoords()
        {
            return this.coords;
        }

        public Enums.TableType GetTableType()
        {
            return this.tableType;
        }
    }
}
