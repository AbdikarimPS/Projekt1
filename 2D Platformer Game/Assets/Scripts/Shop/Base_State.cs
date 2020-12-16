using UnityEngine;
using UnityEngine.UI;

public enum State
{
    ItemIngredients,
    ItemAutoClick,
    DecreaseTimer
}
[CreateAssetMenu(fileName = "New Data", menuName = "Shop", order = 2 )]
public class Base_State : ScriptableObject
{
    [Header("Game Settings")]
    public int price;
    public int minStatus;
    public int maxStatus;
    public string Description;
    [Header("Optional Settings")]
    public int Itemtype;
    public int IncreasePrize = 50;
    [Header("State Settings")]
    public State State;

}
