using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LoginPage : MonoBehaviour
{
    [SerializeField] GameObject[] lines;

    public void DrawFirstLine()
    {
        ChangeColor(0);
    }

    public void DrawSecondLine()
    {
        ChangeColor(1);
    }
    public void DrawThirdLine()
    {
        ChangeColor(2);
    }

    public void ChangeColor(int i)
    {
        lines[i].GetComponent<Shadow>().effectColor = new Color(0.93f,0.69f,0.13f,1.0f);
        for (int j = 0; i < lines.Length; j++)
        {
            if (j != i)
            {
                lines[j].GetComponent<Shadow>().effectColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
            }
        }
    }

    public void ButtonClick()
    {

    }
}
