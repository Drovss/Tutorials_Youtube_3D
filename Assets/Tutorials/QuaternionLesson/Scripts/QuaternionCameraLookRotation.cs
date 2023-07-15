using UnityEngine;

namespace Tutorials.QuaternionLesson.Scripts
{
    public class QuaternionCameraLookRotation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _camera;
        
        [SerializeField] private float _rotationSpeed;
        
        private void Update()
        {
            var towardsPlayer = _target.position - _camera.position;
            
            var desiredRotation = Quaternion.LookRotation(towardsPlayer, Vector3.up);
            
            var currentRotation = _camera.rotation;
            
            var updatedRotation = Quaternion.Slerp(
                currentRotation,
                desiredRotation, 
                _rotationSpeed * Time.deltaTime);
            
            _camera.rotation = updatedRotation;
        }
    }
}