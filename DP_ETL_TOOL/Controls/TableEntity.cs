using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_ETL_TOOL.Controls
{
    class TableEntity
    {
        private String tableName;
        private String tableSchema;
        private List<Column> columns;
        private List<Index> indexes = new List<Index>();

        public TableEntity()
        {
            this.tableName = "TableNEW" + new Random().Next(0, 1000);
        }

        public TableEntity(String tableName)
        {
            this.tableName = tableName;
            this.columns = new List<Column>();
            this.indexes = new List<Index>();
        }

        public void setName(String tableName)
        {
            this.tableName = tableName.ToUpper();
        }

        public void setSchema(String schemaName)
        {
            this.tableSchema = schemaName.ToUpper();
        }

        public bool addColumn(String name, String type, int length)
        {
            Column exists = null;

            foreach (Column column in columns)
            {
                if (column.getName().Contains(name.ToUpper()))
                {
                    exists = column;
                }
            }

            if (exists == null)
            {
                Column c = new Column(name.ToUpper(), type.ToUpper(), length);
                columns.Add(c);
                return true; // column was added
            }
            else
            {
                return false; // column wasnt added because it already exists
            }

        }

        public bool addIndex(String name, String type, List<Column> columns)
        {
            Index exists = null;

            foreach (Index index in indexes)
            {
                if (index.getName().Contains(name.ToUpper()))
                {
                    exists = index;
                }
            }

            if (exists == null)
            {
                Index i = new Index(name.ToUpper(), type.ToUpper(), columns);
                indexes.Add(i);
                return true; // index was added
            }
            else
            {
                return false; // index wasnt added because it already exists
            }

        }

        public void removeColumn(String name)
        {
            foreach (Column column in columns) {
                if (column.getName().Contains(name.ToUpper())) {
                    columns.Remove(column);
                }
            }
        }

        public void removeIndex(String name)
        {
            foreach (Index index in indexes)
            {
                if (index.getName().Contains(name.ToUpper()))
                {
                    indexes.Remove(index);
                }
            }
        }

        public String getName()
        {
            return tableName;
        }

        public String getSchema()
        {
            return tableSchema;
        }

        public List<Column> getColumns()
        {
            return columns;
        }

        public List<Index> getIndexes()
        {
            return indexes;
        }
    }

    class Column
    {
        private String name;
        private String type;
        private int length;

        public Column(String name, String type, int length)
        {
            this.name = name.ToUpper();
            this.type = type.ToUpper();
            this.length = length;
        }

        public String getName()
        {
            return this.name;
        }
    }

    class Index
    {
        private String name;
        private String type;
        private List<Column> columns;

        public Index(String name, String type, List<Column> columns)
        {
            this.name = name.ToUpper();
            this.type = type.ToUpper();
            this.columns = new List<Column>();
            this.columns = columns;
        }

        public String getName()
        {
            return this.name;
        }
    }
}
