using System.Collections;
using System.Security.Cryptography;
/*using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
*/
using UnityEngine;
using UnityEngine.Events;

public class EnimiControler : MonoBehaviour
{
    public float attackDamage = 10f;
    public int Exp = 100;
    public int Gold = 10;
    public EnimiFather EF;
    UnityEvent OnDamage = new UnityEvent();
    private float x;
    private float y;
    private Vector3 startP = new Vector3(0, 0, 0);
    private float AttackSpeed = 1f;
    private float AttackTime = 1f;
    private Transform HeroTransform;
    private PlayerController PC;
    private Animator animp;
    //public float AttackSpeed = 0.5f;
    public float MaxHp = 100f;
    public float ThisHp = 100f;
    public Transform HpBar;
    private bool napr = false;
    public float speed = 1.0f;
    public Transform startMarker;
    public Transform endMarker;
    private float startTime;
    private float journeyLength;
    private bool mathed = false;
    private bool Attack = false;
    void Start()
    {
        //OnDamage.AddListener(this,GetDamage(10));
        float x = UnityEngine.Random.Range(-0.5f, 0.5f);
        float y = UnityEngine.Random.Range(-0.5f, 0.5f);
        startP = transform.position;
        animp = GetComponent<Animator>();
    }
    public void Update()
    {
        if (Vector3.Distance(transform.position, startP) > 10f)
        {
            Attack = false;
            transform.position = startP;
        }
        if (!Attack)
        if (!napr)
        {
            if (!mathed)
            {
                startTime = Time.time;
                journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
                mathed = true;
                animp.Play("Run", 0, 0.1f);
            }
            float distCovered = (Time.time - startTime) * speed;
            float frastionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, frastionOfJourney);
            if(transform.position == endMarker.position)
            {
                napr = true;
                mathed = false;
            }
        }
        else
        {
            if (!mathed)
            {
                startTime = Time.time;
                journeyLength = Vector3.Distance(endMarker.position, startMarker.position);
                mathed = true;
                animp.Play("Run", 0, 0.1f);
            }

            float distCovered = (Time.time - startTime) * speed;
            float frastionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(endMarker.position, startMarker.position, frastionOfJourney);
            if (transform.position == startMarker.position)
            {
                napr = false;
                mathed = false;
            }
        }
        else
        {
            AttackTime -= Time.deltaTime;
            if(AttackTime < 0 && Vector3.Distance(transform.position, HeroTransform.position)< 1f)
            {
                AttackTime = AttackSpeed;
                animp.Play("Attack", 0, 0.1f);
                PC.getDps(attackDamage, gameObject);
            }
            else
            {
                Vector3 pos = HeroTransform.position;
                pos.x -= 0.378f + x;
                pos.y -= 0.449f + y;
                transform.position = Vector3.Lerp(transform.position, pos, 0.02f);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PC = col.gameObject.GetComponent<PlayerController>();
            Attack = true;
            HeroTransform = col.gameObject.GetComponent<Transform>();
            Debug.Log("Рома");
        }
    }
    public void GetDamage(int demage)
    {
        if (Vector3.Distance(transform.position, HeroTransform.position) < 2f)
        {
            ThisHp -= demage;
            if (ThisHp <= 0)
            {
                PC.GetExpGold(Exp, Gold);
                PC.UpdateList(gameObject);
                animp.Play("Dead", 0, 0.1f);
                EF.FatherDestroy();
            }
            Vector3 HpVector = HpBar.localScale;
            HpVector.x = ThisHp / MaxHp;
            HpBar.localScale = HpVector;
            Debug.Log(ThisHp);
        } 
    }
}
