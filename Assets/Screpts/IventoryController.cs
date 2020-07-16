using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryController : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject InventoryGen;
    public GameObject InvenoryItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInvenotry()
    {
        InventoryPanel.SetActive(true);
    }
    public void CloseInvenotry()
    {
        InventoryPanel.SetActive(false);
    }
}
