using System;

namespace DP_ETL_TOOL.Entities
{
    class ColumnEntity
    {
        private String columnName;
        private String columnType;
        private int columnLength;
        private bool columnIsUnique = false;

        public ColumnEntity(String name, String type, int length, bool isUnique)
        {
            this.columnName = name.ToUpper();
            this.columnType = type.ToUpper();
            this.columnLength = length;
            this.columnIsUnique = isUnique;
        }

        public String GetColumnName()
        {
            return this.columnName;
        }

        public String GetColumnType()
        {
            return this.columnType;
        }

        public int GetColumnLength()
        {
            return this.columnLength;
        }

        public bool GetColumnIsUnique()
        {
            return this.columnIsUnique;
        }

        public void SetColumnName(string columnName)
        {
            this.columnName = columnName;
        }

        public void SetColumnType(string columnType)
        {
            this.columnName = columnType;
        }

        public void SetColumnLength(int columnLength)
        {
            this.columnLength = columnLength;
        }

        public void SetIsUnique(bool isUnique)
        {
            this.columnIsUnique = isUnique;
        }

    }
}
