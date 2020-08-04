using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnerDanje : MonoBehaviour
{
    public Transform player;
    public GameObject Enemy;
    public float SpawnTime = 10f;
    public List<GameObject> Enemys = new List<GameObject>();
    public int MaxEnemys = 5;
    public float Timer = 10f;
    private float CheckTime = 2f;
    private float CheckTimer = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        CheckTimer -= Time.deltaTime;
        if (CheckTimer <= 0f)
        {

            CheckTimer = CheckTime;
            for (int i = 0; i < Enemys.Count; i++)
            {
                if (/*Enemys.Count < i + 1 &&*/ Enemys[i] == null)
                {
                    Enemys.RemoveAt(i);
                    i--;
                }
            }
        }
        if (Enemys.Count <= MaxEnemys) 
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0f && Vector3.Distance(transform.position, player.position) > 5f)
            {
                float x = UnityEngine.Random.Range(-3f, 3f);
                float y = UnityEngine.Random.Range(-3f, 3f);
                Vector3 Randompos = new Vector3(transform.position.x + x, transform.position.y + y, 0f);
                GameObject EnimiSpawned = Instantiate(Enemy, Randompos, Quaternion.identity);
                Enemys.Add(EnimiSpawned);
                Timer = SpawnTime;
            }
        }
    }
}
