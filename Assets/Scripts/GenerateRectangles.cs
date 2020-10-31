using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateRectangles : MonoBehaviour
{
    public Transform prefabOne;
    public Sprite[] sprit;
    public string[] texts;
    void Start()
    {
        var index = 0;
        for (int i = 0; i < 3; i++)
        {
            var j = Instantiate(prefabOne, transform);
            var comps = j.GetComponentsInChildren<Image>();
            var compsText = j.GetComponentsInChildren<Text>();
            for (var e = 4; e < 9; e++)
            {
                comps[e].sprite = sprit[index++];
            }
        }
    }
    void Update()
    {
        
    }
}
