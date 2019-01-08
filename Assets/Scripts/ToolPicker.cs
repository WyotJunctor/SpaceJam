using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPicker : MonoBehaviour
{

    public List<ToolSpawner> toolSpawners = new List<ToolSpawner>();
    public static GameObject currentTool;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in transform) {
            toolSpawners.Add(t.GetComponent<ToolSpawner>());
        }
    }

    public void Select(ToolSpawner toolSpawner) {
        if (toolSpawner.tool)
            currentTool = toolSpawner.tool;

        foreach (ToolSpawner ts in toolSpawners) {
            if (ts != toolSpawner)
                ts.Deselect();
        }
    }
}
