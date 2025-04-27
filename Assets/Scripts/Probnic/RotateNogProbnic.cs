using UnityEngine;

public class RotateNogProbnic : MonoBehaviour
{
    private Vector2 _one;
    private Vector2 _two;
    private Transform _thisTransform;

    private Camera _camera;

    private void Start()
    {
        _one = Vector2.right;
        _camera = Camera.main;
        _thisTransform = transform;
    }

    private void OnDrawGizmos()
    {
        if (_thisTransform != null) 
        { 
            Gizmos.DrawLine(_thisTransform.position, _one * 10);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_thisTransform.position, _camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
