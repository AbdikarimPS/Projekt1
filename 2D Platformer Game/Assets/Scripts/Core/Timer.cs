using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
public class Timer : MonoBehaviour
{
    [Range(0, 50)]
    public float timerValue;
    public Image timerBar = null;
    public float length;
    private ButtonClickedEvent button = null;
    public bool autoclick = false;
    public bool onCooldown;
    [SerializeField] private Item item = null;
    [SerializeField] private Image[] image;

    [SerializeField] private Animator anim;
    private static readonly int FadeCache = Animator.StringToHash("isFading");

    public IEnumerator StartCooldown(float cooldown)
    {
        length = timerValue;
        onCooldown = true;
        while (length >= 0)
        {
            timerBar.fillAmount = length / timerValue;
            length -= Time.deltaTime;
            SetAlphaColor();
            yield return  null;
        }
        ResetAlphaColor();
        onCooldown = false;
    }
    private void FixedUpdate()
    {

        if (autoclick == true)
        {
            if (length >= 0)
            {
                timerBar.fillAmount = length / timerValue;
                length -= Time.deltaTime;
                SetAlphaColor();
            }
            else
            {

                button?.Invoke();
                StartAutoCooldown(timerValue);
                item.ItemIngredients();
                ResetAlphaColor();
            }
        }
    }
    private void StartAutoCooldown(float time) => timerValue = time;
    void SetAlphaColor()
    {
        anim.SetBool(FadeCache, true);

        for (int i = 0; i < image.Length; i++)
        {
            Color color = image[i].color;
            color.a = 0.6f;
            image[i].color = color;
        }
    }
    private void ResetAlphaColor()
    {
        anim.SetBool(FadeCache, false);
        for (int i = 0; i < image.Length; i++)
        {
            Color color = image[i].color;
            color.a = 1;
            image[i].color = color;
        }
    }


}


    
  
