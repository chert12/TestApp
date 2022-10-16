using System;
using System.Collections.Generic;
using System.IO;
using Chernov.Test.Abstractions;
using Chernov.Test.Views.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Chernov.Test.Views
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Recorder _recorder;
        [SerializeField] private Player _player;

        private void Update()
        {
            //_recorder.OnUpdate();
        }
    }
}