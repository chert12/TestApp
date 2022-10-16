using System;

namespace Chernov.Test.Abstractions
{
    public interface IUiViewModel
    {
        event Action<bool> OnRecordingStatusChanged;
        event Action OnUpdateView;
    }
}