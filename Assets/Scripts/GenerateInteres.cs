using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateInteres : MonoBehaviour
{
    public Transform prefabOne;
    public string[] texts;
    public Color colorOne, colorTwo; 
    void Start()
    {
        print(texts.Length);
        for (int i = 0; i < texts.Length / 7; i++)
        {
            var j = Instantiate(prefabOne, transform);
            var butComp = j.GetComponentsInChildren<Button>();
            foreach (var w in butComp) 
            {
                w.onClick.AddListener(() => MyListener(w));
            }
            var compsText = j.GetComponentsInChildren<Text>();
            print(compsText.Length);
            for (var e = 0; e < 7; e++)
            {
                compsText[e].text = texts[i * 7 + e];
            }
        }
    }

    void MyListener(Button but)
    {
        print(but);
        var img = but.GetComponent<Image>();
        print(img.color);
        if (img.color.Equals( colorOne)) img.color = colorTwo;
        else img.color = colorOne;
    }

}
