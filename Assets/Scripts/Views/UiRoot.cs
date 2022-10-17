using System;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Chernov.Test.Views
{
    /// <summary>
    /// Class defines basic Ui controller
    /// </summary>
    public class UiRoot : MonoBehaviour, IUiService, IUiViewModel
    {
        #region data

        [SerializeField] private Toggle _wasdToggle;
        [SerializeField] private Toggle _mouseToggle;
        [SerializeField] private Toggle _touchToggle;

        #endregion

        #region interface

        public event Action<bool> OnRecordingStatusChanged;
        public event Action OnUpdateView;
        public event Action<InputType> OnInputTypeChanged;

        public void ChangeRecordingStatus(bool status)
        {
            OnRecordingStatusChanged?.Invoke(status);
        }

        public void UpdateView()
        {
            OnUpdateView?.Invoke();
        }

        #endregion

        #region implementation

        private void Awake()
        {
            _wasdToggle.onValueChanged.AddListener(value =>
            {
                if (value)
                {
                    OnInputTypeChanged?.Invoke(InputType.Keyboard);
                }
            });

            _mouseToggle.onValueChanged.AddListener(value =>
            {
                if (value)
                {
                    OnInputTypeChanged?.Invoke(InputType.Mouse);
                }
            });

            _touchToggle.onValueChanged.AddListener(value =>
            {
                if (value)
                {
                    OnInputTypeChanged?.Invoke(InputType.Touch);
                }
            });
        }

        private void Start()
        {
            _wasdToggle.isOn = true;
        }

        #endregion
    }
}