using UnityEngine;

public class Idle : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private IdleEvent _idleEvent;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _idleEvent = GetComponent<IdleEvent>();
    }

    private void OnEnable()
    {
        _idleEvent.OnIdle += IdleEvent_OnIdle;
    }

    private void OnDisable()
    {
        _idleEvent.OnIdle -= IdleEvent_OnIdle;
    }

    /// <summary>
    /// Ответ на событие  - состояние покоя
    /// </summary>
    private void IdleEvent_OnIdle()
    {
        Vector2 curentVelocity = _rigidBody2D.velocity;
        _rigidBody2D.velocity = new Vector2(0f, curentVelocity.y);
        // Debug.Log("VELOCITY Y = " + curentVelocity.y);
    }

}
