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

    private void Update()
    {
        var z = GetValueZ();
        _thisTransform.rotation = Quaternion.Euler(0, 0, z);
    }

    private float GetValueZ()
    {
        _two = (_camera.ScreenToWorldPoint(Input.mousePosition) - _thisTransform.position);
        var scalarComposition = _one.x * _two.x + _one.y * _two.y;
        var modulesComposition = _one.magnitude * _two.magnitude;
        var division = scalarComposition / modulesComposition;
        var angle = Mathf.Acos(division) * Mathf.Rad2Deg;
        return angle;
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
