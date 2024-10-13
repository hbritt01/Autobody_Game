using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOGBehavior : MonoBehaviour
{
    public Vector3 targetPositionW = new Vector3(0, 0, 0);
    public Vector3 startPositionW = new Vector3(-5f, 0, 0);
    public Vector3 targetScaleW = new Vector3(2.2f, 2.2f, 0);
    public Vector3 startScaleW = new Vector3(1f, 2f, 0);

    public Vector3 targetPositionL = new Vector3(0, 0, 0);
    public Vector3 startPositionL = new Vector3(4.9f, 0, 0);
    public Vector3 targetScaleL = new Vector3(2.6f, 2.5f, 0);
    public Vector3 startScaleL = new Vector3(1.2f, 2.3f, 0);

    public Sprite[] sprites; // Array to hold win and lose sprites
    public bool wins = true;

    private GameObject winObject;
    private GameObject loseObject;

    // Start is called before the first frame update
    void Start()
    {
        // Create separate GameObjects for win and lose sprites
        winObject = new GameObject("Win");
        loseObject = new GameObject("Lose");

        // Add SpriteRenderer components and set initial sprites
        SpriteRenderer winRenderer = winObject.AddComponent<SpriteRenderer>();
        SpriteRenderer loseRenderer = loseObject.AddComponent<SpriteRenderer>();

        winRenderer.sprite = sprites[0]; // Win sprite
        loseRenderer.sprite = sprites[1]; // Lose sprite

        // Set initial positions and scales
        winObject.transform.position = startPositionW;
        winObject.transform.localScale = startScaleW;

        loseObject.transform.position = startPositionL;
        loseObject.transform.localScale = startScaleL;
    }

    // Update is called once per frame
    void Update()
    {
        // Move and scale only the active GameObject
        winObject.SetActive(true);
        loseObject.SetActive(true);

        if(wins)
        {
            loseObject.SetActive(false);
            winObject.transform.position = Vector3.MoveTowards(winObject.transform.position, targetPositionW, 2 * Time.deltaTime);
            winObject.transform.localScale = Vector3.MoveTowards(winObject.transform.localScale, targetScaleW, 1 * Time.deltaTime);
        }
        else
        {
            winObject.SetActive(false);
            loseObject.transform.position = Vector3.MoveTowards(loseObject.transform.position, targetPositionL, 2 * Time.deltaTime);
            loseObject.transform.localScale = Vector3.MoveTowards(loseObject.transform.localScale, targetScaleL, 1 * Time.deltaTime);
        }
    }
}

