namespace Chernov.Test.Abstractions
{
    /// <summary>
    /// Interface defines base logic for processing previously created recods
    /// </summary>
    public interface IRecordProcessor
    {
        /// <summary>
        /// Process record data
        /// </summary>
        /// <param name="data">Data to process</param>
        void Process(ARecordData data);
    }
}