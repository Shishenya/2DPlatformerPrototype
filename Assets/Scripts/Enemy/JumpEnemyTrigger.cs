using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyTrigger : MonoBehaviour
{
    [Range(0f,100f)]
    [SerializeField] private float _chanceJump = 35f;
    private float _durationJump = 2.5f;
    private float _timerDurationJump;
    private float _jumpForceVertical = 3f;


    private void Awake()
    {
        _timerDurationJump = -1;
    }

    private void Update()
    {
        _timerDurationJump -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_timerDurationJump > 0) return;

        if (collision.gameObject.GetComponent<EnemyCreature>() != null)
        {
            float rnd = Random.Range(0f, 100f);
            if (rnd < _chanceJump)
            {
                Debug.Log("Прыжок врага!");
                EnemyCreature enemyCreature = collision.gameObject.GetComponent<EnemyCreature>();
                enemyCreature.jumpEvent.CallOnJumpEvent(enemyCreature.movementDetails.jumpForce, Vector2.zero, _jumpForceVertical);
            }
            SetStartTimer();
        }
    }

    private void SetStartTimer()
    {
        _timerDurationJump = _durationJump;
    }
}
