using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDatabase : ItemDatabase
{
    private void Awake()
    {
        BuildDatabase();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void BuildDatabase()
    {
        items = new List<Item>()
        {
        new SeedItem(1, "Gold Ore", "Smelt to make gold bars", 20, 0, Resources.Load<GameObject>("Standard/Tomato_Plant 1"), new Dictionary<string, int> { { "Value", 20 } }),

        new SeedItem(2, "cartoon seeds", "A pack of seeds", 30, 0, Resources.Load<GameObject>("Standard/Turnip_Plant"), new Dictionary<string, int> { { "Value", 40 } })
        };

      
    }
}

 
