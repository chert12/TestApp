using System.Collections.Generic;

namespace Chernov.Test.Abstractions
{
    public interface IRecordsStorageService
    {
        void SaveRecord(ARecordData recordData);
        IEnumerable<string> GetAvailableRecords();
        T GetSavedRecord<T>(string path) where T: ARecordData;
    }
}