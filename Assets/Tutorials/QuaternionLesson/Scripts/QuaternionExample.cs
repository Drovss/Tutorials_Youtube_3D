using System;
using UnityEngine;

namespace Tutorials.QuaternionLesson.Scripts
{
    public class QuaternionExample : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        [SerializeField] private bool _isPlay;
        
        private Quaternion _startRotation;
        private Quaternion _targetRotation;
     
        void Update()
        {
            if (!_isPlay) return;

             //_transform.eulerAngles = new Vector3(0f, 90f, 0f);
            
             //_transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            
             //_transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            
             //_transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
            
             // Quaternion quaternion = _transform.rotation;
             // Vector3 eulerAngles = quaternion.eulerAngles;
            
             // float angle = 0f;
             // Vector3 axis;
             // _transform.rotation.ToAngleAxis(out angle, out axis);

             //_transform.rotation *= Quaternion.Euler(0f, 1f, 0f);
            
             //_transform.Rotate(0f, 1f, 0f);
            
            //_transform.rotation = Quaternion.identity;

            float angle = Quaternion.Angle(_startRotation, _targetRotation);
        }
    }
}
