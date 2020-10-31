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
    public static string MyName = "Борис";
    public string[] arraySmall;
    public Sprite[] spr;
    public GameObject pref;
    private List<GameObject> list = new List<GameObject>();
    public Dictionary<string, List<string[]> > dic = new Dictionary<string, List<string[]> >();
    public GameObject prefChat;
    public Button send;
    public Text textview;
    public GameObject movied;
    public Vector2 start;
    public Vector2 end;
    
    void Start()
    {
        ChooseDialog();
    }

    private void ChooseDialog()
    {
        RemovedList();
        for (var e = 0; e < arraySmall.Length; e++)
        {
            var a = Instantiate(pref, transform);

            a.GetComponentInChildren<Text>().text = arraySmall[e];
            a.GetComponentsInChildren<Image>()[1].sprite = spr[e];
            var e1 = e;
            a.GetComponent<Button>().onClick.AddListener(() => OpenChat(arraySmall[e1]));
            list.Add(a);
        }
    }

    void OpenChat(string name)
    {
        //var an = movied.AddComponent<AnimationMoveTo>();
       
        RemovedList();
        if (!dic.ContainsKey(name))
            dic[name] = new List<string[]>();
        List<string[]> arr = dic[name];
        foreach (var ss in arr)
        {
         
            var go = Instantiate(prefChat, transform);
            var array = go.GetComponentsInChildren<Text>();
            array[0].text = ss[0];
            array[1].text = ss[1];
            list.Add(go);
        }
        
        send.onClick.RemoveAllListeners();
        send.onClick.AddListener(() => AddMessage(name));
    }

    void AddMessage(string chatName)
    {
        dic[chatName].Add(new []{MyName, textview.text});
        OpenChat(chatName);
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