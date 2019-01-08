using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseSplashScreen : MonoBehaviour, IPointerClickHandler
{

    public GameObject splashScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pedata) {
        if (pedata.button == PointerEventData.InputButton.Left) {
            splashScreen.SetActive(false);
        }
    }
}
