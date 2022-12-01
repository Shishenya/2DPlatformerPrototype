using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{

    #region Factory
    [Space(10)]
    [Header("Factore Reff")]
    #endregion
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private PlayerFactory _playerFactory;

    public EnemyFactory enemyFactory { get => _enemyFactory;}

    #region Cinemachine
    [Space(10)]
    [Header("Cinemachine Reff")]
    #endregion
    [SerializeField] private CinemachineVirtualCamera _cinemachine;

    private GameObject _player; // игрок


    protected override void Awake()
    {

        base.Awake();

        // Инициализция игрока и установка камеры
        InitPlayer();


    }
    
    /// <summary>
    /// Инициализация игрока
    /// </summary>
    private void InitPlayer()
    {
        _player = _playerFactory.Create(Settings.startPositionPlayer);
        _cinemachine.Follow = _player.transform;
    }

    private void Update()
    {
        TestUpdateSpawnEnemy();
    }

    private void TestUpdateSpawnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Vector2 testSpawn = _player.transform.position + new Vector3(-2f, _player.transform.position.y, 0f);
            GameObject enemy = _enemyFactory.Create(testSpawn);
        }
    }

    /// <summary>
    /// Ссылка на GO игрока
    /// </summary>
    public GameObject GetPlayer()
    {
        return _player;
    }

}
