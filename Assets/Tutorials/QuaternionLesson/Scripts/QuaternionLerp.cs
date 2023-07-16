using UnityEngine;

namespace Tutorials.QuaternionLesson.Scripts
{
    public class QuaternionLerp : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        private Quaternion _startRotation;
        private Quaternion _targetRotation;
        
        private float _t;
        
        private void Start()
        {
            _startRotation = _transform.rotation;
            _targetRotation = Quaternion.Euler(10f, 90, 30f);
        }

        private void Update()
        {
            RotateLerp();
        }

        private void RotateLerp()
        {
            //_transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, _t);
            //_transform.rotation = Quaternion.LerpUnclamped(_startRotation, _targetRotation, _t);
            //_transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, _t);
            //_transform.rotation = Quaternion.SlerpUnclamped(_startRotation, _targetRotation, _t);

            _t += Time.deltaTime * 0.5f;
        }
    }
}