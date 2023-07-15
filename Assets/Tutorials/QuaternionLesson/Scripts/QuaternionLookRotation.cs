using UnityEngine;

namespace Tutorials.QuaternionLesson.Scripts
{
    public class QuaternionLookRotation : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        [SerializeField] private Transform _target;

        private void Update()
        {
            var relativePos = _target.position - _transform.position;
            
            _transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);

            Debug.DrawRay(_transform.position, _transform.forward * 10f, Color.blue);
            Debug.DrawRay(_transform.position, _transform.up * 10f, Color.green);
        }
    }
}