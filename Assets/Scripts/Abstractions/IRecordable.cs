using System.Collections.Generic;

namespace Chernov.Test.Abstractions
{
    public interface IRecordable
    {
        void StartRecording();
        void StopRecording();
        ARecordData GetRecordedData();
    }
}