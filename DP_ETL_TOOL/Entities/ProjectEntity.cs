using DP_ETL_TOOL.Controls;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class ProjectEntity
    {
        [IgnoreDataMember]
        private List<TableControl> tables;
        [IgnoreDataMember]
        private List<JoinControl> joins;
        [DataMember]
        private List<TableEntity> tableEntities;
        [DataMember]
        private List<JoinEntity> joinEntities;

        public ProjectEntity()
        {
            this.tables = new List<TableControl>();
            this.joins = new List<JoinControl>();
            this.tableEntities = new List<TableEntity>();
            this.joinEntities = new List<JoinEntity>();
        }

        public void AddTable(TableControl table)
        {
            this.tables.Add(table);
        }

        public void AddJoin(JoinControl join)
        {
            this.joins.Add(join);
        }

        public void RemoveTable(string tableName)
        {
            foreach (TableControl tc in tables)
            {
                if (tc.GetTableEntity().GetName().ToUpper().Trim() == tableName.ToUpper().Trim())
                {
                    tables.Remove(tc);
                    tc.Dispose();

                    RemoveTableSpecificJoin(tableName);
                }
            }
        }

        public void RemoveJoin(string parentTable, string childTable)
        {
            foreach (JoinControl jc in joins)
            {
                if (jc.GetMainTable().GetTableEntity().GetName().ToUpper().Trim() == parentTable.ToUpper().Trim() && jc.GetChildTable().GetTableEntity().GetName().ToUpper().Trim() == childTable.ToUpper().Trim())
                {
                    joins.Remove(jc);
                    jc.Dispose();
                }
            }
        }

        public void RemoveTableSpecificJoin(string tableName)
        {
            foreach (JoinControl jc in joins)
            {
                if (jc.GetMainTable().GetTableEntity().GetName().ToUpper().Trim() == tableName.ToUpper().Trim() || jc.GetChildTable().GetTableEntity().GetName().ToUpper().Trim() == tableName.ToUpper().Trim())
                {
                    joins.Remove(jc);
                    jc.Dispose();
                }
            }
        }

        public List<TableControl> GetTables()
        {
            return this.tables;
        }

        public List<JoinControl> GetJoins()
        {
            return this.joins;
        }

        public void PrepareForSerializationToXML()
        {
            tableEntities.Clear();
            joinEntities.Clear();

            foreach (TableControl tc in tables)
            {
                tableEntities.Add(tc.GetTableEntity());
            }

            foreach (JoinControl jc in joins)
            {
                joinEntities.Add(jc.GetJoinEntity());
            }
            {

            }

        }
    }


}
