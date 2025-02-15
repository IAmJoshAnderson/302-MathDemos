using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TweenDemo : MonoBehaviour
{

    public AnimationCurve curve;

    public Transform pointA;
    public Transform pointB;

    private float timeCurrent = 0;

    private bool isPlaying = false;

    [Range(.25f, 5)]
    public float timeTotal = 2;

    public void StartTween()
    {
        isPlaying = true;
        timeCurrent = 0;


    }


    // Update is called once per frame
    void Update()
    {

        if (isPlaying) {
        timeCurrent += Time.deltaTime;
        DoInterp();
    }
    }
    void DoInterp()
    {
        if (pointA == null) return;
        if (pointB == null) return;

        float p = timeCurrent / timeTotal;

        p = curve.Evaluate(p);

        Vector3 pos= AnimMath.Lerp(pointA.position, pointB.position, p);

        transform.position = pos;

        if (timeCurrent >= timeTotal) isPlaying = false;
    }
}


[CustomEditor(typeof(TweenDemo))]
public class EditorTweenDemo : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Start Tween"))
        {
            (target as TweenDemo).StartTween();
        }

    }

}