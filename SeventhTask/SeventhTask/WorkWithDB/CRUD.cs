using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
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
            db.GetTable(typeof(T)).Attach(newModel, oldModel);
            db.SubmitChanges();
        }

        public static void Delete<T>(T model)
        {
            db.GetTable(typeof(T)).DeleteOnSubmit(model);
            db.SubmitChanges();
        }
    }
}
