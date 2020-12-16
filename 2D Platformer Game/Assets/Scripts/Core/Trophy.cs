using System.Collections.Generic;
using UnityEngine;
using System;
public class Trophy : MonoBehaviour
{
    [SerializeField] private ItemList itemList = null;
    [SerializeField] private List<Items> items = new List<Items>();
    [SerializeField] private int[] values;
    [SerializeField] private int[] result;

    int button = 0;
   
    public void SetTrophy()
    {

        bool won = true;
        for (int i = 0; i < items.Count; i++)
        {
            if (!items[i].allowedItem) { continue; }
            result[i] = Convert.ToInt32(itemList.itemData[i].itemText.text);
            if (values[i] <= result[i]) { continue; }
            print($" Won: false  Values: {values[i]} Result: {result[i]}");
            won = false;
            break;
        }
        if (!won) { return; }
            GetTrophy();
    }

    public void GetTrophy()
    {
        button++;
        Destroy(gameObject);
        if(button == 4)
        {
            print("End Game");
        }
    }
}
