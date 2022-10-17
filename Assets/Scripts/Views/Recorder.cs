using System.Collections.Generic;
using System.Collections;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using UnityEngine;

namespace Chernov.Test.Views
{
    /// <summary>
    /// Class implements logic for recording movement
    /// </summary>
    public class Recorder : MonoBehaviour, IRecordable
    {
        #region data

        private bool _isRecording;
        private LocationRecordData _recordData;
        private Coroutine _recordCoroutine;

        #endregion

        #region interface

        public void StartRecording()
        {
            _isRecording = true;
            _recordData = new LocationRecordData {Points = new List<LocationPoint>()};
            _recordCoroutine = StartCoroutine(RecordingCoroutine());
        }

        public void StopRecording()
        {
            _isRecording = false;
            StopCoroutine(_recordCoroutine);
            _recordCoroutine = null;
        }

        public ARecordData GetRecordedData()
        {
            return _recordData;
        }

        #endregion

        #region implementation

        private IEnumerator RecordingCoroutine()
        {
            var waiter = new WaitForEndOfFrame();
            while (_isRecording)
            {
                _recordData.Points.Add(new LocationPoint
                {
                    Id = _recordData.Points.Count, Position = new SerializableVector3(transform.position),
                    Rotation = new SerializableVector3(transform.localEulerAngles)
                });
                yield return waiter;
            }
        }

        #endregion
    }
}