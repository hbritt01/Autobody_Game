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

    public Sprite[] sprites; 
    public bool wins = true;

    private GameObject winObject;
    private GameObject loseObject;

    void Start()
    {
        winObject = new GameObject("Win");
        loseObject = new GameObject("Lose");

        SpriteRenderer winRenderer = winObject.AddComponent<SpriteRenderer>();
        SpriteRenderer loseRenderer = loseObject.AddComponent<SpriteRenderer>();

        winRenderer.sprite = sprites[0]; 
        loseRenderer.sprite = sprites[1];

        winObject.transform.position = startPositionW;
        winObject.transform.localScale = startScaleW;

        loseObject.transform.position = startPositionL;
        loseObject.transform.localScale = startScaleL;
    }

    void Update()
    {
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

