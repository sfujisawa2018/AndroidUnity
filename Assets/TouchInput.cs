using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    private Text textComponent;

    // Use this for initialization
    void Start () {
        textComponent = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        // 一か所以上のタッチ情報あり？
        if (Input.touchCount > 0)
        {
            string text = "";
            foreach (Touch touch in Input.touches)
            {
                text += "touch" + touch.fingerId +
                    ":(" + touch.position.x + "," + touch.position.y + ")" + "\n";
            }
            textComponent.text = text;
        }
        else
        {
            textComponent.text = "No touch";
        }

    }
}
