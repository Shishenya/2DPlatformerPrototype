using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private EnemyCreature _creatures;
    private float _speed = 5f;
    private float _jumpForce;
    public AimDirection _currentAimDirection;


    #region Timer
    private float _changeAimStart;
    private float _changeAimTimer;
    #endregion

    private void Awake()
    {
        _creatures = GetComponent<EnemyCreature>();
        _speed = _creatures.movementDetails.speed;
        _jumpForce = _creatures.movementDetails.jumpForce;

        _changeAimStart = _creatures.enemyDetailsSO.changeMove;
        _changeAimTimer = _changeAimStart;
        _currentAimDirection = AimDirection.left;

    }

    private void Update()
    {
        MoveEnemy();

        TimerMoveChange();

    }

    /// <summary>
    /// Движение противника
    /// </summary>
    private void MoveEnemy()
    {
        _creatures.moveEvent.CallOnMoveEvent(_currentAimDirection, _speed);
    }

    private void TimerMoveChange()
    {
        _changeAimTimer -= Time.deltaTime;
        if (_changeAimTimer<0)
        {
            _changeAimTimer = _changeAimStart;

            if (_currentAimDirection == AimDirection.left)
            {
                _currentAimDirection = AimDirection.right;
                return;
            }

            if (_currentAimDirection == AimDirection.right)
            {
                _currentAimDirection = AimDirection.left;
                return;
            }
        }

    }

}
