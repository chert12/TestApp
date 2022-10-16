using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Chernov.Test.Services
{
    public class RecordLocalStorageService : IRecordsStorageService
    {

        public void SaveRecord(ARecordData recordData)
        {
            var d = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, Constants.Filenames.RecordsFolderName)); //Assuming Test is your Folder

            var files = d.GetFiles("*.txt"); //Getting Text files

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
            var d = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, Constants.Filenames.RecordsFolderName));

            var files = d.GetFiles("*.txt");
            var result = files.Select(file => file.Name).ToList();
            return result;
        }

        public T GetSavedRecord<T>(string path) where T:ARecordData
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
    }
}