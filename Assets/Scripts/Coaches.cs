using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Coaches : MonoBehaviour
{
    public string[] arraySmall;
    public string[] arrayName;
    public string[] arrayDesc;
    public Sprite[] sprites;
    public GameObject small;
    public GameObject content;
    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;
    void Start()
    {
        RectTransform rect = content.GetComponent<RectTransform>();
        rect.transform.localPosition = new Vector3(0.0f, 329.0f, 0.0f);
        _group = GetComponent<VerticalLayoutGroup>();
        setSmall();
    }

    private void RemovedList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }


    void setSmall()
    {
        RemovedList();
        if (arraySmall.Length > 0)
        {
            var pr1 = Instantiate(small, transform);
            var h = pr1.GetComponent<RectTransform>().rect.height;
            var tr = GetComponent<RectTransform>();
            tr.sizeDelta = new Vector2(tr.rect.width, h * arraySmall.Length);
            Destroy(pr1);
            for (var i = 0; i < arraySmall.Length; i++)
            {
                var pr = Instantiate(small, transform);
                Text[] texts = pr.GetComponentsInChildren<Text>();
                texts[0].text = arrayName[i];
                texts[1].text = arrayDesc[i];
                pr.GetComponentInChildren<Text>().text = arraySmall[i];
                pr.GetComponentsInChildren<Image>()[1].sprite = sprites[i];
                var i1 = i;              
                list.Add(pr);
            }
        }
    }
}
