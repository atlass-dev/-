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
    public InputField field;
    public Button back;
    void Start()
    {
        back.onClick.AddListener(ChooseDialog);
        
        ChooseDialog();
        var list = new List<string[]>();
        list.Add(new []{"Василий", "Привет всем!"});
        list.Add(new []{"Мария", "Здравствуйте!"});
        list.Add(new []{"Олег Иванович", "Привет всем!"});
        list.Add(new []{"Мария", "Как дела?"});
        list.Add(new []{"Василий", "Мария, Отлично!"});
        dic["Общий чат"] = list;
    }

    private void ChooseDialog()
    {
        SetEnabled(false);
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

    void SetEnabled(bool s)
    {
        field.enabled = s;
        foreach (var child in field.GetComponentsInChildren<MaskableGraphic>())
        {
            child.enabled = s;
        }

        back.enabled = s;
        foreach (var child in back.GetComponentsInChildren<MaskableGraphic>())
        {
            child.enabled = s;
        }
    }

    void OpenChat(string name)
    {
        SetEnabled(true);
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
        field.text = "";
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