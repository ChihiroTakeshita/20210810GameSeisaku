using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BowStatusUI : MonoBehaviour
{
    public Player player;
    public Text lvText;
    public Text lvUpButtonText;
    public Text sellButtonText;
    [SerializeField]

    void Update()
    {
        if (player.selectBow == null)
        {
            lvText.text = "LV: - ";
            lvUpButtonText.text = " - GOLD";
            sellButtonText.text = " - GOLD";
        }
        else
        {
            lvText.text = $"LV:{player.selectBow.lv}";
            lvUpButtonText.text = $"{player.selectBow.Cost}GOLD";
            sellButtonText.text = $"{player.selectBow.Price}GOLD";
        }
    }
}
