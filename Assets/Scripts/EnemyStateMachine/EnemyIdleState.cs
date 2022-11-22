using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public bool isSpawned; //Called from EnemySpawn

    public override void EnterState(EnemyStateManager enemy)
    {
        //Play Animation or not
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (isSpawned)
            enemy.SwitchState(enemy.MovingState);
    }
}
