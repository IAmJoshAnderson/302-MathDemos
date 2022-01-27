using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDemo : MonoBehaviour
{

    [Range(-1, 3)]
    public float timeScale = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;

        // Time.deltaTime = Time.unscaledDeltaTime * Time.timeScale;
    }
}
