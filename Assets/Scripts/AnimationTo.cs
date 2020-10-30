using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationTo : MonoBehaviour
{
    public float duration = 1f;
    public float percent = 0f;
    

    protected abstract void UpdatePercent(float newPercent);
    

    // Update is called once per frame
    void Update()
    {
        percent += Time.deltaTime / duration;
        UpdatePercent(percent);
        if (percent >= 1f)
        {
            UpdatePercent(1f);
            Destroy(this);
        }
    }
}
