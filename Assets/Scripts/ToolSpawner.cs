using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSpawner : MonoBehaviour
{
    //public Sprite image;
    private Image mouseFollow;
    public GameObject tool;
    private ToolPicker toolPicker;

    private bool follow = false;

    // Start is called before the first frame update
    void Start()
    {
        mouseFollow = transform.GetChild(0).GetComponent<Image>();
        mouseFollow.sprite = GetComponent<Image>().sprite;
        mouseFollow.enabled = false;
        toolPicker = GetComponentInParent<ToolPicker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow) {
            mouseFollow.transform.position = Input.mousePosition;
        }
    }

    public void Select() {
        toolPicker.Select(this);
        follow = true;
        mouseFollow.enabled = true;
        Debug.Log("Reeee");
    }

    public void Deselect() {
        mouseFollow.enabled = false;
        mouseFollow.transform.position = transform.position;
        follow = false;
    }
}
