using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private CannonCircle cannonCircle;
    // Start is called before the first frame update
    void Start()
    {
        cannonCircle = GetComponentInParent<CannonCircle>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            cannonCircle.pause = false;
        }
    }
}
