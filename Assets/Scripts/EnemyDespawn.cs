using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    public delegate void OnTowerReachedEvent();
    public static event OnTowerReachedEvent OnTowerReached;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyStateManager>().Hit();
            OnTowerReached?.Invoke();
        }
    }
}
