using UnityEngine;
using UnityEngine.UI;

public class ZiplineController : MonoBehaviour
{
    public Button startButton; // Assign your button in the Inspector
    public GameObject zipline; // Assign your zipline GameObject here
    public Transform ziplineStart; // Set your zipline start position
    public Transform ziplineEnd; // Set your zipline end position
    public float speed = 2f; // Speed of movement

    private bool isZipping = false;
    private Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        // Make zipline visible from the start
        zipline.SetActive(true);

        // Assuming the script is attached to the player or you can get the player transform
        playerTransform = transform; // Use this if attached to the player object

        // Assign button listener
        startButton.onClick.AddListener(StartZipline);
    }

    void Update()
    {
        if (isZipping)
        {
            float step = speed * Time.deltaTime;
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, ziplineEnd.position, step);

            // Maintain the height of the zipline
            playerTransform.position = new Vector3(playerTransform.position.x, ziplineStart.position.y, playerTransform.position.z);

            if (Vector3.Distance(playerTransform.position, ziplineEnd.position) < 0.001f)
            {
                isZipping = false;
                Debug.Log("Zipline Experience Complete");
            }
        }
    }

    void StartZipline()
    {
        if (!isZipping)
        {
            isZipping = true;
            // Set the player's starting position at the zipline start point
            playerTransform.position = new Vector3(ziplineStart.position.x, ziplineStart.position.y, ziplineStart.position.z);
            Debug.Log("Starting Zipline Experience");
        }
    }
}