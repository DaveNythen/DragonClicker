using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    float animationTime = 0.1f;

    public override void EnterState(EnemyStateManager enemy)
    {
        //Play Animation
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (animationTime > 0)
            animationTime -= Time.deltaTime;
        else
            EnemyPool.ReturnToPoolPos(enemy.transform);
    }
}
