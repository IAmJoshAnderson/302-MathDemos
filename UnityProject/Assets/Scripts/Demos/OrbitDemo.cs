using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))] //Makes sure LineRenderer is the sibling component to OrbitDemo. Prevents it from being removed.
public class OrbitDemo : MonoBehaviour
{

    public float timeMultiplier = 1; // Time in human existence, speed of the planets moving around.
    public float timeOffset = 0;

    public Transform orbitCenter;

    public float radius = 10;

    private LineRenderer path;

    public int pathResolution = 32; // "Resolution" of the circle

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>(); // Now stores line renderer inside path variable if component exists
        updateOrbitPath(); // calls updateorbitpath below
    }

    // Update is called once per frame
    void Update()
    {

        if (!orbitCenter) return; // The center of the object's rotation

        float x = radius * Mathf.Cos(Time.time * timeMultiplier + timeOffset);
        float z = radius * Mathf.Sin(Time.time * timeMultiplier + timeOffset);

        transform.position = new Vector3(x, 0, z) + orbitCenter.position;

        if (orbitCenter.hasChanged) updateOrbitPath();
    }

    void updateOrbitPath() // Updates the LineRenderer
    {
        if (!orbitCenter) return;

        float radsPerCircle = 2 * Mathf.PI; // 2*PI

        Vector3[] pts = new Vector3[pathResolution]; // 32 Vector3's will Run, 1/32 over a circle.

        for(int i = 0; i < pts.Length; i++)
        {
            float x = radius * Mathf.Cos(i * radsPerCircle/pathResolution); // 2 * PI / 32
            float z = radius * Mathf.Sin(i * radsPerCircle/pathResolution);

            Vector3 pt = new Vector3(x, 0, z) + orbitCenter.position;
            pts[i] = pt;
        }

        path.positionCount = pathResolution; // How many points are there?
        path.SetPositions(pts); // Set those positions, please.

    }
}
