using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows;
using System.Windows.Media;

public class NewBehaviourScript : MonoBehaviour
{
    public Texture2D texture;
    public PolygonCollider[] polygonColliders;
    public int brushSize = 5;
    public string[] paintColor = {"#FFFF0000", "#FF0000FF", "#FF008000", "#FF6495ED", "#FFDDA0DD", "#FFFFD700", "#FF2F4F4F", "#FF800000",
    "#FFA0522D", "#FF4B0082"};
    public gameObject[] selectedColor;
    public int selectedIndex = MIN_INT;
    public Vector2Int TextureSize;
    // Start is called before the first frame update
    void Start()
    {
        TextureSize = new Vector2Int(texture.width, texture.height);
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseDown(0))
        {
            PaintPixels();
        }
        ColorSelector();
    }
    void PaintPixels() {
        // create a ray through mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition)
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == polygonColliders[0] || hit.collider == polygonColliders[1] || hit.collider == polygonColliders[2])
                Vector2 uv = hit.textureCoord;
            else if (hit.collider == )
            int x = Mathf.FloorToInt(uv.x * textureSize.x);
            int y = Mathf.FloorToInt(uv.y * textureSize.y);
            if (selectedIndex >= 0 && ColorUtility.TryToParse(paintColor[selectedIndex], out Color color))
            {
                PaintCircle(x, y, color);
                texture.Apply();
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
                    if (pixelX >= 0 && pixelY < textureSize.x && pixelY >= pixelY < textureSize.y) 
                        textureSize.SetPixel(pixelX, pixelY, color);
                }
            }
        }
    }
}
