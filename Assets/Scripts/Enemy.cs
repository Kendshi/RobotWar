using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> EnemyDeath;
}
