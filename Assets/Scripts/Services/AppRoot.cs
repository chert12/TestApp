using Chernov.Test.Abstractions;
using Chernov.Test.Views;
using UnityEngine;

namespace Chernov.Test.Services
{
    /// <summary>
    /// Class defines a general app controller
    /// </summary>
    public class AppRoot : MonoBehaviour
    {
        #region data

        [SerializeField] private UiRoot _uiRoot;
        [SerializeField] private RecordService _recordServiceImpl;

        private static AppRoot _instance;
        private IUiViewModel _uiViewModel;
        private IUiService _uiService;
        private IRecordsStorageService _recordsStorageService;
        private IRecordService _recordService;

        #endregion


        #region interface

        public static AppRoot Instance => _instance;
        public IUiViewModel UiViewModel => _uiViewModel;
        public IUiService UiService => _uiService;
        public IRecordsStorageService RecordsStorageService => _recordsStorageService;
        public IRecordService RecordService => _recordService;

        #endregion

        #region implementation

        private void Awake()
        {
            _instance = this;
            _uiService = _uiRoot;
            _uiViewModel = _uiRoot;
            _recordService = _recordServiceImpl;

            _recordsStorageService = new RecordLocalStorageService();
        }

        #endregion
    }
}