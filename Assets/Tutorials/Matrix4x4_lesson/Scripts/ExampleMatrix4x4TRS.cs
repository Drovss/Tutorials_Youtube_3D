using UnityEngine;

namespace Tutorials.Matrix4x4_lesson.Scripts
{
    public class ExampleMatrix4x4TRS : MonoBehaviour
    {
        [SerializeField] private Vector3 _translation;
        [SerializeField] private Vector3 _eulerAngles;
        [SerializeField] private Vector3 _scale = new Vector3(1, 1, 1);

        private MeshFilter _mf;
        private Vector3[] _origVerts;
        private Vector3[] _newVerts;


        private void Start()
        {
            _mf = GetComponent<MeshFilter> ();
            _origVerts = _mf.mesh.vertices;
            _newVerts = new Vector3[_origVerts.Length];
        }

        private void Update()
        {
            // створюємо кватерніон з кутів Елера
            Quaternion rotation = Quaternion.Euler(_eulerAngles.x, _eulerAngles.y, _eulerAngles.z);

            // ствроюємо TRS матрицю
            Matrix4x4 matrix = Matrix4x4.TRS(_translation, rotation, _scale);
            
            //Matrix4x4 matrix = Matrix4x4.Translate(_translation);
            //Matrix4x4 matrix = Matrix4x4.Rotate(rotation);
            //Matrix4x4 matrix = Matrix4x4.Scale(_scale);

            // Для кожної вершини...
            for (int i = 0; i < _origVerts.Length; i++)
            {
                // приміняємо матрицю до вершин
                _newVerts[i] = matrix.MultiplyPoint3x4(_origVerts[i]);
            }

            // копіюємо нові значення вершин в меш
            _mf.mesh.vertices = _newVerts;
        }
    }
}