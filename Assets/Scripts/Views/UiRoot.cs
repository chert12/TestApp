using System;
using Chernov.Test.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace Chernov.Test.Views
{
    public class UiRoot : MonoBehaviour, IUiService, IUiViewModel
    {
        public event Action<bool> OnRecordingStatusChanged;
        public event Action OnUpdateView;

        public void ChangeRecordingStatus(bool status)
        {
            OnRecordingStatusChanged?.Invoke(status);
        }

        public void UpdateView()
        {
            OnUpdateView?.Invoke();
        }
    }
}