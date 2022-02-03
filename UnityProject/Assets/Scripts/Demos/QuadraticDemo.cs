using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuadraticDemo : MonoBehaviour
{

    public Transform StartPoint;
    public Transform EndPoint;
    public Transform ControlPoint;

    [Range(2, 100)] // Can be changed safely to change curve resolution
    public int curveResolution = 10;

    public AnimationCurve temporalEasing;

    private bool IsPlaying = false;
    public float TweenTimeLength = 3;
    private float TweenTimeCurrent = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying) TweenTimeCurrent += Time.deltaTime;

        float p = TweenTimeCurrent / TweenTimeLength;
        p = Mathf.Clamp(p, 0, 1);

        p = temporalEasing.Evaluate(p);

        Vector3 pos = FindPointOnCurve(p);
        transform.position = pos;

        if (TweenTimeCurrent >= TweenTimeLength) IsPlaying = false;
    }

    public void PlayTween(bool fromBeginning = false)
    {
        IsPlaying = true;
        if (fromBeginning) TweenTimeCurrent = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(ControlPoint.position, Vector3.one); // 1, 1, 1 vector, drawing a cube at the control point.

        

        for (int i = 0; i < curveResolution; i++) {
            Vector3 a = FindPointOnCurve(i / (float)curveResolution); // int divided by int isnt good, int divided by float!
            Vector3 b = FindPointOnCurve((i + 1) / (float)curveResolution); // 1 third of A

            Gizmos.DrawLine(a, b);
        }
    }

    Vector3 FindPointOnCurve(float percent)
    {
        Vector3 a = AnimMath.Lerp(StartPoint.position, ControlPoint.position, percent); // TWO Vectors to give the vectors between start to control, then control to end.
        Vector3 b = AnimMath.Lerp(ControlPoint.position, EndPoint.position, percent);

        return AnimMath.Lerp(a, b, percent);
    }
}

[CustomEditor(typeof(QuadraticDemo))]
public class QuadraticDemoEditor : Editor // Is in Unity Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Play Tween"))
        {
            QuadraticDemo demo = (QuadraticDemo)target;
            demo.PlayTween(true);
        }

    }

}
