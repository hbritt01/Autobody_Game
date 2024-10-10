using UnityEngine;

public class Mechanic_Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    // public float minX = -5f;
    // public float maxX = 5f;
    // public float minY = -6f;
    // public float maxY = 3f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        Vector3 currentPosition = transform.position;

        // currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        // currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        transform.position = currentPosition;
    }

    public void Move(string str)
    {
        Debug.Log(str);
    }
}
