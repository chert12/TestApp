using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Chernov.Test.Services
{
    /// <summary>
    /// Class implements logic for downloading and uploading <see cref="ARecordData"/> from local storage
    /// </summary>
    public class RecordLocalStorageService : IRecordsStorageService
    {
        #region interface

        public void SaveRecord(ARecordData recordData)
        {
            var d = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath,
                Constants.Filenames.RecordsFolderName));
            var files = d.GetFiles(Constants.Filenames.FileSearchPattern);
            var nameFormat = Path.Combine(Application.streamingAssetsPath, Constants.Filenames.RecordsFolderName,
                Constants.Filenames.RecordFilenameTemplate);

            var filename = string.Format(nameFormat, files.Length);
            var i = 1;
            while (File.Exists(filename))
            {
                filename = string.Format(nameFormat, filename.Length + i++);
            }

            File.WriteAllText(filename, JsonConvert.SerializeObject(recordData));
        }

        public IEnumerable<string> GetAvailableRecords()
        {
            var d = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath,
                Constants.Filenames.RecordsFolderName));

            var files = d.GetFiles(Constants.Filenames.FileSearchPattern);
            var result = files.Select(file => file.Name).ToList();
            return result;
        }

        public T GetSavedRecord<T>(string path) where T : ARecordData
        {
            if (!File.Exists(path))
            {
                Debug.LogWarning($"Unable to get file from {path} because file does not exist");
                return null;
            }

            var raw = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<T>(raw);
            return result;
        }

        #endregion
    }
}