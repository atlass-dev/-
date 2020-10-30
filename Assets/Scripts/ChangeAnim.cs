using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAnim : MonoBehaviour
{
    public float time;
    Scrollbar scroll;
    Image im;
    void Update()
    {
        var val = scroll.value;
        var c = im.color;
        var cblock = scroll.colors;
        if (val == 1f)
            im.color = Color.white;
        else
            im.color = Color.white;
        /*cblock.normalColor = Color.Lerp(Color.green, Color.red, Mathf.PingPong(Time.time, 1));*/
    }
}
