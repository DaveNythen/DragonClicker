using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class EnemyStats : MonoBehaviour
{
    [HideInInspector] public bool isAlive;
    [SerializeField] SphereCollider col;
    public float speed;

    public void Hit()
    {
        isAlive = false;
        col.enabled = false;
    }

    public void Reset()
    {
        isAlive = true;
        col.enabled = true;
    }
}
