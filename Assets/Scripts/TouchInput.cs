using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    private Text textComponent;
    private Camera cam;
    public GameObject chara;

    // Use this for initialization
    void Start () {
        // テキストコンポーネントを取得
        textComponent = GetComponent<Text>();
        // メインカメラを取得
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        // 一か所以上のタッチ情報あり？
        if (Input.touchCount > 0)
        {
            string text = "";
            foreach (Touch touch in Input.touches)
            {
                // タッチ座標をスクリーン座標系からワールド座標系に変換
                Vector2 worldpos = cam.ScreenToWorldPoint(touch.position);
                text += "touch" + touch.fingerId +
                    ":(" + worldpos.x + "," + worldpos.y + ")" + "\n";
                if (touch.phase == TouchPhase.Began)
                {
                    Instantiate(chara, worldpos, Quaternion.identity);
                }
            }
            textComponent.text = text;
        }
        else
        {
            textComponent.text = "No touch";
        }
    }
}
