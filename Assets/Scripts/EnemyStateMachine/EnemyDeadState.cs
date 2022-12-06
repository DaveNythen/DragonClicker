using UnityEngine;
using DG.Tweening;

public class EnemyDeadState : EnemyBaseState
{
    float _animationTime;

    public override void EnterState(EnemyStateManager enemy)
    {
        _animationTime = 1f;
        enemy.animator.SetBool("isAlive", false);
        enemy.agent.speed = 0;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (_animationTime > 0)
            _animationTime -= Time.deltaTime;
        else
            enemy.transform.DOMoveY(-0.5f, 0.5f).OnComplete(() =>
            {
                EnemyPool.ReturnToPoolPos(enemy.transform);
            });
    }
}
