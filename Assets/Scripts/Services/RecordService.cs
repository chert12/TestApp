using Chernov.Test.Abstractions;
using System;
using Chernov.Test.Views;
using UnityEngine;

namespace Chernov.Test.Services
{
    /// <summary>
    /// Class implement logic and data for work with <see cref="ARecordData"/>
    /// </summary>
    public class RecordService : MonoBehaviour, IRecordService
    {
        #region data

        [SerializeField] private Player _player;
        [SerializeField] private Recorder _recorder;
        private bool _isPlaying;
        private bool _isRecording;
        private IRecordProcessor _recordProcessor;
        private IRecordable _recordable;

        #endregion

        #region interface

        public bool IsPlayingRecord => _isPlaying;
        public bool IsRecording => _isRecording;

        public event Action<bool> OnPlayingStatusChanged;

        public void PlayRecord(ARecordData record)
        {
            if (!IsBusy())
            {
                _isPlaying = true;
                OnPlayingStatusChanged?.Invoke(_isPlaying);
                _recordProcessor.Process(record);
            }
        }

        public void StopPlaying()
        {
            _isPlaying = false;
            OnPlayingStatusChanged?.Invoke(_isPlaying);
        }

        public void StartRecording()
        {
            if (!IsBusy())
            {
                _isRecording = true;
                _recordable.StartRecording();
            }
        }

        public bool IsBusy()
        {
            return _isPlaying || _isRecording;
        }

        #endregion

        #region implementation

        private void Start()
        {
            _recordable = _recorder;
            _recordProcessor = _player;
            AppRoot.Instance.UiViewModel.OnRecordingStatusChanged += OnRecordingListenerStatusChanged;
        }

        private void OnRecordingListenerStatusChanged(bool status)
        {
            if (status)
            {
                StartRecording();
            }
            else
            {
                _isRecording = false;
                _recordable.StopRecording();
                AppRoot.Instance.RecordsStorageService.SaveRecord(_recordable.GetRecordedData());
                AppRoot.Instance.UiService.UpdateView();
            }
        }

        #endregion
    }
}