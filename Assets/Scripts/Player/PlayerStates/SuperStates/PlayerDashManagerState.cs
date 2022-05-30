using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashManagerState : PlayerAbilityState
{
    
    public bool can_dash=true;
    public Status_Modifier Dash_Mod;
    public PlayerUpwardsDashState UpDashState{get;private set;}
    public PlayerDashState DashState{get;private set;}
    public PlayerDashManagerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        UpDashState = new PlayerUpwardsDashState(player, stateMachine, playerData, "updash");
        
        DashState = new PlayerDashState(player, stateMachine, playerData, "dash");
        DashState.state_manager = this;
    }
    
    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        can_dash = false;
        player.ghost_fx.renderOnMotion = true;
        if(player.Input.GetDirInput().y>0){
            Debug.Log("Teste");
            stateMachine.ChangeState(UpDashState);
        }else{
            stateMachine.ChangeState(DashState);
        }
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
