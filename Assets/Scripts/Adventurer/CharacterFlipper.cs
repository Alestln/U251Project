using UnityEngine;

public class CharacterFlipper
{
    public void UpdateDirection(float direction, Transform rootObject)
    {
        if (direction != 0f)
        {
            Vector3 scale = rootObject.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            rootObject.localScale = scale;
        }
    }
}