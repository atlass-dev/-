using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPrefSize : MonoBehaviour
{
    private RectTransform text;
    public float width = 10;
    public float height = 10;
    void Start()
    {
        text = GetComponentInChildren<Text>().GetComponent<RectTransform>();
        var my = GetComponent<RectTransform>();
        print(my.rect);
        GetComponentInChildren<Text>().GetComponent<ContentSizeFitter>().verticalFit =
            ContentSizeFitter.FitMode.PreferredSize;
        print(text.rect);
        my.sizeDelta = new Vector2(text.rect.width + width, text.rect.height + height);
    }
    
}
