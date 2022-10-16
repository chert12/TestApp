using System.Collections.Generic;

namespace Chernov.Test.Abstractions
{
    public interface IRecordProcessor
    {
        void Process(ARecordData data);
    }
}