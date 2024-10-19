using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText; // This will be linked to your TextMeshPro text field

    void Update()
    {
        // Update the text with the current number of remaining coins (coming from your coin collection logic)
        coinText.text = "remaining coins: " + CoinCollect.remainingCoins;
    }
}

