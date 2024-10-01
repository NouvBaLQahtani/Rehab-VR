using System.Collections;
using TMPro;
using UnityEngine;

public class coinCollection : MonoBehaviour
{
   private int Coin = 0;
   public TextMeshProUGUI coinText;
   public float rotationSpeed = 50f;  // Optional if you want to control rotation in the player script

   private void Start()
   {
       coinText.text = "Coins: " + Coin.ToString();
   }

   private void Update()
   {
       // You can remove this rotation part if it's only for the coins
   }

   private void OnTriggerEnter(Collider other)
   {
       // Check if the object the player collided with is tagged as "coin"
       if (other.CompareTag("coin"))
       {
           Coin++;  // Increment the coin count
           coinText.text = "Coins: " + Coin.ToString();  // Update the UI text
           Debug.Log("Collected coin: " + Coin);

           // Destroy the coin after collecting it
           Destroy(other.gameObject);
       }
   }
}
