using System.Collections.Generic;

namespace Chernov.Test.Abstractions
{
    /// <summary>
    /// Interface defines base operations to work with stored records
    /// </summary>
    public interface IRecordsStorageService
    {
        /// <summary>
        /// Save record to storage
        /// </summary>
        /// <param name="recordData">Record to save</param>
        void SaveRecord(ARecordData recordData);

        /// <summary>
        /// Return a list of available records
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAvailableRecords();

        /// <summary>
        /// Get saved record from storage
        /// </summary>
        /// <param name="path">Path to download</param>
        /// <typeparam name="T">Type of the record</typeparam>
        /// <returns></returns>
        T GetSavedRecord<T>(string path) where T : ARecordData;
    }
}