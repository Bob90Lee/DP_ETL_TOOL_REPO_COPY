using DP_ETL_TOOL.Types;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class LayerMemberEntity
    {
        [DataMember]
        private List<TableEntity> tableEntities;
        [DataMember]
        private List<JoinEntity> joinEntities;
        [DataMember]
        private Enums.Layer layerType;
        [DataMember]
        private string memberName;

        public LayerMemberEntity(string memberName, Enums.Layer layerType)
        {
            tableEntities = new List<TableEntity>();
            joinEntities = new List<JoinEntity>();
            this.layerType = layerType;
            this.memberName = memberName;
        }        

        public void SetMemberName(string memberName)
        {
            this.memberName = memberName;
        }

        public string GetMemberName()
        {
            return this.memberName;
        }

        public void AddTable(TableEntity table)
        {
            this.tableEntities.Add(table);
        }

        public void AddJoin(JoinEntity join)
        {
            this.joinEntities.Add(join);
        }

        public List<TableEntity> GetTables()
        {
            return this.tableEntities;
        }

        public List<JoinEntity> GetJoins()
        {
            return this.joinEntities;
        }

        public void SetLayerType(Enums.Layer layerType)
        {
            this.layerType = layerType;
        }

        public Enums.Layer GetLayerType()
        {
            return layerType;
        }

    }
}
