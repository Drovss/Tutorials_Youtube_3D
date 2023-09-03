using System;
using UnityEngine;

namespace Tutorials.Matrix4x4_lesson.Scripts
{
    public class TestMatrix4x4 : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        private void Update()
        {
            var res = _transform.localToWorldMatrix.MultiplyVector(Vector3.one * 90);
            
            _transform.rotation = Quaternion.Euler(res);
        }
    }
}