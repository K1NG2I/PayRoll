using System.Data;

namespace RFQ.Domain.Helper
{
    public static class DataTableMapper
    {
        /// <summary>
        /// Maps a DataTable to a list of model objects of type T.
        /// </summary>
        /// <typeparam name="T">The type of the model to map to.</typeparam>
        /// <param name="table">The DataTable to map from.</param>
        /// <returns>List of T mapped from the DataTable.</returns>
        public static List<T> MapToList<T>(DataTable table) where T : new()
        {
            var properties = typeof(T).GetProperties();
            var result = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                var item = new T();
                foreach (var prop in properties)
                {
                    if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        try
                        {
                            var value = Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                            prop.SetValue(item, value);
                        }
                        catch
                        {
                            // Ignore conversion errors and continue
                        }
                    }
                }
                result.Add(item);
            }
            return result;
        }
        public static T MapToSingle<T>(DataTable table) where T : new()
        {
            if (table == null || table.Rows.Count == 0)
                return default!; // returns null for reference types

            var properties = typeof(T).GetProperties();
            var row = table.Rows[0];
            var item = new T();

            foreach (var prop in properties)
            {
                if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                {
                    try
                    {
                        var value = Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                        prop.SetValue(item, value);
                    }
                    catch
                    {
                        // Ignore conversion errors and continue
                    }
                }
            }

            return item;
        }
    }
}
