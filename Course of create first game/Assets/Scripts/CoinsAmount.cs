
using TMPro;
using UnityEngine;

public class CoinsAmount : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text _coinAmountText;

    private int _coinsCounter;
    public int CoinsCounter
    {
        get
        {
            return _coinsCounter;
        }
        set
        {
            _coinsCounter = value;
            _coinAmountText.text = "Coins: " + value.ToString();
        }
    }
}
