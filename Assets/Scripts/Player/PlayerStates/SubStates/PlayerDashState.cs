using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public PlayerDashManagerState state_manager;
    bool ground_dash=false;
    
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(playerData.Crouch_Height);
        ground_dash=false;
        player.physics.AddModofier(state_manager.Dash_Mod);
        if(!player.physics.On_ground){
            player.physics.SetGravity(0);
            player.SetVelocityY(0);
        }else{
            ground_dash=true;
        }
        player.SetVelocityX(player.transform.localScale.x * playerData.Dash_Multiplier);
        Debug.Log(player.transform.localScale.x * playerData.Dash_Multiplier);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(playerData.Normal_Height);
        if(!ground_dash)    
            player.physics.ResetGravity();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!CheckJumpInput()){
            // if(ground_dash && !player.physics.On_ground){
            //     stateMachine.ChangeState(player.AirState);
            // }else{
                
            // }
            if(player.physics.Wall_dir()!=0){
                stateMachine.ChangeState(ground_dash?player.IdleState:player.AirState);
            }
        }
        
        if(Time.time >= startTime + playerData.Dash_Timer || !Dash_Hold){
            if(ground_dash){
                if(player.DetectCeiling()){
                    stateMachine.ChangeState(player.CrouchIdleState);    
                }else{
                    stateMachine.ChangeState(player.IdleState);
                }
            }else{
                stateMachine.ChangeState(player.AirState);
            }
        }
    }
    bool CheckJumpInput(){
        if(JumpInput){
            player.Input.UseJumpInput();
            if(!player.AirState.doubleJumped){
                if(!ground_dash){
                    player.AirState.doubleJumped = true;
                }
                stateMachine.ChangeState(player.JumpState);
            }
            
            return true;
        }
        return false;
    }
}
