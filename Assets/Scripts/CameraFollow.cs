using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 10f;
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


        /*Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);      */
    }
}
