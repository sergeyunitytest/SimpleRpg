using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private DBSingleton db;
    public Text count;
    public Image Logo;
    public Sprite image;
    public int ID;
    public int Quantity;
    public int position;
    public string Name;
    public string Description;
    private PlayerController PC;
    void Start()
    {
        db = DBSingleton.getInstance();

    }
    public void UpdateData(int Qu, Sprite im, int id, PlayerController pc)
    {
        PC = pc;
        ID = id; 
        Quantity = Qu;
        image = im;
        count.text = Quantity + "";
        Logo.sprite = image;

    }
    public void UpdateData(int Qu, int id)
    {
        ID = id;
        Quantity = Qu;
        count.text = Quantity + "";
        Logo.sprite = image;

    }
    public void BtnClick()
    {
        Debug.Log(ID);
        Debug.Log(db.data.items.Count);
        if (ID == 2)
        {
            PC.Health(0.2f, 0f);
        }
        if (ID == 3)
        {
            PC.Health(0f, 0.2f);
        }
        if(ID != 1)
        Quantity--;
        count.text = Quantity + "";
        if(Quantity<= 0)
        {
            gameObject.SetActive(false);
        }
        for (int j = 0; j < db.data.items.Count; j++)
        {
            if (db.data.items[j].id == ID)
            {
                db.data.items[j].count = Quantity;
            }
        }
    }
}
