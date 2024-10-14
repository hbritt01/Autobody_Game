using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Texture2D texture;
    public PolygonCollider2D[] polygonColliders;
    public int brushSize = 5;
    public string[] paintColor = {"#FFFF0000", "#FF0000FF", "#FF008000", "#FF6495ED", "#FFDDA0DD", "#FFFFD700", "#FF2F4F4F", "#FF800000",
    "#FFA0522D", "#FF4B0082"};
    public GameObject[] selectedColor;
    public int selectedIndex = -1;
    public Vector2Int textureSize;
    // Start is called before the first frame update
    void Start()
    {
        textureSize = new Vector2Int(texture.width, texture.height);
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PaintPixels();
        }
    }
    void PaintPixels() {
        // create a ray through mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider == polygonColliders[0] || hit.collider == polygonColliders[1] || hit.collider == polygonColliders[2]) {
                Vector2 uv = hit.textureCoord;
                int x = Mathf.FloorToInt(uv.x * textureSize.x);
                int y = Mathf.FloorToInt(uv.y * textureSize.y);
                if (selectedIndex >= 0 && ColorUtility.TryParseHtmlString(paintColor[selectedIndex], out Color color))
                {
                    PaintCircle(x, y, color);
                    texture.Apply();
                }
            }
        }
    }
    void PaintCircle(int centerX, int centerY, Color color) 
    {
        for (int y = -brushSize; y <= brushSize; y++) {
            for (int x = -brushSize; x <= brushSize; x++) {
                if (x * x + y * y <= brushSize * brushSize)
                {
                    int pixelX = centerX + x;
                    int pixelY = centerY + y;
                    if (pixelX >= 0 && pixelY < textureSize.x && pixelY >= 0 &&pixelY < textureSize.y)
                        texture.SetPixel(pixelX, pixelY, color);
                }
            }
        }
    }
}
