
    using UnityEngine;

    public class AnimationMoveTo : AnimationTo
    {
        public Vector2 start;
        public Vector2 end;

        protected override void UpdatePercent(float newPercent)
        {
            var vec = start + (end - start) * newPercent;
            transform.position = new Vector3(vec.x, vec.y, transform.position.z);
        }
    }
