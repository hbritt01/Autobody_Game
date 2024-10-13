using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOGBehavior : MonoBehaviour
{
    public Vector3 targetPositionW = new Vector3(0, 0, 0);
    public Vector3 startPositionW = new Vector3(-4.5f, 0, 0);
    public Vector3 targetScaleW = new Vector3(2f, 2f, 0);
    public Vector3 startScaleW = new Vector3(1f, 2f, 0);

    public Vector3 targetPositionL = new Vector3(0, 0, 0);
    public Vector3 startPositionL = new Vector3(4.5f, 0, 0);
    public Vector3 targetScaleL = new Vector3(2.4f, 2.3f, 0);
    public Vector3 startScaleL = new Vector3(1.2f, 2.3f, 0);

    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private bool wins = true;

    // Start is called before the first frame update
    void Start()
    {
        if(wins){
            transform.position = startPositionW;
            transform.localScale = startScaleW;
        } else {
            transform.position = startPositionL;    
            transform.localScale = startScaleL;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wins){
            transform.position = Vector3.MoveTowards(transform.position, targetPositionW, 2 * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScaleW, 1 * Time.deltaTime);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, targetPositionL, 2 * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScaleL, 1 * Time.deltaTime);
        }
        
    }
}
