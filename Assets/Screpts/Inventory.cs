using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private DBSingleton db;
    public GameObject item;
    private List<items> ListItems = new List<items>();
    public PlayerController Pc;
    // Start is called before the first frame update
    void Start()
    {
        db = DBSingleton.getInstance();
        ListItems = db.data.items;
        //Debug.Log(ListItems[0].name);
        for(int i = 0; i<ListItems.Count; i++)
        {
            //Debug.Log(ListItems[i].name);
            GameObject go = Instantiate(item);
            go.transform.SetParent(gameObject.transform);
            InventoryItem ii = go.GetComponent<InventoryItem>();
            Sprite sp = Resources.Load<Sprite>(ListItems[i].link);
            ii.UpdateData(ListItems[i].count, sp, ListItems[i].id, Pc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
