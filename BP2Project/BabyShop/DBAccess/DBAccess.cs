using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyShop.Model;

namespace BabyShop.DBAccess
{
    public class DBAccess
    {
        private static BP2ProjectEntities db = null;

        public static BP2ProjectEntities Instance
        {
            get
            {
                if (db == null)
                    db = new BP2ProjectEntities();

                return db;
            }
        }
        
        private DBAccess() { }

        public static void Refresh()
        {
            db.Dispose();
            db = new BP2ProjectEntities();
        }
    }
}
