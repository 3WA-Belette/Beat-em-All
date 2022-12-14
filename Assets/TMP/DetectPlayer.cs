using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] AIBrain _brain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.TryGetComponent<PlayerTag>(out var player))
        {
            _brain.SetTarget(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent<PlayerTag>(out var player))
        {
            _brain.ClearTarget();
        }
    }


}
