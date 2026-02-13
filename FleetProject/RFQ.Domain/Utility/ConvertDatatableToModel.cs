using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Utility
{
    public static class ConvertDatatableToModel
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            List<T> data = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                T item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        prop.SetValue(item, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                    }
                }
                data.Add(item);
            }

            return data;
        }
    }
}
