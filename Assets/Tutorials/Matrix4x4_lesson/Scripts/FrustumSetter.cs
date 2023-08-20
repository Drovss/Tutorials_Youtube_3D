using UnityEngine;

namespace Tutorials.Matrix4x4_lesson.Scripts
{
    [ExecuteInEditMode]
    public class FrustumSetter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private float _nearFarDistance = 100;
        [SerializeField] private GameObject _monitorQuad;

        private void Start()
        {
            if (_monitorQuad == null) return;
            
            var r = _monitorQuad.GetComponent<Renderer>();
            
            if (r != null)
            {
                r.enabled = false;
            }
        }

        private void Update()
        {
            if (_monitorQuad != null && _camera != null)
            {
                SetFrustumFromQuad(_camera, _monitorQuad);
            }
        }
        
        void SetFrustumFromQuad(Camera cam, GameObject quad)
        {
            float near = 1;
            float far = 1000;

            // quads Z rotation (roll) is locked
            quad.transform.localEulerAngles = new Vector3(
                quad.transform.localEulerAngles.x, 
                quad.transform.localEulerAngles.y, 
                0);

            // set near far plane
            near = GetDistanceFromQuad(cam, quad);
            cam.nearClipPlane = near;
            far = near + _nearFarDistance;
            cam.farClipPlane = far;

            // set camera rotation
            cam.transform.forward = _monitorQuad.transform.forward;

            //set left right bottom top
            Matrix4x4 worldToCamMat = cam.worldToCameraMatrix;
            Mesh quadMesh = quad.GetComponent<MeshFilter>().sharedMesh;

            //transform Quad corner-vertices position from local space to world space
            Vector3[] quadVertices = quadMesh.vertices;
            Vector3[] quadWorldVertices = new Vector3[quadVertices.Length];
            for (int i = 0; i < quadVertices.Length; i++)
            {
                quadWorldVertices[i] = quad.transform.TransformPoint(quadVertices[i]);
            }

            //transform from world space to camera space
            Vector3[] camSpaceVertices = new Vector3[quadWorldVertices.Length];
            for (int i = 0; i < quadWorldVertices.Length; i++)
            {
                camSpaceVertices[i] = worldToCamMat.MultiplyPoint(quadWorldVertices[i]);
            }

            //find left, right, bottom, and top coordinates
            float left = float.MaxValue;
            float right = float.MinValue;
            float bottom = float.MaxValue;
            float top = float.MinValue;

            for (int i = 0; i < camSpaceVertices.Length; i++)
            {
                if (camSpaceVertices[i].x < left) left = camSpaceVertices[i].x;
                if (camSpaceVertices[i].x > right) right = camSpaceVertices[i].x;
                if (camSpaceVertices[i].y < bottom) bottom = camSpaceVertices[i].y;
                if (camSpaceVertices[i].y > top) top = camSpaceVertices[i].y;
            }

            //set projection matrix
            cam.projectionMatrix = Matrix4x4.Frustum(left, right, bottom, top, near, far);
        }

        float GetDistanceFromQuad(Camera cam, GameObject quad)
        {
            Vector3 qNormal = quad.transform.forward.normalized;
            Vector3 qPos = cam.transform.position - quad.transform.position;

            float distance = Mathf.Abs(Vector3.Dot(qNormal, qPos));

            return distance;
        }
    }
}