using UnityEngine;

namespace Tutorials.QuaternionLesson.Scripts
{
    public class TransformRotateAround : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _target;
        
        [SerializeField] private float _angularSpeed;

        private void Update()
        {
            _transform.RotateAround(
                _target.position,
                Vector3.up,
                _angularSpeed * Time.deltaTime);
        }
    }
}