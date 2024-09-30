using UnityEngine;
using UnityEngine.UI;

public class ZiplineController : MonoBehaviour
{
    public Button startButton; // Assign your button in the Inspector
    public GameObject zipline; // Assign your zipline GameObject here
    public Transform ziplineStart; // Set your zipline start position
    public Transform ziplineEnd; // Set your zipline end position
    public float speed = 5f; // Speed of movement

    private bool isZipping = false;

    void Start()
    {
        startButton.onClick.AddListener(StartZipline);
        zipline.SetActive(false); // Hide zipline initially
    }

    void Update()
    {
        if (isZipping)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, ziplineEnd.position, step);

            if (Vector3.Distance(transform.position, ziplineEnd.position) < 0.001f)
            {
                isZipping = false;
                zipline.SetActive(false); // Hide zipline after use
                Debug.Log("Zipline Experience Complete");
            }
        }
    }

    void StartZipline()
    {
        if (!isZipping)
        {
            isZipping = true;
            zipline.SetActive(true);
            Debug.Log("Starting Zipline Experience");
            // Set the player's starting position at the zipline start point
            transform.position = ziplineStart.position;
        }
    }
}