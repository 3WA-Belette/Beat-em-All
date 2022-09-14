using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EntityHealth : MonoBehaviour
{
    // Nos champs
    [SerializeField] int _maxHealth;
    int _currentHealth;

    // Propri�t� pour rendre les informations disponibles aux autres composants
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
    /// <param name="amount">NB de point de vie � enlever</param>
    public void Damage(int amount)
    {
        // Guards
        if (amount < 0)
        {
            Debug.LogWarning("Olala on m'a donn� des mauvais param�tres");
            return;
        }

        _currentHealth -= amount;

        // Securit� MAX Health
        _currentHealth = Mathf.Max(_currentHealth, 0);  // ex : -10 , 0

        Debug.Log($"DAMAGE, {_currentHealth}");
    }

    /// <summary>
    /// On gagne de la vie
    /// </summary>
    /// <param name="amount">NB de point de vie � regen</param>
    public void Regen(int amount)
    {
        // Guards
        if (amount < 0)
        {
            Debug.LogWarning("Olala on m'a donn� des mauvais param�tres");
            return;
        }

        // Calcul de la regen
        _currentHealth += amount;

        // Securit� MAX Health
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);  // ex : 55 , 20
        
        Debug.Log($"Regen, {_currentHealth}");
    }

}
