using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tutorials.Matrix4x4_lesson.Scripts
{
    public class ExampleMatrix4x4 : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _transformCenter;
        [SerializeField] private TextMeshProUGUI _text;

        [FormerlySerializedAs("_isLocal")] [SerializeField] private bool _isGlobal;
        private void Start()
        {
            //NewMatrix();

            //MultiplyMatrix();

            //TranslateTransform();

            //RotateTransform();
            
            //RotatePoint();

            //ScaleTransform();

            //ManyMatrix();

            //TRSMatrix();
        }

        private void Update()
        {
            //CurrentMatrix();

            //MoveTransform();

            //RotateTransform();

            //TransformMatrix();

            // var matrix = CreateRotationMatrix(
            //     _transformCenter.position, 
            //     _transformCenter.eulerAngles.x, 
            //     Vector3.up);
            //
            // _transform.rotation = matrix.rotation;
            // _transform.position = matrix.GetPosition();
        }

        private void TransformMatrix()
        {
            if (_isGlobal)
            {
                var localToWorld = _transform.localToWorldMatrix;
                _text.SetText(localToWorld.ToStringMatrix4x4());
            }
            else
            {
                var worldToLocal = _transform.worldToLocalMatrix;
                _text.SetText(worldToLocal.ToStringMatrix4x4());
            }
        }

        private void CurrentMatrix()
        {
            var matrix = Matrix4x4.TRS(
                _transform.position,
                _transform.rotation,
                _transform.localScale
            );

            _text.SetText(matrix.ToStringMatrix4x4());
        }

        private void NewMatrix()
        {
            //               |  0   1   2   3
            //            ---+----------------
            //            0  | m00 m01 m02 m03
            //            1  | m10 m11 m12 m13
            //            2  | m20 m21 m22 m23
            //            3  | m30 m31 m32 m33
            
            var matrix = new Matrix4x4(); // створення 
            var m00 = matrix[0, 0]; // зчитування
            matrix[0, 1] = 2f; // запис

            var matrixIdentity = Matrix4x4.identity;
            var matrixZero = Matrix4x4.zero;
        }

        private void MultiplyMatrix()
        {
            var translationMatrix = new Matrix4x4(
                new Vector4(1, 0, 0, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(5, 0, 0, 1)
            );

            var v = new Vector3(0, 1, 2);
            var result = translationMatrix.MultiplyPoint3x4(v); // = (5, 1, 2)
        }

        private void TranslatePoint()
        {
            var input = new Vector3(0, 1, 2);
            var translationMatrix =
                Matrix4x4.Translate(new Vector3(5, 1, -2));
            var result = translationMatrix.MultiplyPoint(input); // = (5, 2, 0)
        }

        private void TranslateTransform()
        {
            Matrix4x4 translationMatrix = Matrix4x4.Translate(new Vector3(5f, 0f, 0f));
            _transform.position = translationMatrix.MultiplyPoint(_transform.position);
            
            _text.SetText(translationMatrix.ToStringMatrix4x4());
        }

        private void RotatePoint()
        {
            Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f, 90f, 0f));
            var input = new Vector3(0, 0, 1);
            
            var result = rotationMatrix.MultiplyVector(input); // (1,0,0)
            Debug.Log(result);
        }

        private void RotateTransform()
        {
            Quaternion rotation = Quaternion.Euler(0f, -1, 0f);
            Matrix4x4 rotationMatrix = Matrix4x4.Rotate(rotation);
            //_transform.rotation = rotationMatrix.rotation;

            Matrix4x4 objectMatrix = _transform.localToWorldMatrix;
            Matrix4x4 newObjectMatrix = rotationMatrix * objectMatrix;
            
            _transform.position = newObjectMatrix.GetColumn(3);
            _transform.rotation = rotation * _transform.rotation;
            
            _text.SetText(rotationMatrix.ToStringMatrix4x4());
        }

        private Matrix4x4 CreateRotationMatrix(Vector3 centerOfRotation, float angleOfRotation, Vector3 rotationAxis)
        {
            Matrix4x4 translationToCenterPoint = Matrix4x4.Translate(centerOfRotation);
            Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.AngleAxis(angleOfRotation, rotationAxis));

            Matrix4x4 resultMatrix = translationToCenterPoint * rotation;
            return resultMatrix;
        }

        private void ScaleTransform()
        {
            Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(2f, 2f, 2f));
            _transform.localScale = scaleMatrix.lossyScale;
            
            _text.SetText(scaleMatrix.ToStringMatrix4x4());
        }

        private void ManyMatrix()
        {
            var translation = Matrix4x4.Translate(new Vector3(5, 0, 0));
            var rotation = Matrix4x4.Rotate(Quaternion.Euler(90, 0, 0));
            var scale = Matrix4x4.Scale(new Vector3(1, 5, 1));
            var combined = translation * rotation * scale;
            var input = new Vector3(1, 1, 1);
            var result = combined.MultiplyPoint(input);
            Debug.Log(result); // = (6, 1, 5)
        }

        private void TRSMatrix()
        {
            var transformMatrix = Matrix4x4.TRS(
                new Vector3(5, 0, 0),
                Quaternion.Euler(90, 0, 0),
                new Vector3(1, 5, 1)
            );
        }
    }
}