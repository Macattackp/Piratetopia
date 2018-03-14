using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float camMaxAngle = 45f;
    public float camMinAngle = 15f;
    public float smoothSpeed = 10f;
    public float mouseSensitivity = 4f;

    public Transform target;
    public Transform verticalTarget;
    public Vector3 cameraOffset;
    public Vector3 idleCameraOffset;

    private Vector3 _smoothedPosition;
    private Quaternion _currentRotation;
    private Vector3 _targetPosition;
    private Quaternion _targetRotation;
    private Vector3 _localRotation;

    // Use this for initialization
    void Start () {
        _smoothedPosition = target.position + cameraOffset;
        transform.position=_smoothedPosition;

    }
	
	// Update is called once per frame
	void LateUpdate () {

        _targetPosition = target.position + cameraOffset;
        _smoothedPosition = Vector3.Lerp(transform.position, _targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = _smoothedPosition;

        //transform.LookAt(target);

        cameraOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * smoothSpeed, Vector3.up) * cameraOffset;
        transform.position = target.position + cameraOffset;
        transform.LookAt(target.position);        
    }
}
