using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kvests : MonoBehaviour
{
    public PlayerController PC;
    public GameObject content;
    public GameObject panel;
    public Text GoldText;
    public int Gold;
    public List<Kvest> KvestStrings = new List<Kvest>();

    public void AddKvest(int KvestId, string KvestString, int Gold, int Exp)
    {
        bool iskvest = false;
        foreach (Kvest searchkvest in KvestStrings)
        {
            if (searchkvest.KvestId == KvestId) iskvest = true;
        }
        if (!iskvest)
        {
            GameObject child = Instantiate(panel, content.transform.position, Quaternion.identity) as GameObject;
            child.transform.SetParent(content.transform);
            child.transform.Find("Text").GetComponent<Text>().text = KvestString; 
            Kvest kvest = new Kvest(KvestId, KvestString, child, Gold, Exp);
            KvestStrings.Add(kvest);
        }
    }
    public void ExitKvest(int KvestId, string KvestString)
    {
        
        foreach (Kvest kvest in KvestStrings)
        {
            if (kvest.KvestId == KvestId && !kvest.Compliter)
            {
                PC.GetExpGold(kvest.Exp, kvest.Gold);
                kvest.Compliter = true;
                //Gold += kvest.Gold;
                //GoldText.text = Gold + "";
                Destroy(kvest.ListElement);
                //KvestStrings.Remove(kvest);
            }
        }
    }
}
 public class Kvest
{
    public bool IsFind = false;
    public GameObject ListElement;
    public string KvestString;
    public int KvestId;
    public int Gold;
    public int Exp;
    public bool Compliter = false;
    public Kvest(int KvestId, string KvestString, GameObject ListElement, int Gold, int Exp)
    {
        this.Gold = Gold;
        this.Exp = Exp;
        this.ListElement = ListElement;
        this.KvestString = KvestString;
        this.KvestId = KvestId;
    }
}
