using System.Transactions;
using UnityEngine;

public class AnimationScaleTo : AnimationTo
{
    public float startScale;
    public float endScale;
    protected override void UpdatePercent(float newPercent)
    {
        var scale = startScale + (endScale - startScale) * newPercent;
        transform.localScale = new Vector3(scale, scale);
    }
}