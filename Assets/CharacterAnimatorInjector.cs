using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorInjector : MonoBehaviour
{
    [SerializeField] Transform _root;
    [SerializeField] Animator _animator;

    [Header("Dependencies")]
    [SerializeField] Movement _movement;
    [SerializeField] Attack _attack;
    [SerializeField] Health _health;

    [Header("Parameters")]
    [SerializeField] string _attackTrigger;
    [SerializeField] string _damageTrigger;
    [SerializeField] string _isWalkingBool;
    [SerializeField] string _isDeadBool;

    private void Start()
    {
        _attack.OnAttack += AttackEvent;
        _health.OnDamage += DamageEvent;
    }

    private void OnDestroy()
    {
        _attack.OnAttack -= AttackEvent;
        _health.OnDamage -= DamageEvent;
    }

    void AttackEvent() => _animator.SetTrigger(_attackTrigger);
    void DamageEvent() => _animator.SetTrigger(_damageTrigger);

    void LateUpdate()
    {
        _animator.SetBool(_isWalkingBool, _movement.IsWalking);
        _animator.SetBool(_isDeadBool, _health.IsDead);
    }

    #region EDITOR
#if UNITY_EDITOR
    private void Reset()
    {
        // Setup basic root
        _root = transform.parent;
        _animator = GetComponent<Animator>();

        // Try find components
        _movement = _root.GetComponentInChildren<Movement>();
        _attack = _root.GetComponentInChildren<Attack>();
        _health = _root.GetComponentInChildren<Health>();

        // Reset params
        _attackTrigger = "OnAttack";
        _damageTrigger = "OnDamage";
        _isWalkingBool = "IsWalking";
        _isDeadBool = "IsDead";
    }
#endif
    #endregion

}
