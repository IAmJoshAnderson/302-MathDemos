using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

    [Range(0,1)]
    public float percent = 0;


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        DoInterpolation();
    }
    void DoInterpolation() {

        if (pointA == null) return;
        if (pointB == null) return;

        Vector3 pos = Vector3.Lerp(pointA.position, pointB.position, percent);

        Quaternion rot = Quaternion.Lerp(pointA.rotation, pointB.rotation, percent);

        transform.position = pos;
        transform.rotation = rot;
            }
        private void OnValidate()
    {
        DoInterpolation();
    }
}
