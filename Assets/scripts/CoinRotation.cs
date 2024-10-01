using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void Update()
    {
        // Rotate the coin around the X-axis
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
