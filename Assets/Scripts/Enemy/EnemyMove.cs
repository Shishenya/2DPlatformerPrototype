using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private Creatures _creatures;
    private float _speed = 5f;
    private float _jumpForce;

    private void Awake()
    {
        _creatures = GetComponent<Creatures>();
        _speed = _creatures.movementDetails.speed;
        _jumpForce = _creatures.movementDetails.jumpForce;
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        AimDirection aimDirection = AimDirection.left;
        _creatures.moveEvent.CallOnMoveEvent(aimDirection, _speed);
    }

}
