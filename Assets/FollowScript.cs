using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject != null)
        {
            transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, -10);
        }
    }

    public void FindPlayer()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
}
