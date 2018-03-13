using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    private Transform _xFormCamera;
    private Transform _xFormParent;

    private Vector3 _localRotation;
    private float _cameraDistance = 10f;

    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;

    public GameObject target;
    public bool cameraDisable = true;

    // Use this for initialization
    void Start()
    {
        _xFormCamera = transform;
        _xFormParent = transform.parent;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F4))
        {
            cameraDisable = !cameraDisable;
        }

        if (!cameraDisable)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                _localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                //Clamp to avoid flipping or horizon clipping

                _localRotation.y = Mathf.Clamp(_localRotation.y, 5, 90);
            }

            //Scrolling Input
            if(Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                scrollAmount *= (_cameraDistance * 0.3f);

                _cameraDistance += scrollAmount * -1f;

                //Limiting Camera by meters
                _cameraDistance = Mathf.Clamp(_cameraDistance, 1.5f, 100f);
            }
        }

        //Actual Camera Rig Transformations

        Quaternion qT = Quaternion.Euler(_localRotation.y, _localRotation.x, 0);
        _xFormParent.rotation = Quaternion.Lerp(_xFormParent.rotation, qT, Time.deltaTime*orbitDampening);

        if(_xFormCamera.localPosition.z != _cameraDistance * -1f)
        {
            _xFormCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(_xFormCamera.localPosition.z, _cameraDistance * -1f, Time.deltaTime *scrollDampening));
        }

    }
}
