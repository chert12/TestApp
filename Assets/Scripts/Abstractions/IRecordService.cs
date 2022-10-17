using System;

namespace Chernov.Test.Abstractions
{
    /// <summary>
    /// Interface defines data and operations to work with records
    /// </summary>
    public interface IRecordService
    {
        /// <summary>
        /// Event fires when system starts or finishes playing record
        /// </summary>
        event Action<bool> OnPlayingStatusChanged;

        /// <summary>
        /// Property shows is any records playing at the moment
        /// </summary>
        bool IsPlayingRecord { get; }

        /// <summary>
        /// Property shows is system record any movement now
        /// </summary>
        bool IsRecording { get; }

        /// <summary>
        /// Play selected record
        /// </summary>
        /// <param name="record">Record to play</param>
        void PlayRecord(ARecordData record);

        /// <summary>
        /// Stop playing record
        /// </summary>
        void StopPlaying();

        /// <summary>
        /// Start recording process
        /// </summary>
        void StartRecording();

        /// <summary>
        /// Return true if <see cref="IsPlayingRecord"/> or <see cref="IsRecording"/> is true
        /// </summary>
        /// <returns></returns>
        bool IsBusy();
    }
}