using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected Vector2 Input;
    
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
        
    }
    public virtual void PhysicsUpdate(){
        DoCheck();
    }
    public virtual void DoCheck(){
        
    }
}
