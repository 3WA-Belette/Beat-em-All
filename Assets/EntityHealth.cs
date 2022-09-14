using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    // Nos champs
    [SerializeField] int _maxHealth;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _root;

    [SerializeField] UnityEvent _onDamage;
    [SerializeField] UnityEvent _onDie;

    int _currentHealth;

    // Propriété pour rendre les informations disponibles aux autres composants
    public int CurrentHealth
    {
        get { return _currentHealth; }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
    }

    /// <summary>
    /// Initialisation au lancement du jeu
    /// </summary>
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    /// <summary>
    /// On inflige des dommages
    /// </summary>
    /// <param name="amount">NB de point de vie à enlever</param>
    public void Damage(int amount)
    {
        // Guards
        if (amount < 0)
        {
            Debug.LogWarning("Olala on m'a donné des mauvais paramètres");
            return;
        }

        _currentHealth -= amount;

        // Securité MAX Health
        _currentHealth = Mathf.Max(_currentHealth, 0);  // ex : -10 , 0

        _onDamage.Invoke();
        _animator.SetTrigger("Hurt");

        if (_currentHealth <= 0)
        {
            _onDie.Invoke();
            _animator.SetBool("IsDead", true);
            StartCoroutine(WaitBeforeDestroy());
        }

        Debug.Log($"DAMAGE, {_currentHealth}");
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(_root);
    }

    bool _isCooldown;
    IEnumerator Cooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(2f);
        _isCooldown = false;
    }


    /// <summary>
    /// On gagne de la vie
    /// </summary>
    /// <param name="amount">NB de point de vie à regen</param>
    public void Regen(int amount)
    {
        // Guards
        if (amount < 0)
        {
            Debug.LogWarning("Olala on m'a donné des mauvais paramètres");
            return;
        }

        // Calcul de la regen
        _currentHealth += amount;

        // Securité MAX Health
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);  // ex : 55 , 20
        
        Debug.Log($"Regen, {_currentHealth}");
    }

    #region EDITOR
#if UNITY_EDITOR
    private void Reset()
    {
        _maxHealth = 20;
    }
#endif
    #endregion

}
