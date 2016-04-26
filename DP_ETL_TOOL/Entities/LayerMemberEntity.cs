using DP_ETL_TOOL.Controls;
using DP_ETL_TOOL.Types;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

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
        private List<ProcedureEntity> procedureEntities;
        [DataMember]
        private Enums.Layer layerType;
        [DataMember]
        private Enums.ModeType modeType; // object type
        [DataMember]
        private string memberName;

        public LayerMemberEntity(string memberName, Enums.Layer layerType, Enums.ModeType modeType)
        {
            this.tableEntities = new List<TableEntity>();
            this.joinEntities = new List<JoinEntity>();
            this.procedureEntities = new List<ProcedureEntity>();
            this.layerType = layerType;
            this.memberName = memberName;
            this.modeType = modeType;
        }

        public void ClassifyControlTypes(List<Control> controls)
        {
            tableEntities.Clear();
            joinEntities.Clear();

            foreach (Control c in controls)
            {
                if (c.GetType() == typeof(TableControl))
                {
                    TableControl tc = (TableControl)c;
                    tableEntities.Add(tc.GetTableEntity());
                }
                else if (c.GetType() == typeof(JoinControl))
                {
                    JoinControl jc = (JoinControl)c;
                    joinEntities.Add(jc.GetJoinEntity());
                }
            }
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

        public Enums.ModeType GetModeType()
        {
            return modeType;
        }

    }
}
