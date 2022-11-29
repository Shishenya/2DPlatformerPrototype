using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(JumpEvent))]
[DisallowMultipleComponent]
public class Jump : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private JumpEvent _jumpEvent;
    private Creatures _creature;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpEvent = GetComponent<JumpEvent>();
        _creature = GetComponent<Creatures>();
    }

    private void OnEnable()
    {
        _jumpEvent.OnJump += JumpEvent_OnJump;
    }

    private void OnDisable()
    {
        _jumpEvent.OnJump -= JumpEvent_OnJump;
    }

    private void JumpEvent_OnJump(JumpEventArgs jumpEventArgs)
    {
        JumpRigidBody(jumpEventArgs.jumpForce, jumpEventArgs.direction, jumpEventArgs.speed);
    }

    private void JumpRigidBody(float jumpForce, Vector2 direction, float speed)
    {
        float modificator = 2f;
        _rigidbody2D.velocity = new Vector2(direction.x * speed / modificator, jumpForce);
        _creature.isJump = true;
        _creature.isGround = false;
    }

}
