using System.IO;
using Chernov.Test.Data;
using Chernov.Test.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Chernov.Test.Views
{
    public class RecordViewElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private Button _playButton;

        private string _filename;
        
        public void Init(string name)
        {
            _filename = name;
            _title.text = name;
        }

        private void Start()
        {
            _playButton.onClick.AddListener(() =>
            {
                var data = AppRoot.Instance.RecordsStorageService.GetSavedRecord<LocationRecordData>(
                    Path.Combine(Application.streamingAssetsPath, Constants.Filenames.RecordsFolderName, _filename));
                if (data != null)
                {
                    AppRoot.Instance.RecordProcessor.Process(data);
                }
            });
        }
        
    }
}