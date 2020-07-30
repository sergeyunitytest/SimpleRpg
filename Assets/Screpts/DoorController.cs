using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Player")
        {
            Destroy(Door);
            Destroy(gameObject);
        }
    }
}
