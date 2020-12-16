using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int coins;
    [SerializeField] private TextMeshProUGUI coinsUIHome, coinsUIShop = null;


    private void Update()
    {
        coinsUIHome.text =  coins.ToString();
        coinsUIShop.text = coins.ToString();
    }
}
