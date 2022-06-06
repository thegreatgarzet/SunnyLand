using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewHitBox : MonoBehaviour
{
    public HitBox box;
    public Color32 _color;
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawCube((Vector2)transform.position + new Vector2((box.offset.x)* transform.localScale.x, box.offset.y), box.size);
    }
}
