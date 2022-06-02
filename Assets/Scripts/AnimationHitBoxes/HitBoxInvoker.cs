using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using GabrielBigardi.SpriteAnimator;

[RequireComponent(typeof(SpriteAnimator))]
public class HitBoxInvoker : MonoBehaviour
{
    SpriteAnimator anim;
    public AnimHitBox current_anim;
    public AnimHitBox[] HitBoxes_List;
    public int c_frame;
    
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
        string c_name = anim.CurrentAnimation.Name;
        
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
                print("Box Created");
            }
        }
    }
}
