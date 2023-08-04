using System;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    [SerializeField] int _enemyDamage = 10;
    [SerializeField] int _playerHp = 10;
    public int EnemyDamage => _enemyDamage;
    public int PlayerHp => _playerHp;
    void Start()
    {
        print(damage(PlayerHp, EnemyDamage));
    }

    Func<int, int, int> damage = (playerHp, enemyDamage) => playerHp - enemyDamage;
}
