using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

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

    private GameObject _player; // �����

    #region Score
    [Space(10)]
    [Header("Score")]
    #endregion
    public TextMeshProUGUI scoreTMPUI;
    private int _gameScore = 0;


    protected override void Awake()
    {

        base.Awake();

        // ������������ ������ � ��������� ������
        InitPlayer();


    }
    
    /// <summary>
    /// ������������� ������
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
    /// ������ �� GO ������
    /// </summary>
    public GameObject GetPlayer()
    {
        return _player;
    }


    /// <summary>
    /// ��������� UI ��� Score, �� ���� �������������� =)
    /// </summary>
    public void UpdateUiScore(int amount) {

        _gameScore += amount;
        scoreTMPUI.text = Settings.scoreText + _gameScore.ToString();
    }

}
