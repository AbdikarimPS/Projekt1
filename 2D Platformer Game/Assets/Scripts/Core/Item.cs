using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Items
{
    [SerializeField] private string itemName;
    public bool allowedItem;
    public Items(string itemName, bool allowedItem)
    {
        this.itemName = itemName;
        this.allowedItem = allowedItem;
    }
}
public class Item : MonoBehaviour
{
    [Header("Allowed Ingredients")] [SerializeField]
    private List<Items> items = new List<Items>();

    [SerializeField] private Timer timer = null;
    [SerializeField] private ItemList itemList = null;

    #region Old Garbage script

    //public int bean;
    //[HideInInspector]
    //public int water;
    //[HideInInspector]
    //public int milk;
    //[HideInInspector]
    //public int sugar;
    //[HideInInspector]
    //public int ice;

    //public void _itemIngredients()
    //{
    //    if (items[0].allowedItem) // bean 
    //    {
    //        bean = Random.Range(itemList.itemData[2].minValue, itemList.itemData[2].maxValue);

    //        itemList.itemData[0].itemText.text = (System.Convert.ToInt32(itemList.itemData[0].itemText.text) + bean).ToString();
    //    }
    //    if (items[1].allowedItem) // water 
    //    {
    //        water = Random.Range(itemList.itemData[1].minValue, itemList.itemData[1].maxValue);
    //    }
    //    if (items[2].allowedItem) // milk 
    //    {
    //        milk = Random.Range(itemList.itemData[2].minValue, itemList.itemData[2].maxValue);
    //        itemList.itemData[2].itemText.text = (System.Convert.ToInt32(itemList.itemData[2].itemText.text) + milk).ToString();
    //    }
    //    if (items[3].allowedItem) // sugar 
    //    {
    //        sugar = Random.Range(itemList.itemData[3].minValue, itemList.itemData[3].maxValue);
    //        itemList.itemData[3].itemText.text = (System.Convert.ToInt32(itemList.itemData[3].itemText.text) + sugar).ToString();
    //    }

    //    if (items[4].allowedItem) // ice
    //    {
    //        ice = Random.Range(itemList.itemData[4].minValue, itemList.itemData[4].maxValue);
    //        itemList.itemData[4].itemText.text = (System.Convert.ToInt32(itemList.itemData[4].itemText.text) + ice).ToString();
    //    }
    //}

    #endregion
    public void ItemIngredients()
    {
        if (timer.onCooldown) return;        
        for (var i = 0; i < items.Count; i++)
        {
            if (!items[i].allowedItem) continue;
            itemList.itemData[i].itemValue = Random.Range(itemList.itemData[i].minValue, itemList.itemData[i].maxValue);
            itemList.itemData[i].itemText.text = (System.Convert.ToInt32(itemList.itemData[i].itemText.text) + itemList.itemData[i].itemValue).ToString();
            itemList.audio.clip = itemList.sounds[1];
            itemList.audio.Play();
            StartCoroutine(timer.StartCooldown(timer.timerValue));
            }
        }
    }