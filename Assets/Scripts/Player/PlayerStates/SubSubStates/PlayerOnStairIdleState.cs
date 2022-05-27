using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnStairIdleState : PlayerOnStairState
{
public PlayerOnStairIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
    public override void LogicUpdate(){
        base.LogicUpdate();
        
    }
}
