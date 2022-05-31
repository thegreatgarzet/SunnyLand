﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SunnyLand/PlayerData", order = 0)]
public class PlayerData : ObjData {
  
    [Header("Exposed Values")]
    
	
    public bool EnableDoubleJump=true;
    [Header("Stair")]
    public float GrabStair_Timer = .1f;
    public float StairClimb_Speed = 1;
    [Header("Dash")]
    public float Dash_Timer=.3f;
    public float Dash_Multiplier = 1.2f;
    public float AirDash_Anim_Timer;
    [Header("COLLIDER VALUES")]
    public float Normal_Height;
    public float Crouch_Height;
    [Header("Exposed Values")]
    public float WallSlide_Speed, WallJump_Timer;
 
}
   [System.Serializable]
    public struct ColliderValues{
        public float y_offset;
        public float y_height;
    }