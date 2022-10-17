using System.IO;
using Chernov.Test.Data;
using Chernov.Test.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Chernov.Test.Views
{
    /// <summary>
    /// Class defines Ui element for single record view
    /// </summary>
    public class RecordViewElement : MonoBehaviour
    {
        #region data

        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private Button _playButton;

        private string _filename;

        #endregion

        #region interface

        public void Init(string name)
        {
            _filename = name;
            _title.text = name;
        }

        #endregion

        #region implementation

        private void Start()
        {
            _playButton.onClick.AddListener(() =>
            {
                if (!AppRoot.Instance.RecordService.IsBusy())
                {
                    var data = AppRoot.Instance.RecordsStorageService.GetSavedRecord<LocationRecordData>(
                        Path.Combine(Application.streamingAssetsPath, Constants.Filenames.RecordsFolderName,
                            _filename));
                    if (data != null)
                    {
                        AppRoot.Instance.RecordService.PlayRecord(data);
                        _playButton.image.color = Constants.Colors.Red;
                    }
                }
            });

            AppRoot.Instance.RecordService.OnPlayingStatusChanged +=
                val => _playButton.image.color = Constants.Colors.MainAccent;
        }

        #endregion
    }
}