using UnityEngine;

public class MoveObjectOntoScene : MonoBehaviour
{
    // Set the target position in the Inspector
    public Vector3 targetPosition = new Vector3(-10, -1, 0);
    public float moveSpeed = 3.0f; // Set the speed of movement

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, set the starting position off-screen or off the scene
        transform.position = new Vector3(1, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object toward the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
