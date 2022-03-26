using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_mvc.Models
{
    public class DB
    {
        string dbPath = @"C:\Users\Anton\source\3к-2с\программирование_интернет_серверов\лабораторные\lab3\lab3_mvc\db.json";

        public DB()
        {
            File.Open(dbPath, FileMode.OpenOrCreate, FileAccess.ReadWrite).Close();       
        }

        public List<DictRecord> GetAll()
        {
            List<DictRecord> records = new List<DictRecord>();
            using (StreamReader reader = new StreamReader(File.OpenRead(dbPath)))
            {
                string text = reader.ReadToEnd();
                if (!String.IsNullOrEmpty(text))
                    records = JsonConvert.DeserializeObject<List<DictRecord>>(text);
            }

            return records;
        }

        public void AddRecord(string lastName, string number)
        {
            List<DictRecord> records = GetAll();
            records.Add(new DictRecord(lastName, number));
            Save(records);
        }

        public void Update(int id, string lastName, string number)
        {
            List<DictRecord> records = GetAll();
            records[id] = new DictRecord(lastName, number);
            records[id].Id = id;
            Save(records);
        }

        public void Delete(int id)
        {
            List<DictRecord> records = GetAll();
            records.RemoveAt(id - 1);
            Save(records);
        }

        public int LastId()
        {
            List<DictRecord> records = GetAll();
            return records.Count == 0 ? -1 : records[records.Count - 1].Id;
        }

        public DictRecord Find(int id)
        {
            List<DictRecord> dicts = GetAll();
            return dicts.Find((record) => record.Id == id);
        }

        public void Save(List<DictRecord> records)
        {
            using (StreamWriter writer = new StreamWriter(dbPath, false))
            {
                string text = JsonConvert.SerializeObject(records);
                writer.Write(text);
            }
        }
    }
}