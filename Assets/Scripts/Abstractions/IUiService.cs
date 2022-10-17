namespace Chernov.Test.Abstractions
{
    /// <summary>
    /// Interface defines base user interface operations
    /// </summary>
    public interface IUiService
    {
        /// <summary>
        /// Set new recording status (if recording at the moment)
        /// </summary>
        /// <param name="status">Recording status</param>
        void ChangeRecordingStatus(bool status);

        /// <summary>
        /// Method which initializes user interface update
        /// </summary>
        void UpdateView();
    }
}