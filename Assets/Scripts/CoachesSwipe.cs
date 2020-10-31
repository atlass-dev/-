using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoachesSwipe : MonoBehaviour
{
    public GameObject smallCoaches;
    public Coaches script;
    public void ChangeSmallCoaches()
    {
        RectTransform rect = GetComponent<RectTransform>();
        if (rect.position.x != 400)
        {
            script.small = smallCoaches;
        }
    }
}

