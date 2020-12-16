using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public struct ItemData
{
    public string itemName;
    [Range(1, 50)]
    public int minValue;
    [Range(1, 50)]
    public int maxValue;
    public int itemValue;
    public Text itemText;
    
    public ItemData(int min, int max, string name, Text it, int ie)
    {
        this.minValue = min;
        this.maxValue = max;
        this.itemName = name;
        this.itemText = it;
        this.itemValue = ie;
    }
}
public class ItemList : MonoBehaviour
{
    [SerializeField] private PlayerStats pS = null;
     int[] allAmountValue = { 2,5,10,50,100};

    public ItemData[] itemData = null;

    [Header("AudioManager")] public AudioClip[] sounds = null;
    public new AudioSource audio;
    public  AudioSource shop;
    private int result;

    public void ItemCollectAll(int type)
    {
        print($"ItemValue: {itemData[type].itemValue}");
        pS.coins += itemData[type].itemValue * allAmountValue[type];
        print($" Coins: {pS.coins} ItemText: {itemData[type].itemValue} allAmountValue: {allAmountValue}");
        result -= itemData[type].itemValue * allAmountValue[type];
        itemData[type].itemValue = 0;
        itemData[type].itemText.text = 0.ToString();        
    }

    public void PlaySound(int type)
    {
        audio.clip = sounds[type];
        audio.Play();
    }

}

