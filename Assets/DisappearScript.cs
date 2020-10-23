using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Renderer>().material.color = Color.black;
        Destroy(gameObject, 1);
    }
}
