using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Gère les inputs du joueurs et qui redistribue les valeurs des inputs aux composants correspondant
/// </summary>
public class PlayerBrain : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _sprintInput;
    [SerializeField] InputActionReference _attackInput;

    [Header("Actions")]
    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityAttack _attack;

    void Start()
    {
        // Movement
        _moveInput.action.started += Move;
        _moveInput.action.performed += Move;
        _moveInput.action.canceled += StopMove;
        // Attack
        _attackInput.action.started += Attack;
        // Sprint
        _sprintInput.action.started += StartSprint;
        _sprintInput.action.canceled += StopSprint;
    }


    void StartSprint(InputAction.CallbackContext obj)
    {
        _movement.SetRunning(true);
    }
    void StopSprint(InputAction.CallbackContext obj)
    {
        _movement.SetRunning(false);
    }

    void Attack(InputAction.CallbackContext obj)
    {
        _attack.LaunchAttack();
    }

    void Move(InputAction.CallbackContext obj)
    {
        _movement.SetDirection(obj.ReadValue<Vector2>());
    }

    void StopMove(InputAction.CallbackContext obj)
    {
        _movement.SetDirection(Vector2.zero);
    }
}
