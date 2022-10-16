using System;
using Chernov.Test.Services;
using UnityEngine;

namespace Chernov.Test.Views
{
    public class RecordsView : MonoBehaviour
    {
        [SerializeField] private RecordViewElement _elementPrefab;
        [SerializeField] private RectTransform _uiRoot;

        private void Start()
        {
            AppRoot.Instance.UiViewModel.OnUpdateView += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            var files = AppRoot.Instance.RecordsStorageService.GetAvailableRecords();
            ClearView();
            foreach (var file in files)
            {
                var element = Instantiate(_elementPrefab, _uiRoot);
                element.Init(file);
            }
        }

        private void ClearView()
        {
            for (var i = 0; i < _uiRoot.childCount; i++)
            {
                Destroy(_uiRoot.GetChild(i).gameObject);
            }
        }
    }
}