using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeItem : MonoBehaviour
{
    public int CraftId;
    public Text nameText;
    public Image logo;
    public Alchemist alchemist;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateInfo(int id, String name, Sprite log, Alchemist al)
    {
        CraftId = id;
        nameText.text = name;
        logo.sprite = log;
        alchemist = al;
    }

    public void CraftButton()
    {
        alchemist.SendInfo(CraftId);
    }
}
