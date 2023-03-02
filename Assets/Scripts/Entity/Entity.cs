using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Entity : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected GameObject _bombPrefab;
    [Header("Stats")]
    private float _fuseTimer;
    private bool _ricochetBomb;
    private float _moveSpeed;
    private bool _doubleBomb;
    private int _maxHealth;
    private int _currentHealth;
    private int _damage;

    public float FuseTimer { get { return _fuseTimer; } set { _fuseTimer = value > 0 ? value : 0.5f; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public bool DoubleBomb { get { return _doubleBomb; } set { _doubleBomb = value; } }
    public bool RicochetBomb { get { return _ricochetBomb; } set { _ricochetBomb = value; } }
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value > 0 ? value : 100; } }
    public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = _currentHealth <= _maxHealth ? value : _maxHealth; } }
    public int Damage { get { return _damage; } set { _damage = value; } }
    public bool CanRicochet { get; set; }
    public int MaxRicochets { get; set; }

    protected virtual void DropBomb()
    {
        return;
    }
    protected virtual void Move()
    {
        return;
    }

}
