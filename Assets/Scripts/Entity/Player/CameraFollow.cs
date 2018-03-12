using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 10f;
    public float verticalSmoothSpeed = 5f;
    public Vector3 offset;

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

        playerOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * verticalSmoothSpeed, Vector3.right) * playerOffset;
        transform.position = target.position + playerOffset;
        transform.LookAt(target.position);
    }
}
