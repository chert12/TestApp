using Chernov.Test.Data;
using Chernov.Test.Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Chernov.Test.Views
{
    /// <summary>
    /// Class defines clickable panel for starting and stopping recording
    /// </summary>
    public class RecordButtonPanel : MonoBehaviour, IPointerClickHandler
    {
        #region data

        [SerializeField] private Image _recordImage;
        [SerializeField] private TextMeshProUGUI _recordText;

        private bool _isRecording;

        #endregion

        #region interface

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!AppRoot.Instance.RecordService.IsPlayingRecord)
            {
                _isRecording = !_isRecording;
                _recordImage.color = _isRecording ? Constants.Colors.Red : Constants.Colors.MainAccent;
                _recordText.color = _isRecording ? Constants.Colors.Red : Constants.Colors.MainAccent;
                _recordText.text = _isRecording ? Constants.Texts.Recording : Constants.Texts.ClickForStartRecording;

                AppRoot.Instance.UiService.ChangeRecordingStatus(_isRecording);
            }
        }

        #endregion

        #region implementation

        private void Start()
        {
            _recordImage.color = Constants.Colors.MainAccent;
            _recordText.text = Constants.Texts.ClickForStartRecording;
        }

        #endregion
    }
}