using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Chernov.Test.Abstractions;
using Chernov.Test.Data;
using Chernov.Test.Views.Data;
using UnityEngine;

namespace Chernov.Test.Views
{
    public class Player : MonoBehaviour, IRecordProcessor
    {

        public void Process(ARecordData data)
        {
            if (data is LocationRecordData typedData)
            {
                StartCoroutine(StartRecordPlaying(typedData));
            }
        }
        
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
        }
    }
}