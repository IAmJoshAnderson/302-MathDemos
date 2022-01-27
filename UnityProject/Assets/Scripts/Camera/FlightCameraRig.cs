using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCameraRig : MonoBehaviour
{

    public float speed = 10; // speed of movement

    private float pitch = 0;
    private float yaw = 0;

    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;


    // Update is called once per frame
    void Update()
    {

        // ====== update position: ======

        // This will allow movement of the camera left to right, up and down!

        float v = Input.GetAxis("Vertical"); // forward / back on the keyboard
        float h = Input.GetAxis("Horizontal"); // left / right on the keyboard (strafe)

        // transform.position += transform.forward * v * Time.deltaTime; //move in this direction with V as the scale. Delta Time makes it 1 meter per second instead of 1 meter per tick
        // transform.position += transform.right * h * Time.deltaTime;

        Vector3 dir = transform.forward * v + transform.right * h; // Does lines 19 and 20 in one line

        transform.position += dir * Time.deltaTime * speed;


        // ==== update rotation: ======

        // This will allow rotation of the camera!

        float mx =Input.GetAxis("Mouse X"); // yaw (y) Turn head back and forth
        float my = Input.GetAxis("Mouse Y"); // pitch (x) Nod head up and down

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;

        pitch = Mathf.Clamp(pitch, -89, 89); // Camera doesn't flip upside down


        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
