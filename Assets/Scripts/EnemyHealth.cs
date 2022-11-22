using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isAlive;

    public void Hit()
    {
        if (isAlive)
        {
            isAlive = false;
            //play sound, animation....
            EnemyPool.ReturnToPoolPos(transform);
        }
    }

    public void Reset()
    {
        isAlive = true;
    }
}
