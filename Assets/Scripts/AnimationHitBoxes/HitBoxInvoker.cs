using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using GabrielBigardi.SpriteAnimator;

[RequireComponent(typeof(SpriteAnimator))]
public class HitBoxInvoker : MonoBehaviour
{
    public SpriteAnimator anim;
    public AnimHitBox current_anim;
    public AnimHitBox[] HitBoxes_List;
    public int c_frame;
    public string c_name;
    //VISUALIZER
        public Vector2 Visualizer_Offset, Visualizer_Size;
    //VISUALIZER
    
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {

    }
    private void Awake()
    {
        anim = GetComponent<SpriteAnimator>();
        anim.SpriteChanged +=CheckForHitBox;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        c_name = anim.CurrentAnimation.Name;
        if(c_name == null){
            return;
        }
        for (int i = 0; i < HitBoxes_List.Length; i++)
        {
            current_anim = HitBoxes_List[i].AnimationName == c_name?HitBoxes_List[i]:null;
        }
        
    }
    public void CheckForHitBox(){
        if(current_anim ==null){
            return;
        }
        for (int i = 0; i < current_anim.HitBoxes.Length; i++)
        {
            if(anim.CurrentFrame == current_anim.HitBoxes[i].frame){
                InstantiateBox(current_anim.HitBoxes[i]);
            }
        }
    }
    void InstantiateBox(HitBox hitBox){
        Vector2 new_offset = new Vector2(hitBox.offset.x * transform.localScale.x, hitBox.offset.y);
        Vector2 pos = (Vector2)transform.position + new_offset;
        Collider2D[] _results = Physics2D.OverlapBoxAll(pos, hitBox.size, 0, hitBox.collision_mask);
        for (int i = 0; i < _results.Length; i++)
        {
            print("Colidiu com: " + _results[i].ToString());
        }
    }
}
