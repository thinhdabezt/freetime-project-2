using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public float groundDistance = 0.1f;
    public ContactFilter2D contactFilter;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    CapsuleCollider2D touchingCol;
    Animator animator;

    private bool _isGrounded = true;
    public bool IsGrounded 
    { 
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded=value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    private bool _isOnWall = true;
    public bool IsOnWall
    {
        get
        {
            return IsOnWall;
        }
        private set
        {
            IsOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    private bool _isOnCeiling = true;
    public bool IsOnCeiling
    {
        get
        {
            return IsOnCeiling;
        }
        private set
        {
            IsOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, contactFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(Vector2.down, contactFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, contactFilter, ceilingHits, ceilingDistance) > 0;
    }
}
