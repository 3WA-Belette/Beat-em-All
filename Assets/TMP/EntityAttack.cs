using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] HitBox _hitBox;

    public void LaunchAttack()
    {
        Debug.Log($"{transform.parent.name} : OH MY GOD");

        _animator.SetTrigger("Attack");

        // Method Raycast
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right), Color.yellow, 1f);

        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector2.right));
        RaycastHit[] hits = Physics.RaycastAll(ray, 2f, LayerMask.GetMask("Attackable"));
        foreach(RaycastHit h in hits)
        {
            if(h.collider.TryGetComponent<EntityHealth>(out var health))
            {
                health.Damage(5);
            }
        }


        // Method Hitbox
        //_hitBox.LaunchAttack();

    }


}
