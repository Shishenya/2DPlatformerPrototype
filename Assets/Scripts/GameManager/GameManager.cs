using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;

    private void Start()
    {
        GameObject enemy = _enemyFactory.Create();
    }
}
