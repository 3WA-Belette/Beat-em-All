using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] List<EntityHealth> health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EntityHealth>(out var h))
        {
            health.Add(h);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EntityHealth>(out var h))
        {
            health.Remove(h);
        }
    }

    internal void LaunchAttack()
    {
        foreach(EntityHealth h in health)
        {
            h.Damage(5);
        }
    }
}
