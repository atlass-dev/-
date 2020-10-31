using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Tasks : MonoBehaviour
{
    public string[] arraySmall;
    public Sprite[] sprites;
    public string[] arrayBig;
    public string[] arrayBigConditions;
    public string[] arrayBigRewards;
    public GameObject small;
    public GameObject big;
    public GameObject content;
    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;
    void Start()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
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

    private void Remove(int id)
    {
        int count = 0;
        foreach (var elem in list)
        {
            if (count == id)
            {
                Destroy(elem);
            }
            count++;
        }
    }

    void SetBig(int id)
    {
        Remove(id);
        var go = Instantiate(big, transform);
        var text = go.GetComponentInChildren<Text>();
        text.text = arrayBig[id];
        Text[] texts = go.GetComponentsInChildren<Text>();
        texts[1].text = arrayBigConditions[id];
        texts[3].text = arrayBigRewards[id];

        go.GetComponentsInChildren<Image>()[1].sprite = sprites[id];
        var button = go.GetComponentInChildren<Button>();
        button.onClick.AddListener(setSmall);

        var h = go.GetComponent<RectTransform>().rect.height;
        var tr = GetComponent<RectTransform>();
        tr.sizeDelta = new Vector2(tr.rect.width, h);

        list.Add(go);
    }

    void setSmall()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
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
                pr.GetComponentInChildren<Text>().text = arraySmall[i];
                pr.GetComponentsInChildren<Image>()[1].sprite = sprites[i];
                var i1 = i;
                pr.GetComponent<Button>().onClick.AddListener(() => SetBig(i1));
                list.Add(pr);
            }
        }
    }

}
