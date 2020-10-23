using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speedX;
    public float speedY;
    private Rigidbody2D rb2d;
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb2d.velocity = new Vector2(speedX, speedY);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        speedX *= -1;
        speedY *= -1;
    }

}
