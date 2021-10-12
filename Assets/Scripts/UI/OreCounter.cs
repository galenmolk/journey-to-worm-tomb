using TMPro;
using UnityEngine;

public class OreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Animator animator;
    
    private int oreCount;
    private static readonly int AddOreAnimatorTrigger = Animator.StringToHash("AddOre");
    
    public void AddOre(int amount)
    {
        oreCount += amount;
    }

    private void DisplayOreCountChange()
    {
        countText.text = oreCount.ToString();
        animator.SetTrigger(AddOreAnimatorTrigger);
    }
}
