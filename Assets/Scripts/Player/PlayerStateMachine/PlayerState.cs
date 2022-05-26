﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected Vector2 Input;
    public bool JumpInput, Grab_Input;
    public bool TouchingWall;
    protected PlayerData playerData;
    protected float startTime;
    private string animBoolName;
    
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName){
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter(){
        DoCheck();
        player.Anim.Play(animBoolName);
        startTime = Time.time;
        Debug.Log(animBoolName);
    }
    public virtual void Exit(){
        
    }
    public virtual void LogicUpdate(){
        JumpInput = player.Input.Jump_Input;
        Grab_Input = player.Input.Grab_Input;
        Input = player.Input.GetDirInput();
        TouchingWall = player.physics.controller.collisions.left && Input.x<0 
        || player.physics.controller.collisions.right && Input.x>0?true:false;
        
    }
    public virtual void PhysicsUpdate(){
        DoCheck();
    }
    public virtual void DoCheck(){
        
    }
}