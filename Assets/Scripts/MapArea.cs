using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{

    public static int max = 5;
    public static int current = 0;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceTool() {
        if (ToolPicker.currentTool && current < max) {
            if (!cam) {
                cam = Camera.main;
            }
            GameObject tool = Instantiate(ToolPicker.currentTool, (Vector2)cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            GameManager.instance.tools.Add(tool.GetComponent<Collider2D>());
            tool.GetComponent<Collider2D>().enabled = false;
            current++;
        }
    }
}
