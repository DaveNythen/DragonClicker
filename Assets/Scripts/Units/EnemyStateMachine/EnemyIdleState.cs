
public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        //Play Animation or not
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (enemy.IsSpawned)
            enemy.SwitchState(enemy.MovingState);
    }
}
