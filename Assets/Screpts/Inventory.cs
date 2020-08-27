using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private DBSingleton db;
    public GameObject item;
    private List<items> ListItems = new List<items>();
    public PlayerController Pc;
    public List<InventoryItem> II = new List<InventoryItem>();
    // Start is called before the first frame update
    void Start()
    {
        db = DBSingleton.getInstance();
        ListItems = db.data.items;
        //Debug.Log(ListItems[0].name);
        for (int i = 0; i < ListItems.Count; i++)
        {
            //Debug.Log(ListItems[i].name);
            GameObject go = Instantiate(item);
            go.transform.SetParent(gameObject.transform);
            InventoryItem ii = go.GetComponent<InventoryItem>();
            Sprite sp = Resources.Load<Sprite>(ListItems[i].link);
            ii.UpdateData(ListItems[i].count, sp, ListItems[i].id, Pc);
            II.Add(ii);
        }
    }

    // Update is called once per frame
    public void UpdateData(List<DropItem> drop)
    {
        for(int i = 0; i < drop.Count; i++)
        {
            for (int j = 0; j < db.data.items.Count; j++)
            {
                if (db.data.items[j].id == drop[i].id)
                {
                    db.data.items[j].count += drop[i].count;
                }
            }
        }
        UpdateInventory();
    }
    public void UpdateInventory()
    {
        ListItems = db.data.items;
        for (int i = 0; i < II.Count; i++)
        {
            II[i].UpdateData(ListItems[i].count, ListItems[i].id);
        }
        DBSingleton.setInstance();
    }
}
