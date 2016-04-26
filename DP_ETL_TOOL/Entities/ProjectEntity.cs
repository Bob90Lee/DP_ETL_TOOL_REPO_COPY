using DP_ETL_TOOL.Controls;
using DP_ETL_TOOL.Types;
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

        /*
        LAYERS
        */
        [DataMember]
        private List<LayerMemberEntity> extractionLayer;
        [DataMember]
        private List<LayerMemberEntity> transformationLayer;
        [DataMember]
        private List<LayerMemberEntity> loadLayer;
        [DataMember]
        private List<LayerMemberEntity> allTablesLayer;

        public ProjectEntity()
        {
            this.tables = new List<TableControl>();
            this.joins = new List<JoinControl>();
            this.tableEntities = new List<TableEntity>();
            this.joinEntities = new List<JoinEntity>();
            this.extractionLayer = new List<LayerMemberEntity>();
            this.transformationLayer = new List<LayerMemberEntity>();
            this.loadLayer = new List<LayerMemberEntity>();
            this.allTablesLayer = new List<LayerMemberEntity>();
        }

        public void AddTable(TableControl table)
        {
            this.tables.Add(table);
        }

        public void AddJoin(JoinControl join)
        {
            this.joins.Add(join);
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

        public void DeserializeFromXML()
        {
            this.tables = new List<TableControl>();
            this.joins = new List<JoinControl>();

            foreach (TableEntity te in tableEntities)
            {
                tables.Add(new TableControl(te, te.GetTableType(), 0, 0));
            }

            foreach (JoinEntity je in joinEntities)
            {
                joins.Add(new JoinControl(je));
            }
        }

        public void AddLayerMember(LayerMemberEntity member, Enums.Layer layer)
        {
            if (GetMemberFromLayerByName(layer, member.GetMemberName()) == null)
            {
                switch (layer)
                {
                    case Enums.Layer.Extraction_Layer:
                        {
                            extractionLayer.Add(member);
                            break;
                        }
                    case Enums.Layer.Transformation_Layer:
                        {
                            transformationLayer.Add(member);
                            break;
                        }
                    case Enums.Layer.Load_Layer:
                        {
                            loadLayer.Add(member);
                            break;
                        }
                    case Enums.Layer.All_Tables:
                        {
                            allTablesLayer.Add(member);
                            break;
                        }
                }
            }
        }

        public List<LayerMemberEntity> GetLayerMembers(Enums.Layer layer)
        {
            switch (layer)
            {
                case Enums.Layer.Extraction_Layer:
                    {
                        return extractionLayer;
                    }
                case Enums.Layer.Transformation_Layer:
                    {
                        return transformationLayer;
                    }
                case Enums.Layer.Load_Layer:
                    {
                        return loadLayer;
                    }
                case Enums.Layer.All_Tables:
                    {
                        return allTablesLayer;
                    }
            }

            return null;
        }

        public LayerMemberEntity GetMemberFromLayerByName(Enums.Layer layer, string memberName)
        {
            foreach (LayerMemberEntity entity in GetLayerMembers(layer))
            {
                if (entity.GetMemberName().ToUpper().Trim() == memberName.ToUpper().Trim())
                {
                    return entity;
                }
            }

            return null;
        }

        public void RemoveJoinEntity(JoinEntity je)
        {
            joinEntities.Remove(je);
        }

        public void DeleteTableAndAllDependenciesByTableName(string tableSchema, string tableName)
        {

            string currentTableName = tableName.Trim().ToUpper();

            if (tableSchema == null)
            {
                tableSchema = "";
            }
            string currentTableSchema = tableSchema.Trim().ToUpper();

            // delete joins

            List<JoinControl> joinsTemp = new List<JoinControl>(joins);

            foreach (JoinControl jc in joinsTemp)
            {
                if ((jc.GetMainTable().GetTableEntity().GetName() == currentTableName && jc.GetMainTable().GetTableEntity().GetSchema() == currentTableSchema) || (jc.GetChildTable().GetTableEntity().GetName() == currentTableName && jc.GetChildTable().GetTableEntity().GetSchema() == currentTableSchema))
                {
                    RemoveJoin(currentTableName, currentTableSchema);
                }
            }

            // delete join entities

            List<JoinEntity> joinEntitiesTemp = new List<JoinEntity>(joinEntities);

            foreach (JoinEntity je in joinEntitiesTemp)
            {
                if ((je.GetMainTable().GetName() == currentTableName && je.GetMainTable().GetSchema() == currentTableSchema) || (je.GetChildTable().GetName() == currentTableName && je.GetChildTable().GetSchema() == currentTableSchema))
                {
                    RemoveJoinEntity(je);
                }
            }

            // delete table controls

            List<TableControl> tablesTemp = new List<TableControl>(tables);

            foreach (TableControl tc in tablesTemp)
            {
                if (tc.GetTableEntity().GetName() == currentTableName && tc.GetTableEntity().GetSchema() == currentTableSchema)
                {
                    tables.Remove(tc);
                }
            }

            // delete table entities

            List<TableEntity> tableEntitiesTemp = new List<TableEntity>(tableEntities);

            foreach (TableEntity te in tableEntitiesTemp)
            {
                if (te.GetName() == currentTableName && te.GetSchema() == currentTableSchema)
                {
                    tableEntities.Remove(te);
                }
            }

            // delete layer members

            List<LayerMemberEntity> allTablesLayerTemp = new List<LayerMemberEntity>(allTablesLayer);

            foreach (LayerMemberEntity lme in allTablesLayerTemp)
            {
                List<TableEntity> tables = lme.GetTables();
                foreach (TableEntity te in tables)
                {
                    if (te.GetName() == currentTableName && te.GetSchema() == currentTableSchema)
                    {
                        allTablesLayer.Remove(lme);
                    }
                }
            }

            List<LayerMemberEntity> extractionLayerTemp = new List<LayerMemberEntity>(extractionLayer);

            foreach (LayerMemberEntity lme in extractionLayerTemp)
            {
                List<TableEntity> tables = lme.GetTables();
                foreach (TableEntity te in tables)
                {
                    if (te.GetName() == currentTableName && te.GetSchema() == currentTableSchema)
                    {
                        allTablesLayer.Remove(lme);
                    }
                }
            }

            List<LayerMemberEntity> transformationLayerTemp = new List<LayerMemberEntity>(transformationLayer);

            foreach (LayerMemberEntity lme in transformationLayerTemp)
            {
                List<TableEntity> tables = lme.GetTables();
                foreach (TableEntity te in tables)
                {
                    if (te.GetName() == currentTableName && te.GetSchema() == currentTableSchema)
                    {
                        allTablesLayer.Remove(lme);
                    }
                }
            }

            List<LayerMemberEntity> loadLayerTemp = new List<LayerMemberEntity>(loadLayer);

            foreach (LayerMemberEntity lme in loadLayerTemp)
            {
                List<TableEntity> tables = lme.GetTables();
                foreach (TableEntity te in tables)
                {
                    if (te.GetName() == currentTableName && te.GetSchema() == currentTableSchema)
                    {
                        allTablesLayer.Remove(lme);
                    }
                }
            }


        }

        public List<JoinControl> DeleteColumnAndAllDependencies(TableEntity te, ColumnEntity ce)
        {
            List<JoinControl> deleted = new List<JoinControl>();

            // delete join pairs / controls

            List<JoinControl> joinsTemp = new List<JoinControl>(joins);

            foreach (JoinControl jc in joinsTemp)
            {
                List<ColumnPairEntity> joinPairsTemp = new List<ColumnPairEntity>(jc.GetJoinEntity().GetJoinPairs());

                foreach (ColumnPairEntity cpe in joinPairsTemp)
                {
                    if (cpe.GetParentColumn() == ce || cpe.GetChildColumn() == ce)
                    {
                        jc.GetJoinEntity().GetJoinPairs().Remove(cpe);
                    }
                }

                if (jc.GetJoinEntity().GetJoinPairs().Count == 0)
                {
                    joins.Remove(jc);
                    deleted.Add(jc);
                }
            }


            // delete join entities

            List<JoinEntity> joinEntitiesTemp = new List<JoinEntity>(joinEntities);
            
            foreach (JoinEntity je in joinEntitiesTemp)
            {
                foreach (JoinControl jc in deleted)
                {
                    if (je == jc.GetJoinEntity())
                    {
                        joinEntities.Remove(je);
                    }
                }
            }

            // delete columns

            List<ColumnEntity> columnEntitiesTemp = new List<ColumnEntity>(te.GetColumns());

            foreach (ColumnEntity column in columnEntitiesTemp)
            {
                if (ce == column)
                {
                    te.GetColumns().Remove(column);
                }
            }

            return deleted;
        }

        public List<LayerMemberEntity> GetAllProjectMembers()
        {
            List<LayerMemberEntity> allMembers = new List<LayerMemberEntity>();

            allMembers.AddRange(extractionLayer);
            allMembers.AddRange(transformationLayer);
            allMembers.AddRange(loadLayer);

            return allMembers;
        }

    }


}
