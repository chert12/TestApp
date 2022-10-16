using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chernov.Test.Views
{
    public class Rotatable : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _axisHorizontal;
        [SerializeField] private Vector3 _axisVertical;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(_targetTransform.position, transform.TransformDirection(_axisHorizontal),
                Input.GetAxis("Horizontal") * _speed * Time.deltaTime);
            transform.RotateAround(_targetTransform.position, _axisVertical,
                Input.GetAxis("Vertical") * _speed * Time.deltaTime);
            transform.LookAt(_targetTransform);
        }
    }
}