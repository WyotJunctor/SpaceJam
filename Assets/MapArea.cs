using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceTool() {
        if (ToolPicker.currentTool) {
            Instantiate(ToolPicker.currentTool, (Vector2)cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }
}
