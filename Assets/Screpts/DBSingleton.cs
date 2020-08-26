using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DBSingleton
{
    public Datas data;
    private static DBSingleton db;
    private static object syncRoot = new object();

    protected DBSingleton(){}

    public static DBSingleton getInstance()
    {
        lock (syncRoot)
        {
            if (db == null)
            {
                db = new DBSingleton();
                string path = "database.json";
                path = Path.Combine(Application.streamingAssetsPath, path);
                string result = File.ReadAllText(path);
                db.data = JsonUtility.FromJson<Datas>(result);
            }
        }
        return db;
    }

    public static DBSingleton setInstance()
    {
        lock (syncRoot)
        {
            if (db != null)
            {
                string fromJson = JsonUtility.ToJson(db.data);
                string path = "database.json";
                path = Path.Combine(Application.streamingAssetsPath, path);
                File.WriteAllText(path, fromJson);
            }
        }
        return db;
    }
}

[Serializable]
public class Datas
{
    public int exp;
    public int lvl;
    public int gold;
    public float x;
    public float y;
    public float hp;
    public float mana;
    public List<items> items = new List<items>();
}

[Serializable]
public class items
{
    public int id;
    public String name;
    public String desk;
    public String link;
    public int count;
}
[Serializable]
public class DropItem
{
    public int id; 
    public int count;
    public DropItem(int ID, int Count)
    {
        id = ID;
        count = Count;
    }
}