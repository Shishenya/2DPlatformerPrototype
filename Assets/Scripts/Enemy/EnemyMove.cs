using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private EnemyCreature _creature;
    private float _speed = 5f;
    private float _jumpForce;
    public AimDirection _currentAimDirection;


    #region Timer
    private float _changeAimStart;
    private float _changeAimTimer;
    #endregion

    private void Awake()
    {
        _creature = GetComponent<EnemyCreature>();
        _speed = _creature.movementDetails.speed;
        _jumpForce = _creature.movementDetails.jumpForce;

        _changeAimStart = _creature.enemyDetailsSO.changeMove;
        _changeAimTimer = _changeAimStart;
        _currentAimDirection = AimDirection.left;

    }

    private void Update()
    {

        if (_creature.isDeath)
        {
            _creature.rigidbody2D.velocity = Vector2.zero;
            return;
        }

        MoveEnemy();

        TimerMoveChange();

    }

    /// <summary>
    /// Движение противника
    /// </summary>
    private void MoveEnemy()
    {
        if (_creature.isAttack) return;
        _creature.moveEvent.CallOnMoveEvent(_currentAimDirection, _speed);
    }

    private void TimerMoveChange()
    {
        _changeAimTimer -= Time.deltaTime;
        if (_changeAimTimer < 0)
        {
            _changeAimTimer = _changeAimStart;

            // если нет указания следовать всегда за игроком, то меняем направление
            if (!_creature.enemyDetailsSO.isAlwaysFollowPlayer)
            {

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
            // иначе всегда следуем за игроком
            else
            {
                _currentAimDirection = Utilites.LookAtPlayer(transform);
            }
        }

    }

}
