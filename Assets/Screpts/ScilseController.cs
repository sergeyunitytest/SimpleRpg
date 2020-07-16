/*using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
*/using UnityEngine;
using UnityEngine.UI;

public class ScilseController : MonoBehaviour
{
    public PlayerController PC;
    public Image Skill1_Image;
    public float Skill1_KD = 1f;
    public float this_Skill1_KD = 1f;
    public bool is_Skill1_KD = false;

    public Image Skill2_Image;
    public float Skill2_KD = 1.5f;
    public float this_Skill2_KD = 1.5f;
    public bool is_Skill2_KD = false;

    public Image Skill3_Image;
    public float Skill3_KD = 2.5f;
    public float this_Skill3_KD = 2.5f;
    public bool is_Skill3_KD = false;

    public Image Skill4_Image;
    public float Skill4_KD = 3f;
    public float this_Skill4_KD = 3f;
    public bool is_Skill4_KD = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_Skill1_KD)
        {
            this_Skill1_KD -= Time.deltaTime;
            Skill1_Image.fillAmount = this_Skill1_KD / Skill1_KD;
            if (this_Skill1_KD < 0f)
            {
                is_Skill1_KD = false;
            }
        }

        if (is_Skill2_KD)
        {
            this_Skill2_KD -= Time.deltaTime;
            Skill2_Image.fillAmount = this_Skill2_KD / Skill2_KD;
            if (this_Skill2_KD < 0f)
            {
                is_Skill2_KD = false;
            }
        }

        if (is_Skill3_KD)
        {
            this_Skill3_KD -= Time.deltaTime;
            Skill3_Image.fillAmount = this_Skill3_KD / Skill3_KD;
            if (this_Skill3_KD < 0f)
            {
                is_Skill3_KD = false;
            }
        }

        if (is_Skill4_KD)
        {
            this_Skill4_KD -= Time.deltaTime;
            Skill4_Image.fillAmount = this_Skill4_KD / Skill4_KD;
            if (this_Skill4_KD < 0f)
            {
                is_Skill4_KD = false;
            }
        }
    }
    public void Skill1()
    {
        if (!is_Skill1_KD)
        {
            this_Skill1_KD = Skill1_KD;
            is_Skill1_KD = true;
            PC.SkillActivate(1);
            //Debug.Log("Skill1");
        }
    }

    public void Skill2()
    {
        if (!is_Skill2_KD)
        {
            this_Skill2_KD = Skill2_KD;
            is_Skill2_KD = true;
            PC.SkillActivate(2);
            //Debug.Log("Skill1");
        }
    }

    public void Skill3()
    {
        if (!is_Skill3_KD)
        {
            this_Skill3_KD = Skill3_KD;
            is_Skill3_KD = true;
            PC.SkillActivate(3);
            //Debug.Log("Skill1");
        }
    }

    public void Skill4()
    {
        if (!is_Skill4_KD)
        {
            this_Skill4_KD = Skill4_KD;
            is_Skill4_KD = true;
            PC.SkillActivate(4);
            //Debug.Log("Skill1");
        }
    }


}

