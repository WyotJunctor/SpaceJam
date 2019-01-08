using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSpawner : MonoBehaviour
{
    //public Sprite image;
    public Image follower;
    public GameObject tool;
    private ToolPicker toolPicker;

    private bool follow = false;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount > 0) {
            follower = transform.GetChild(0).GetComponent<Image>();
            follower.sprite = GetComponent<Image>().sprite;
            follower.enabled = false;
        }
        toolPicker = GetComponentInParent<ToolPicker>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow && follower) {
            follower.transform.position = Input.mousePosition;
        }
    }

    public void Select() {
        toolPicker.Select(this);
        follow = true;
        if (follower)
            follower.enabled = true;
    }

    public void Deselect() {
        follow = false;
        if (follower)
            follower.enabled = false;
    }
}
