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

    #region Cinemachine
    [Space(10)]
    [Header("Cinemachine Reff")]
    #endregion
    [SerializeField] private CinemachineVirtualCamera _cinemachine;

    private GameObject _player; // игрок


    protected override void Awake()
    {

        base.Awake();
        GameObject _player = _playerFactory.Create(Settings.startPositionPlayer);
        // _player.SetActive(true);
        _cinemachine.Follow = _player.transform;

    }

    private void Start()
    {
    }

    /// <summary>
    /// —сылка на GO игрока
    /// </summary>
    public GameObject GetPlayer()
    {
        return _player;
    }

}
