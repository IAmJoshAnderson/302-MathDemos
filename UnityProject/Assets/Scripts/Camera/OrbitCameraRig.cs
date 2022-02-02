using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraRig : MonoBehaviour
{

    public Transform thingToLookAt;



    private float pitch = 0;
    private float yaw = 0;
    private float dis = 10;


    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    public float scrollSensitivity = 1;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // === rotation: ===

       float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;

        // === dolly: ====

        Vector2 scrollAmt = Input.mouseScrollDelta;

        dis += scrollAmt.y * scrollSensitivity;
        dis = Mathf.Clamp(dis, 5, 50); // distance to which the camera can be moved back

        float z = AnimMath.Ease(cam.transform.localPosition.z, -dis, .01f, Time.deltaTime);



        cam.transform.localPosition = new Vector3(0, 0, z);

        // === position: ===

        if (thingToLookAt == null) return;

        // transform.position = thingToLookAt.position;

        //outlays values from AnimMath Ease
        transform.position = AnimMath.Ease(transform.position, thingToLookAt.position, .001f, Time.deltaTime);

    }
}
