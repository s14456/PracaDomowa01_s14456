using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCircle : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ballPrefab;
    [Header("ShootingStuff")]
    public float shootDegree = 15;
    public float startDegree = 360;
    public float stopDegree = 180;
    public float step = -2;
    private float steps = 0;
    public float delay = 2f;
    private float timer = 0;
    [HideInInspector]
    public bool pause = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (!pause && timer > delay)
        {
            timer = 0;
            Rotate();
            if(Mathf.Abs(steps) > shootDegree)
                Shoot();
        }
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, step));
        if (transform.rotation.eulerAngles.z > startDegree || transform.rotation.eulerAngles.z < stopDegree)
            step *= -1;
        steps += step;
    }

    void Shoot()
    {
        pause = true;
        steps = 0;
        Instantiate(ballPrefab, transform.position, transform.rotation);
    }
}
