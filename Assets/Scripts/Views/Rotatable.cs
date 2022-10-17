using Chernov.Test.Data;
using Chernov.Test.Services;
using UnityEngine;

namespace Chernov.Test.Views
{
    /// <summary>
    /// Class defines basic view which can rotate around selected object by sphere trajectory
    /// </summary>
    public class Rotatable : MonoBehaviour
    {
        #region data

        [SerializeField] private Transform _targetTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _axisHorizontal;
        [SerializeField] private Vector3 _axisVertical;

        private InputType _inputType;

        #endregion

        #region implementation

        private void Awake()
        {
            AppRoot.Instance.UiViewModel.OnInputTypeChanged += type => _inputType = type;
        }

        private void Update()
        {
            if (!AppRoot.Instance.RecordService.IsPlayingRecord)
            {
                var direction = GetAxies();
                transform.RotateAround(_targetTransform.position, transform.TransformDirection(_axisHorizontal),
                    direction.x * _speed * Time.deltaTime);
                transform.RotateAround(_targetTransform.position, transform.TransformDirection(_axisVertical),
                    direction.y * _speed * Time.deltaTime);
                transform.LookAt(_targetTransform);
            }
        }

        private Vector2 GetAxies()
        {
            var result = Vector2.zero;
            if (_inputType.Equals(InputType.Keyboard))
            {
                result = new Vector2(Input.GetAxis(Constants.Values.KeyboardAxisHorizontal),
                    Input.GetAxis(Constants.Values.KeyboardAxisVertical));
            }
            else if (_inputType.Equals(InputType.Mouse))
            {
                result = VectorToDirection(Input.mousePosition);
            }
            else if (_inputType.Equals(InputType.Touch))
            {
                if (Input.touchCount > 0)
                {
                    result = VectorToDirection(Input.touches[0].position);
                }
            }

            return result;
        }

        private Vector2 VectorToDirection(Vector3 input)
        {
            var halfScreenX = Screen.width / 2;
            var halfScreenY = Screen.height / 2;

            var resX = 1f - (input.x / halfScreenX);
            var resY = 1f - (input.y / halfScreenY);
            return new Vector2(resX, resY);
        }

        #endregion
    }
}