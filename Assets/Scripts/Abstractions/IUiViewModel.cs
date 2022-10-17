using System;
using Chernov.Test.Data;

namespace Chernov.Test.Abstractions
{
    /// <summary>
    /// Interface defines base view-model for user interface interactions 
    /// </summary>
    public interface IUiViewModel
    {
        /// <summary>
        /// Event fires when recording status changes
        /// </summary>
        event Action<bool> OnRecordingStatusChanged;

        /// <summary>
        /// Event fires when user interface update initialized
        /// </summary>
        event Action OnUpdateView;

        /// <summary>
        /// Event fires when input type changes
        /// </summary>
        event Action<InputType> OnInputTypeChanged;
    }
}