using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationController : MonoBehaviour
{
    private Animator animp;
    // Start is called before the first frame update
    void Start()
    {
        animp = GetComponent<Animator>();
    }

    public void Run()
    {
        animp.Play("Run", 0, 0.1f);
    }
    public void Idle()
    {
        animp.Play("Idle", 0, 0.1f);
    }
    public void IdleWaeon()
    {
        animp.Play("IdleWaeon", 0, 0.1f);
    }
    public void Dead()
    {
        animp.Play("Dead", 0, 0.1f);
    }
    public void Roll()
    {
        animp.Play("Roll", 0, 0.1f);
    }
    public void Block()
    {
        animp.Play("Block", 0, 0.1f);
    }
    public void Walk()
    {
        animp.Play("Walk", 0, 0.1f);
    }
    public void Attack1()
    {
        animp.Play("Attack1", 0, 0.1f);
    }
    public void Attack2()
    {
        animp.Play("Attack2", 0, 0.1f);
    }
    public void Attack3()
    {
        animp.Play("Attack3", 0, 0.1f);
    }
    public void Attack4()
    {
        animp.Play("Attack4", 0, 0.1f);
    }
}
