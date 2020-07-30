using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class KvestController : MonoBehaviour
{
    public GameObject NextKvest;

    public Transform Hero;
    public int Gold;
    public int Exp;
    public string HeroName;
    public List<string> Dialog = new List<string>();
    public GameObject DialogPanel;
    public Image HeroImage;
    public Text HeroText;
    public Text DialogText;
    public int DialogNumber = 0;
    public int KvestId;
    //public Text Kvests;
    public string KvestStrings;
    public Kvests kvests;

    // Start is called before the first frame update
    void Start()
    {
        DialogPanel.SetActive(false);

    }

    void Update()
    {
        if(Vector3.Distance(transform.position, Hero.position) > 3f)
        {
            DialogPanel.SetActive(false);
        }
    }

    public void HideKvests()
    {
        DialogPanel.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.tag == "Player")
        {
            //PC = Col.gameObject.GetComponent<PlayerController>();
            bool CatFind = false;
            foreach (Kvest kvest in kvests.KvestStrings)
            {
                if (kvest.KvestId == KvestId)
                {
                    Debug.Log("1");
                    CatFind = true;
                    /*Destroy(kvest.ListElement);
                    KvestStrings.Remove(kvest);*/
                }
            }
            if (CatFind)
            {
                DialogPanel.SetActive(false);
                kvests.ExitKvest(KvestId, KvestStrings);
                Debug.Log("2");
                NextKvest.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                DialogPanel.SetActive(true);
                DialogText.text = Dialog[DialogNumber];
                Debug.Log("3");
            }
        }
    }
    public void NextDialog()
    {
        if (DialogNumber+1 < Dialog.Count)
        {
            DialogNumber++;
            DialogText.text = Dialog[DialogNumber];
        }
        else
        {
                DialogPanel.SetActive(false);
                kvests.AddKvest(KvestId, KvestStrings, Gold, Exp);

        }
    }
}
