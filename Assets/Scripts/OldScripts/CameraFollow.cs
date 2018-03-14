using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float pitch;
    public float speedH = 5f;
    public float speedV = 10f;

    public Transform target;

    public float smoothSpeed = 10f;
    public float verticalSmoothSpeed = 5f;
    public Vector3 offset;
    public Vector3 LookAtOffset;
    public float maxViewRange = 90f;
    public float minViewRange = -45f;

    private Vector3 playerOffset;

    private void Start()
    {
        playerOffset = target.position+offset;
    }

    private void LateUpdate()
    {       
        playerOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * smoothSpeed, Vector3.up) * playerOffset;
        transform.position = target.position + playerOffset;
        transform.LookAt(target.position);

        playerOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * verticalSmoothSpeed, Vector3.left) * playerOffset;
        transform.position = target.position + playerOffset;
        transform.LookAt(target.position+LookAtOffset);
    }
}
