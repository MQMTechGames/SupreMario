using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    PlayerMover _mover;
    CollisionCheck _floorCollider;

    bool _doubleJumped = false;

    Timer _doubleJumpTimer = new Timer();

    public enum State
    {
        Grounded,
        Jumping
    }

    void Awake()
    {
        _mover = GetComponentInChildren<PlayerMover>();
        _floorCollider = GetComponentInChildren<CollisionCheck>();
    }

    public bool IsFalling()
    {
        return _mover.IsFalling();
    }

    public void OnHit()
    {
        Debug.Log("Player: Im Hit :(");
    }

    void FixedUpdate()
    {
        CheckDoubleJumping();

        UpdateMovement();

        CheckHierarchy();
    }

    void CheckHierarchy()
    {
        if (_floorCollider.IsTouching && _floorCollider.Touched.CompareTag("ground"))
        {
            transform.parent = _floorCollider.Touched.transform;
        } else
        {
            transform.parent = null;
        }
    }

    void CheckDoubleJumping()
    {
        if (_floorCollider.IsTouching)
        {
            _doubleJumped = false;
        }
    }
    
    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(_floorCollider.IsTouching)
            {
                _doubleJumpTimer.Wait(0.25f);
                _mover.Jump();
            }
            else
            {
                if(!_doubleJumped && _doubleJumpTimer.IsFinished())
                {
                    _mover.Jump();
                    _doubleJumped = true;
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _mover.Move(-1f);
        } 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _mover.Move(1f);
        }
    }
}
