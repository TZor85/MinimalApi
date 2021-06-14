using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinAPI.Core.Internfaces
{
    public interface ILocalMongoDataBase
    {
        void InsertRecord<T>(string table, T record);
        List<T> LoadRecords<T>(string table);
        T LoadRecordById<T>(string table, int id);
        void DeleteRecord<T>(string table, int id);
    }
}
