using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ShowNews : MonoBehaviour
{
    private Text text;

    public string fullText;

    public float width = 500;
    public float heightImage = 700;
    
    private Button button;
    private RectTransform buttTransform;

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(swapData);
        buttTransform = button.GetComponent<RectTransform>();
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void swapData()
    {
        var old = text.text;
        text.text = fullText;
        fullText = old;
        buttTransform.sizeDelta = new Vector2(buttTransform.rect.width, heightImage);
    }
}
