using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Recipe> recipe = new List<Recipe>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Recipe
{
    public List<int> Rets = new List<int>();
    public int ExitItem;
    public int CountItem;
}
