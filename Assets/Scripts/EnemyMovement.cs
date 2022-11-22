using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Transform tower;

    private void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
    }

    private void Update()
    {
        transform.LookAt(tower);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
