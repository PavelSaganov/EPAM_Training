using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SeventhTask.WorkWithDB
{
    public static class CRUD
    {
        public static DataContext db;
        public static void Create<T>(T model)
        {
            db.GetTable(typeof(T)).InsertOnSubmit(model);
            db.SubmitChanges();
        }

        public static ITable Read<T>()
        {
            return db.GetTable(typeof(T));
        }

        public static void Update<T>(T oldModel, T newModel)
        {
            List<PropertyInfo> properties = typeof(T).GetProperties().Where(p => !p.Name.Contains(typeof(T).Name + "Id")).ToList();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(newModel, property.GetValue(oldModel));
            }

            db.SubmitChanges();
        }

        public static void Delete<T>(T model)
        {
            db.GetTable(typeof(T)).DeleteOnSubmit(model);
            db.SubmitChanges();
        }
    }
}
