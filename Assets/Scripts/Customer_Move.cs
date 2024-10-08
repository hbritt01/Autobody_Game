using UnityEngine;

public class MoveObjectOntoScene : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(-10, -1, 0);
    public Vector3 startPosition = new Vector3(1, 5, 0);
    public float moveSpeed = 3.0f; // Set the speed of movement

    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private bool shouldMove = true; // Determines if the object should move

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.position = startPosition;
            shouldMove = true;
            SetRandomSprite();
        }

        if (shouldMove)
        {
            // Move the object toward the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop moving once it reaches the target position
            if (transform.position == targetPosition)
            {
                shouldMove = false;
            }
        }
    }

    void SetRandomSprite()
    {
        if (sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];
        }
    }
}
