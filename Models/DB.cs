using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_mvc.Models
{
    public static class DB
    {
        static ApplicationContext db;
        static string dbPath = @"C:\Users\Anton\source\3к-2с\программирование_интернет_серверов\лабораторные\lab3\lab3_mvc\db.json";

        public static List<DictRecord> GetAll()
        {
            List<DictRecord> records = new List<DictRecord>();
            using (db = new ApplicationContext())
            {
                foreach(DictRecord record in db.DictRecords)
                {
                    records.Add(record);
                }
            }

            return records;
        }

        public static void AddRecord(string lastName, string number)
        {
            using (db = new ApplicationContext())
            {
                DictRecord record = new DictRecord { LastName = lastName, Number = number };
                db.DictRecords.Add(record);
                db.SaveChanges();
            }
        }

        public static DictRecord Find(int id)
        {
            DictRecord record;
            using(db = new ApplicationContext())
            {
                record = GetAll().Find(el => el.Id == id);
            }

            return record;
        }

        public static void Update(int id, string lastName, string number)
        {
            DictRecord record = Find(id);
            using (db = new ApplicationContext())
            {
                record.LastName = lastName;
                record.Number = number;
                db.DictRecords.Update(record);
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            DictRecord record = Find(id);
            using (db = new ApplicationContext())
            {
                db.DictRecords.Remove(record);
                db.SaveChanges();
            }
        }
    }
}