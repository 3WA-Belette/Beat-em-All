using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [Header("Conf")]
    [SerializeField] Transform _root;
    [SerializeField] Transform _targetedPlayer;

    [Header("Actions")]
    [SerializeField] Movement _movement;
    [SerializeField] Attack _attack;





    #region Editor
#if UNITY_EDITOR
    private void Reset()
    {
        _root = transform.parent;
        _movement = _root.GetComponentInChildren<Movement>();
        _attack = _root.GetComponentInChildren<Attack>();
    }
#endif
    #endregion

}
