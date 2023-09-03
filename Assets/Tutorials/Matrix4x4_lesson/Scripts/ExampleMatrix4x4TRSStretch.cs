using UnityEngine;

namespace Tutorials.Matrix4x4_lesson.Scripts
{
    public class ExampleMatrix4x4TRSStretch : MonoBehaviour
    {
        [SerializeField] private float _rotAngle;
        [SerializeField] private float _stretch;

        [SerializeField] private MeshFilter _mf;
        
        private Vector3[] _origVerts;
        private Vector3[] _newVerts;

        private void Start()
        {
            _origVerts = _mf.mesh.vertices;
            _newVerts = new Vector3[_origVerts.Length];
        }

        private void Update()
        {
            // Create a rotation matrix from a Quaternion.
            Quaternion rot = Quaternion.Euler(_rotAngle, 0, 0);
            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, rot, Vector3.one);

            // Get the inverse of the matrix (ie, to undo the rotation).
            Matrix4x4 inv = m.inverse;

            // For each vertex...
            for (var i = 0; i < _origVerts.Length; i++)
            {
                // Rotate the vertex and scale it along its new Y axis.
                var pt = m.MultiplyPoint3x4(_origVerts[i]);
                pt.y *= _stretch;

                // Return the vertex to its original rotation (but with the
                // scaling still applied).
                _newVerts[i] = inv.MultiplyPoint3x4(pt);
            }

            // Copy the transformed vertices back to the mesh.
            _mf.mesh.vertices = _newVerts;
        }
    }
}