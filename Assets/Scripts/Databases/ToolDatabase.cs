using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDatabase : ItemDatabase
{


    protected override void BuildDatabase()
    {
        items = new List<Item>()
        {
        new ToolItem(1, "Shovel", "used to till land", 20, 0, Resources.Load<GameObject>("Standard/Tomato_Plant 1"), new Dictionary<string, int> { { "Value", 20 } })

        };
    }

} 
