using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private Animator anim;
    private Collider2D col;
    private float Timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0f)
        {
            col.enabled = true;
            anim.SetBool("boom", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
