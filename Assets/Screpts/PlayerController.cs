using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.ComponentModel;

public class PlayerController : MonoBehaviour
{
    public Text GoldText;
    private float TimeRegen = 1f;
    private float RegenK = 0.01f;
    public Text LvlText;
    public Text ExpText;
    public int StartLvlExp = 500;
    public int Lvl = 1;
    public float LvlK = 1.5f;
    public int Exp = 0;
    public int Gold = 0;
    public List<GameObject> EnimiGameObject = new List<GameObject>();
    private List<EnimiControler> EnimiCon = new List<EnimiControler>();
    UnityEvent OnDamage = new UnityEvent();
    public Text HpText;
    public Text ManaText;
    public Image HPBar;
    public Image ManaBar;
    private float HP = 500;
    private float Mana = 500;
    private float MaxHP = 500;
    private float MaxMana = 500;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer sr;
    private MyAnimationController Mac;
    private string lastanim = "Idle";
    public Kvests kvests;
    public float speed = 2.5f;
    private void Start()
    {
        LvlText.text = "Lvl:" + Lvl;
        ExpText.text = Exp + "/" + StartLvlExp * Lvl * LvlK;
        HpText.text = HP + "/" + MaxHP;
        ManaText.text = Mana + "/" + MaxMana;
        HPBar.fillAmount = HP / MaxHP;
        ManaBar.fillAmount = Mana / MaxMana;
        rb = GetComponent<Rigidbody2D>();
        Mac = GetComponent<MyAnimationController>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(HP < MaxHP || Mana < MaxMana)
        TimeRegen -= Time.fixedDeltaTime;
        if (TimeRegen <= 0f)
        {
            TimeRegen = 1f;
            if(HP + MaxHP * RegenK >= MaxHP)
            {
                HP = MaxHP;
            }
            else
            {
                HP += MaxHP * RegenK;
            }
            if (Mana + MaxMana * RegenK >= MaxMana)
            {
                Mana = MaxMana;
            }
            else
            {
                Mana += MaxMana * RegenK;
            }
            HpText.text = HP + "/" + MaxHP;
            HPBar.fillAmount = HP / MaxHP;
            ManaText.text = Mana + "/" + MaxMana;
            ManaBar.fillAmount = Mana / MaxMana;

        }
        if (Input.GetKey(KeyCode.W))
        {
            if (lastanim != "Run")
            {
                Mac.Run();
                lastanim = "Run";
            }
            MyMoveController.MoveTop(rb, sr, speed, transform, Time.fixedDeltaTime);
            //rb.MovePosition(transform.position + top * Time.fixedDelTaime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (lastanim != "Run")
            {
                Mac.Run();
                lastanim = "Run";
            }
            MyMoveController.MoveBottom(rb, sr, -speed, transform, Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (lastanim != "Run")
            {
                Mac.Run();
                lastanim = "Run";
            }
            MyMoveController.MoveLeft(rb, sr, -speed, transform, Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (lastanim != "Run")
            {
                Mac.Run();
                lastanim = "Run";
            }
            MyMoveController.MoveRight(rb, sr, speed, transform, Time.fixedDeltaTime);
        }
        else
        {
            if (lastanim != "Idle")
            {
                Mac.Idle();
                lastanim = "Idle";
            }
        }
    }
    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.tag == "Enimi")
        {
            GameObject FindEnimi = EnimiGameObject.Find(item => item.GetInstanceID() == Col.gameObject.GetInstanceID());
            if (System.Object.ReferenceEquals(FindEnimi, null))
            {
                EnimiGameObject.Add(Col.gameObject);
                EnimiCon.Add(Col.gameObject.GetComponent<EnimiControler>());
            }
        }
        if(Col.tag == "Kvest")
        {
            GameObject Item = Col.gameObject;
            KvestItem kvestItem = Item.GetComponent<KvestItem>();
            int Id = kvestItem.Id;
            //kvests.KvestStrings;

            foreach (Kvest kvest in kvests.KvestStrings)
            {
                if (kvest.KvestId == Id)
                {
                    kvest.IsFind = true;
                    Destroy(Item);
                }
            }
        }
    }
    public void SkillActivate(int number)
    {
        Debug.Log("Skill1" + number);
        if (number == 1)
        {
            Mac.Attack1();
            Mana -= 20;
            ManaText.text = Mana + "/" + MaxMana;
            ManaBar.fillAmount = Mana / MaxMana;
            //OnDamage.Invoke();
            EnemyDamageCreate(20);
        }
        if (number == 2)
        {
            Mac.Attack2();
            Mana -= 20;
            ManaText.text = Mana + "/" + MaxMana;
            ManaBar.fillAmount = Mana / MaxMana;
            //OnDamage.Invoke();
            EnemyDamageCreate(25);
        }
        if (number == 3)
        {
            Mac.Attack3();
            Mana -= 25;
            ManaText.text = Mana + "/" + MaxMana;
            ManaBar.fillAmount = Mana / MaxMana;
            //OnDamage.Invoke();
            EnemyDamageCreate(30);
        }
        if (number == 4)
        {
            Mac.Attack4();
            Mana -= 35;
            ManaText.text = Mana + "/" + MaxMana;
            ManaBar.fillAmount = Mana / MaxMana;
            //OnDamage.Invoke();
            EnemyDamageCreate(45);
        }
    }
    private void EnemyDamageCreate(int damage)
    {
        for (int i = 0; i < EnimiGameObject.Count; i++)
        {
            if (EnimiGameObject[i] != null)
            {
                if (Vector3.Distance(transform.position, EnimiGameObject[i].transform.position) < 1f)
                {
                    EnimiCon[i].GetDamage(damage);
                }
            }
            else
            {
                EnimiGameObject.RemoveAt(i);
                EnimiCon.RemoveAt(i);
            }
        }
    }
    public void GetExpGold(int expl, int gold)
    {
        Exp += expl;
        Gold += gold;
        if(Exp >= StartLvlExp * Lvl * LvlK)
        {
            Lvl++;
            Exp = 0;
            MaxHP *= LvlK;
            HP = MaxHP;
            MaxMana *= LvlK;
            Mana = MaxMana;
            HpText.text = HP + "/" + MaxHP;
            HPBar.fillAmount = HP / MaxHP;
            ManaText.text = Mana + "/" + MaxMana;
            ManaBar.fillAmount = Mana / MaxMana;
        }
        LvlText.text = "Lvl:" + Lvl;
        ExpText.text = Exp + "/" + StartLvlExp * Lvl * Lvl;
        GoldText.text = Gold + "";
    }
    public void getDps(float Dps, GameObject Enimi)
    {
        GameObject FindEnimi = EnimiGameObject.Find(item => item.GetInstanceID() == Enimi.GetInstanceID());
        if(System.Object.ReferenceEquals(FindEnimi, null))
        {
            EnimiGameObject.Add(Enimi);
            EnimiCon.Add(Enimi.GetComponent<EnimiControler>());
        }
        HP -= Dps;
        HpText.text = HP + "/" + MaxHP;
        HPBar.fillAmount = HP / MaxHP;
    }
    public void UpdateList(GameObject Enimi)
    {
        for (int i = 0; i < EnimiGameObject.Count; i++)
        {
            if (EnimiGameObject[i].GetInstanceID() == Enimi.GetInstanceID())
            {
                EnimiGameObject.RemoveAt(i);
                EnimiCon.RemoveAt(i);
            }
        }
    }
}

