using System;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] float health;

    public delegate void OnGameOverEvent();
    public static event OnGameOverEvent OnGameOver;

    private void OnEnable()
    {
        EnemyDespawn.OnTowerReached += OnDamage;
    }

    private void OnDisable()
    {
        EnemyDespawn.OnTowerReached -= OnDamage;
    }

    private void OnDamage()
    {
        health--;

        if (health <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
}
