using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioClip collectSound; // Drag and drop the sound effect here in the Unity Inspector
    private AudioSource audioSource; // AudioSource to play the sound
    private static int totalCoins = 5; // Set the total number of coins to 5
    public static int remainingCoins; // Remaining coins counter

    void Start()
    {
        // Initialize the audio source component
        audioSource = GetComponent<AudioSource>();

        // Initialize the number of remaining coins
        remainingCoins = totalCoins;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the player's hand
        if (other.CompareTag("Hand"))
        {
            // Play the collect sound if available
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Decrease the remaining coins count
            remainingCoins--;

            // Display the updated coin count in the console (you can later connect this to a UI element)
            Debug.Log("Remaining Coins: " + remainingCoins);

            // Destroy the coin
            Destroy(gameObject);

            // If no coins are left, trigger an event (e.g., a win condition)
            if (remainingCoins <= 0)
            {
                Debug.Log("All coins collected!");
                // Here you can trigger a win condition, display a message, or move to the next level
            }
        }
    }
}

