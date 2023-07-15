using UnityEngine;

namespace Tutorials.QuaternionLesson.Scripts
{
    public class QuaternionFromToRotation : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        [SerializeField] private Transform _sphere1;
        [SerializeField] private Transform _sphere2;
        
        private void Start()
        {
            _transform.rotation = Quaternion.FromToRotation(
                _sphere1.position, 
                _sphere2.position);
            
            
            Debug.Log(" angle1 "+ Vector3.Angle(_sphere1.position, _sphere2.position));
            Debug.Log(" angle2 "+ Quaternion.Angle(Quaternion.identity, _transform.rotation));
        }
    }
}