using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirSlashState : PlayerAttackState
{
    public PlayerAirSlashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
    public override void Enter(){
        base.Enter();
    }
    public override void Exit(){
        base.Exit();
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        if(Time.time >= startTime + .5f){
            stateMachine.ChangeState(player.AirState);
        }
    }
}
