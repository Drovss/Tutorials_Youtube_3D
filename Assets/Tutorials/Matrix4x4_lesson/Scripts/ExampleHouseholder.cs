using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Tutorials.Matrix4x4_lesson.Scripts
{
    public class ExampleHouseholder : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _vectorNormal;
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(ReflectTransform);
        }

        private void ReflectTransform()
        {
            
            _transform.LocalReflect(_vectorNormal.position);
        }

        private void Reflect()
        {
            var matrix = Matrix4x4.TRS(
                _transform.position,
                _transform.rotation,
                _transform.localScale
            );

            var newMatrix = matrix.HouseholderReflection(Vector3.up);

            _transform.ApplyLocalTRS(newMatrix);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(Vector3.zero, _vectorNormal.position);
        }
    }
}