using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using Chernov.Test.Services;
using UnityEngine;

namespace Chernov.Test.Views
{
    /// <summary>
    /// Class uses for playing recorded movement
    /// </summary>
    public class Player : MonoBehaviour, IRecordProcessor
    {
        #region interface

        public void Process(ARecordData data)
        {
            if (data is LocationRecordData typedData)
            {
                StartCoroutine(StartRecordPlaying(typedData));
            }
        }

        #endregion

        #region implementation

        private IEnumerator StartRecordPlaying(LocationRecordData data)
        {
            var waiter = new WaitForEndOfFrame();
            var queue = new Queue<LocationPoint>(data.Points.OrderBy(t => t.Id));
            while (queue.Count > 0)
            {
                var locationData = queue.Dequeue();
                transform.position = locationData.Position.ToUnityVector();
                transform.localEulerAngles = locationData.Rotation.ToUnityVector();
                yield return waiter;
            }

            AppRoot.Instance.RecordService.StopPlaying();
        }

        #endregion
    }
}