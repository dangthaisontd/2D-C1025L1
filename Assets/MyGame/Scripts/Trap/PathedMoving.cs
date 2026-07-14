using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PathedMoving")]
public class PathedMoving : MonoBehaviour
{
    [Header("Waypoint")]
    public Vector3[] localWaypoints;
    Vector3[] globalWaypoints;
    [Header("Speed Moving")]
    public float speed;
    public bool cycle;
    public float waiTime;
    [Range(0f, 2f)]
    public float easeAmount;
    [Header("Size")]
    public float size = 0.3f;
    int fromWaypointIndext;
    float percentBetweenWaypoint;
    float nextMoveTime;
    // Start is called before the first frame update
    void Start()
    {
        globalWaypoints = new Vector3[localWaypoints.Length];
        for (int i = 0; i < localWaypoints.Length; i++)
        {
            globalWaypoints[i] = localWaypoints[i] + transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = CaculePlatfomMovements();
        transform.Translate(velocity);
    }
    float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x,a)/(Mathf.Pow(x,a) + Mathf.Pow(1-x,a));
    }
    private Vector3 CaculePlatfomMovements()
    {
        if (Time.time < nextMoveTime)
        {
            return Vector3.zero;
        }
        fromWaypointIndext %= globalWaypoints.Length;
        int toWaypointIndext = (fromWaypointIndext + 1)%globalWaypoints.Length;
        float distanceBetweenWaypoint = Vector3.Distance(globalWaypoints[fromWaypointIndext],globalWaypoints[toWaypointIndext]);
        percentBetweenWaypoint += Time.deltaTime * speed / distanceBetweenWaypoint;
        percentBetweenWaypoint= Mathf.Clamp01(percentBetweenWaypoint);
        float easePercentBetweenWaypoint = Ease(percentBetweenWaypoint);

        Vector3 newPos = Vector3.Lerp(globalWaypoints[fromWaypointIndext], globalWaypoints[toWaypointIndext], easePercentBetweenWaypoint);
        if (percentBetweenWaypoint >=1)
        {
            percentBetweenWaypoint = 0;
            fromWaypointIndext ++;
            if(!cycle)
            {
                if(fromWaypointIndext>=globalWaypoints.Length-1)
                {
                 fromWaypointIndext=0;
                    System.Array.Reverse(globalWaypoints);
                }
            }
            nextMoveTime = Time.time + waiTime;
        }
        return newPos-transform.position;
    }
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        if(localWaypoints != null)
        {
           for(int i = 0; i < localWaypoints.Length; i++)
            {
                Vector3 globalWaypontPos = (Application.isPlaying)? globalWaypoints[i] : localWaypoints[i]+transform.position;
                Gizmos.DrawLine(globalWaypontPos - Vector3.up*size,globalWaypontPos+Vector3.up*size);
                Gizmos.DrawLine(globalWaypontPos - Vector3.left*size,globalWaypontPos+Vector3.left * size);
            }
        }
    }
}
