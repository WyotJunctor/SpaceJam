using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSpawner : MonoBehaviour
{
    //public Sprite image;
    public GameObject follower;
    public GameObject tool;
    private ToolPicker toolPicker;

    private bool follow = false;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        follower = transform.GetChild(0).gameObject;
        follower.SetActive(false);
        toolPicker = GetComponentInParent<ToolPicker>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow) {
            follower.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void Select() {
        toolPicker.Select(this);
        follow = true;
        follower.SetActive(true);
    }

    public void Deselect() {
        follower.SetActive(false);
        follow = false;
    }
}
