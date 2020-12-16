using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
     ItemList itemList = null;
    [SerializeField] private PlayerStats pS = null;
    [SerializeField] private Timer timer = null;

    [SerializeField] private Text priceText, minStatusText, maxStatusText, descriptionText = null;
    [SerializeField] private GameObject purchased = null;
    [SerializeField] private Base_State Data = null;

    [SerializeField] private AudioSource source;

    public GameObject[] ParentList;

    bool bought = false;

    private void Start()
    {
        Data.minStatus = 0;
        priceText.text = Data.price.ToString();
        minStatusText.text = Data.minStatus.ToString();
        maxStatusText.text = "/ " + Data.maxStatus.ToString();
        descriptionText.text = Data.Description.ToString();
        priceText.text = Data.price.ToString();
    }
    public void SwitchStates()
    {
        switch(Data.State)
        {
            case State.ItemIngredients:
                ItemTransition();
                break;
            case State.ItemAutoClick:
                ActiveAutoClcick();
                break;
            case State.DecreaseTimer:
                ItemDecreaseTimer();
                break;
        } 
    }

    private void ItemTransition()
    {
        SetLockSound();
        if (Data.minStatus >= Data.maxStatus || Data.price > pS.coins) { return; }

            pS.coins -= Data.price;
            Data.price += Data.IncreasePrize;
            Data.minStatus++;

        priceText.text = Data.price.ToString();
        minStatusText.text = Data.minStatus.ToString();

        for (int i = 0; i < ParentList.Length; i++)
        {
            ParentList[i].GetComponent<ItemList>().itemData[Data.Itemtype].minValue += 1;
            ParentList[i].GetComponent<ItemList>().itemData[Data.Itemtype].maxValue += 1;
            Debug.Log($"Itemtype: {Data.Itemtype}");
        }


        Debug.Log("Yes");

        PlaySound();
    }


    private void ActiveAutoClcick()
    {
        SetLockSound();

        if (Data.minStatus >= Data.maxStatus || Data.price > pS.coins) { return; }
            timer.autoclick = true;
        pS.coins -= Data.price;
        Data.price += Data.IncreasePrize;
        Data.minStatus++;

        
        minStatusText.text = Data.minStatus.ToString();
            PlaySound();
    }

    private void ItemDecreaseTimer()
    {
        SetLockSound();

        if (Data.minStatus >= Data.maxStatus || Data.price > pS.coins) { return; };
        pS.coins -= Data.price;
        Data.price += Data.IncreasePrize;
        Data.minStatus++;
        minStatusText.text = Data.minStatus.ToString();
        Convert.ToInt32(timer.timerValue *= 0.9f);

        PlaySound();
    }
    private void PlaySound()
    {
        if (Data.minStatus == Data.maxStatus && bought == false ) 
        {

            purchased.SetActive(true);
            source.clip = ParentList[0].GetComponent<ItemList>().sounds[0];
            source.Play();
            bought = true;
        }
        if (Data.minStatus != Data.maxStatus)
        {
            source.clip = ParentList[0].GetComponent<ItemList>().sounds[3];
            source.Play();
        }
    }

    private void SetLockSound()
    {
        if (Data.price > pS.coins || bought == true)
        {
            source.clip = ParentList[0].GetComponent<ItemList>().sounds[4];
            source.Play();
        }
    }
}
