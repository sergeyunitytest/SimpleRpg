using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alchemist : MonoBehaviour
{
    public GameObject ParentPanel;
    private DBSingleton db;
    public List<Recipe> recipe;
    public GameObject PanelList;
    public GameObject RecipePrefab;

    //Панель крафта
    public Image LogoCraftItem;
    public Text NameCraftItem;
    public Text DescCraftItem;
    public GameObject PanelCraftItems;
    public GameObject PrefabCraftItem;
    private int LastId;
    public Inventory inv;

    void Start()
    {
        db = DBSingleton.getInstance();
        for(int i = 0; i < recipe.Count; i++)
        {
            GameObject go = Instantiate(RecipePrefab);
            go.transform.SetParent(PanelList.transform);
            RecipeItem ri = go.GetComponent<RecipeItem>();
            for(int j = 0; j < db.data.items.Count; j++)
            {
                if(db.data.items[j].id == recipe[i].ExitItem)
                {
                    Sprite sp = Resources.Load<Sprite>(db.data.items[j].link);
                    ri.UpdateInfo(db.data.items[j].id, db.data.items[j].name, sp, this);
                }
            }
            
            /*Sprite sp = Resources.Load<Sprite>(ListItems[i].link);
            ri.UpdateData(ListItems[i].count, sp, ListItems[i].id, Pc);
            II.Add(ii);*/
        }
        ParentPanel.SetActive(false);
    }

    public void SendInfo(int id)
    {
        LastId = id;
        foreach (Transform child in PanelCraftItems.transform) Destroy(child.gameObject);
        Debug.Log(id + "");
        for(int i = 0; i < recipe.Count; i++)
        {
            if(recipe[i].ExitItem == id)
            {
                for(int j = 0; j < db.data.items.Count; j++)
                {
                    if(db.data.items[j].id == recipe[i].ExitItem)
                    {
                        LogoCraftItem.sprite = Resources.Load<Sprite>(db.data.items[j].link);
                        NameCraftItem.text = db.data.items[j].name;
                        DescCraftItem.text = db.data.items[j].desk;
                    }
                }
               //recipe[i].Rets idшники айтемов для крафта
               for(int k = 0; k < recipe[i].Rets.Count; k++)
               {
                    for(int j = 0; j < db.data.items.Count; j++)
                    {
                        if(db.data.items[j].id == recipe[i].Rets[k])
                        {
                            Sprite sp = Resources.Load<Sprite>(db.data.items[j].link);
                            GameObject go = Instantiate(PrefabCraftItem);
                            go.transform.SetParent(PanelCraftItems.transform);
                            Image im = go.GetComponent<Image>();
                            im.sprite = sp;
                        }
                    }
               }
            }
        }
    }

    public void CraftButton()
    {
        for(int i = 0; i < recipe.Count; i++)
        {
            if(recipe[i].ExitItem == LastId)
            {
                //recipe[i].Rets idшники айтемов для крафта
                int checkp = 0;
                for(int k = 0; k < recipe[i].Rets.Count; k++)
                {
                    for(int j = 0; j < db.data.items.Count; j++)
                    {
                        if(db.data.items[j].id == recipe[i].Rets[k])
                        {
                            if(db.data.items[j].count > 0)
                            {
                                checkp++;
                            }
                        }
                    }
                }
                Debug.Log(checkp + "  " + recipe[i].Rets.Count);
                if(checkp == recipe[i].Rets.Count)//Если хватает ресов
                {
                    for(int k = 0; k < recipe[i].Rets.Count; k++)
                    {
                        for(int j = 0; j < db.data.items.Count; j++)
                        {
                            if(db.data.items[j].id == recipe[i].Rets[k])
                            {
                                db.data.items[j].count--;
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
                for(int j = 0; j < db.data.items.Count; j++)
                {
                    if(db.data.items[j].id == LastId)
                    {
                        db.data.items[j].count++;
                    }
                }
            }
        }
        //Обновление инвертаря
        inv.UpdateInventory();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            ParentPanel.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            ParentPanel.SetActive(false);
        }
    }
}
