using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyStateManager>().Hit();
        }
    }
}
