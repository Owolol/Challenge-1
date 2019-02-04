using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementforObjects : MonoBehaviour
{
    public float speed = 1.19f;
    


    
    
       Vector3 pointA = new Vector3(-7, 1, 53);
       Vector3 pointB = new Vector3(-7, 1, 38);
    


    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}