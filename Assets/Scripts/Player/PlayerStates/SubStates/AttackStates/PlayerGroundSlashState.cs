using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundSlashState : PlayerAttackState
{
    public int current_slash;
    public bool attack_buffer=false;
    
    public PlayerGroundSlashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
    public override void Enter(){
        base.Enter();
        current_slash = 0;
        attack_buffer = false;
        player.SetVelocityX(0);
        player.sp_anim.AnimationEnded+= EndAnimation;
    }
    public override void Exit(){
        base.Exit();
        player.sp_anim.AnimationEnded-= EndAnimation;
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        AttackInfo attackInfo = player.Input.GetAttackInput();
        if(attackInfo.PrimaryAttack){
            attack_buffer = true;
        }
        if(Time.time >= startTime + playerData.attack_buffer_timer){
            attack_buffer = false;
        }
        if(!player.physics.On_ground && player.physics.velocity.y<=-0.5f){
            stateMachine.ChangeState(player.AirState);
        }else{
            if(Dash_Input){
                player.Input.UseDashInput();
                stateMachine.ChangeState(player.DashManagerState);
                isExitingState = true;
            }else
            if(JumpInput){
                player.Input.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
        }
    }
    public void EndAnimation(){
        if(current_slash==0 && attack_buffer){
            player.sp_anim.Play("groundslash2");
            current_slash++;
            attack_buffer = false;
            return;
        }
        stateMachine.ChangeState(player.IdleState);
    }
}
