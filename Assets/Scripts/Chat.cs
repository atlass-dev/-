using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Chat : MonoBehaviour
{
    public string[] arraySmall;
    public Sprite[] spr;
    public GameObject pref;
    private List<GameObject> list = new List<GameObject>();
    void Start()
    {
        for (var e = 0; e < arraySmall.Length; e++) 
        {
            var a = Instantiate(pref, transform);
            var fontS = a.GetComponentInChildren<Text>().fontSize;
            var b = a.GetComponentsInChildren<Image>()[0].rectTransform.sizeDelta.y;
            b = fontS * 2;
            a.GetComponentInChildren<Text>().text = arraySmall[e];
            a.GetComponentsInChildren<Image>()[1].sprite = spr[e];
        }
    }
    private void RemovedList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }
    
}