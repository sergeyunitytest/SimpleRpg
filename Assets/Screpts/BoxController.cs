using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public List<GameObject> drop = new List<GameObject>();
    private SpriteRenderer sr;
    public Sprite spriteOpen;
    public GameObject Key;
    public List<GameObject> doors = new List<GameObject>();
    private bool Ginerated = false;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !Ginerated)
        {
            Ginerated = true;
            for (int i = 0; i < drop.Count; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                Instantiate(drop[i], transform.position + randomPos, Quaternion.identity);
            }
            for (int i = 0; i < doors.Count; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                GameObject GeneratedKey = Instantiate(Key, transform.position + randomPos, Quaternion.identity);
                DoorController Dc = GeneratedKey.GetComponent<DoorController>();
                Dc.Door = doors[i];
            }
            sr.sprite = spriteOpen;
        }
    }
}
