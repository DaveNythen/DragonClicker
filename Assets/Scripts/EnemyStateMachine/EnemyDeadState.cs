using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    float _animationTime = 0.5f;

    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.animator.SetBool("isAlive", false);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (_animationTime > 0)
            _animationTime -= Time.deltaTime;
        else
            EnemyPool.ReturnToPoolPos(enemy.transform);
    }
}
