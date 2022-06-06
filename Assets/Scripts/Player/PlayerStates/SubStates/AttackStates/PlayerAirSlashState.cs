using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirSlashState : PlayerInAirState
{
    public PlayerAirSlashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
public override void Enter(){
        base.Enter();
        player.sp_anim.AnimationEnded+= EndAnimation;
    }
    public override void Exit(){
        base.Exit();
        player.sp_anim.AnimationEnded-= EndAnimation;
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        if(!player.Input.Jump_Input_Hold && player.physics.velocity.y > 0){
            player.SetVelocityY(0);
        }
        // if(!player.Input.Jump_Input_Hold && player.physics.velocity.y > 0){
        //     player.SetVelocityY(0);
        // }
        // if(Dash_Input){
        //         player.Input.UseDashInput();
        //         if(player.DashManagerState.can_dash){
        //             stateMachine.ChangeState(player.DashManagerState);
        //         }
        //     }else
        //     if(JumpInput){
        //         player.Input.UseJumpInput();
        //         if(player.physics.Wall_dir()!=0){
                    
        //             stateMachine.ChangeState(player.WallJumpState);
        //         }
        //         else if(player.AirState.EnableDoubleJump && !player.AirState.doubleJumped){
        //             player.AirState.doubleJumped =true;
                    
        //             stateMachine.ChangeState(player.JumpState);
        //         }
        //     }else if(player.Stair != null && Input.y >0 && Time.time >= startTime + playerData.GrabStair_Timer){
        //         stateMachine.ChangeState(player.OnStairState);
        //     }
      
            
        //     // if(player.physics.velocity.y<=0 && player.physics.On_ground){
        //     //     stateMachine.ChangeState(player.IdleState);
        //     // }
        //     player.TryIdle();
        
    }
    public void EndAnimation(){
        stateMachine.ChangeState(player.IdleState);
    }
}
