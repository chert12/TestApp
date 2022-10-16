using System;
using System.Collections.Generic;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using Chernov.Test.Services;
using Chernov.Test.Views.Data;
using UnityEngine;

namespace Chernov.Test.Views
{
    public class Recorder : MonoBehaviour, IRecordable
    {
        private bool _isRecording;
        private LocationRecordData _recordData;

        public void Update()
        {
            if (_isRecording)
            {
                _recordData.Points.Add(new LocationPoint{Id = _recordData.Points.Count, Position = new SerializableVector3(transform.position), Rotation = new SerializableVector3(transform.localEulerAngles)});
            }
        }

        public void StartRecording()
        {
            _isRecording = true;
            _recordData = new LocationRecordData {Points = new List<LocationPoint>()};
        }

        public void StopRecording()
        {
            _isRecording = false;
        }

        public ARecordData GetRecordedData()
        {
            return _recordData;
        }
    }
}