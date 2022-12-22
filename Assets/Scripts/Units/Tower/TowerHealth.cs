using System;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] float health;

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
            GameManager.Instance.UpdateGameState(GameState.GameOver);
    }
}
