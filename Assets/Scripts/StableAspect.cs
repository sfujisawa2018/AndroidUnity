using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour {

    // 合わせる方向
    public enum Match
    {
        // 縦に合わせる
        Height,
        // 横に合わせる
        Width
    };
    // 合わせる方向
    public Match match;

    // フィールド
    private Camera cam;
    // 画像のサイズ
    public float width = 1334f;
    public float height = 750f;
    // 画像のPixel Per Unit
    private float pixelPerUnit = 100f;

    void Awake()
    {

    }

    void Update()
    {
        // カメラコンポーネントを取得
        cam = GetComponent<Camera>();
        cam.rect = new Rect(0, 0, 1.0f, 1.0f);

        // カメラのorthographicSizeを設定
        if (match == Match.Height)
        {// 縦に合わせる
            cam.orthographicSize = height / 2f / pixelPerUnit;
            float viewportW = width * Screen.height / height / Screen.width;
            cam.rect = new Rect((1.0f - viewportW) / 2.0f, 0, viewportW, 1.0f);
        }
        else
        {// 横に合わせる
            float scale = Screen.width / width;
            float dispHeight = height * scale;
            float viewportH = dispHeight / Screen.height;
            cam.rect = new Rect(0, (1.0f - viewportH) / 2.0f, 1.0f, viewportH);
        }
        cam.orthographicSize = height / 2f / pixelPerUnit;
    }
}
