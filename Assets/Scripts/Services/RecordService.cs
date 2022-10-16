namespace Chernov.Test.Services
{
    public class RecordService
    {
        public RecordService()
        {
            AppRoot.Instance.UiViewModel.OnRecordingStatusChanged += OnRecordingListenerStatusChanged;
        }
        
        private void OnRecordingListenerStatusChanged(bool status)
        {
            if (status)
            {
                AppRoot.Instance.Recordable.StartRecording();
            }
            else
            {
                AppRoot.Instance.Recordable.StopRecording();
                AppRoot.Instance.RecordsStorageService.SaveRecord(AppRoot.Instance.Recordable.GetRecordedData());
                AppRoot.Instance.UiService.UpdateView();
            }
        }
    }
}