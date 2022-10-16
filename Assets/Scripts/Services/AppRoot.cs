using Chernov.Test.Abstractions;
using Chernov.Test.Views;
using UnityEngine;

namespace Chernov.Test.Services
{
    public class AppRoot : MonoBehaviour
    {
        #region data

        [SerializeField] private UiRoot _uiRoot;
        [SerializeField] private Recorder _recorder;
        [SerializeField] private Player _player;
        
        private static AppRoot _instance;
        private IRecordable _recordable;
        private IRecordProcessor _recordProcessor;
        private IUiViewModel _uiViewModel;
        private IUiService _uiService;
        private IRecordsStorageService _recordsStorageService;

        private RecordService _recordService;
        
        #endregion


        #region interface

        public static AppRoot Instance => _instance;

        public IRecordable Recordable => _recordable;
        public IRecordProcessor RecordProcessor => _recordProcessor;
        public IUiViewModel UiViewModel => _uiViewModel;
        public IUiService UiService => _uiService;
        public IRecordsStorageService RecordsStorageService => _recordsStorageService;
        

        #endregion
        
        #region implementation
        
        private void Awake()
        {
            _instance = this;
            _uiService = _uiRoot;
            _uiViewModel = _uiRoot;
            _recordable = _recorder;
            _recordProcessor = _player;
            
            _recordsStorageService = new RecordLocalStorageService();
            _recordService = new RecordService();
        }

        #endregion
    }
}