using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRectangles : MonoBehaviour
{
    public Transform prefabOne;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(prefabOne, transform);

        }
    }
    void Update()
    {
        
    }
}
