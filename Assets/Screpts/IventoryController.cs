using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryController : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject InventoryGen;
    public GameObject InvenoryItem;

    public void OpenInvenotry()
    {
        InventoryPanel.SetActive(true);
    }
    public void CloseInvenotry()
    {
        InventoryPanel.SetActive(false);
    }
}
