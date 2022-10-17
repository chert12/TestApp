namespace Chernov.Test.Abstractions
{
    /// <summary>
    /// Interface defines base operations for instance which used for records creation
    /// </summary>
    public interface IRecordable
    {
        /// <summary>
        /// Start recording process
        /// </summary>
        void StartRecording();

        /// <summary>
        /// Stop recording process
        /// </summary>
        void StopRecording();

        /// <summary>
        /// Returns last recorded data
        /// </summary>
        /// <returns>Last recorded data</returns>
        ARecordData GetRecordedData();
    }
}