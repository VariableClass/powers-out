using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //new public Rigidbody2D rigidbody;
    public LayerMask groundLayers;
    public float moveSpeed;
    public float jumpPower;
    public float targetMoveSpeed;
    public bool movingBackwards = false;
    public AnimationClip runAnimation;
    public AnimationClip jumpAnimation;

    bool grounded;

    void Start()
    {
    }

    void Update()
    {
        // Get renderer & animator
        var renderer = gameObject.GetComponent<SpriteRenderer>();
        var animator = gameObject.GetComponent<Animator>();
        var animation = gameObject.GetComponent<Animation>();
        var collider = gameObject.GetComponent<BoxCollider2D>();

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            ChangeAnimation(animator, jumpAnimation);
            animator.StopPlayback();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeAnimation(animator, runAnimation);
            animator.StopPlayback();
            movingBackwards = true;
            renderer.flipX = movingBackwards;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ChangeAnimation(animator, runAnimation);
            animator.StopPlayback();
            movingBackwards = false;
            renderer.flipX = movingBackwards;

        }
        else
        {
            animator.StartPlayback();
        }


    }

    private void ChangeAnimation(Animator animator, AnimationClip animationClip)
    {
        var aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
        var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        foreach (var a in aoc.animationClips)
        {
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, animationClip));
        }
        aoc.ApplyOverrides(anims);
        animator.runtimeAnimatorController = aoc;
    }

    void FixedUpdate()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody2D>();

        // Gets movement speed and applies it
        targetMoveSpeed = Mathf.Lerp(rigidbody.velocity.x, Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, Time.deltaTime * 10);

        // Jumps if not grounded
        if(grounded && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 1f * jumpPower);
            return;
        }

        rigidbody.velocity = new Vector2(targetMoveSpeed, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ground", System.StringComparison.OrdinalIgnoreCase))
        {
            var animator = gameObject.GetComponent<Animator>();
            ChangeAnimation(animator, runAnimation);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ground", System.StringComparison.OrdinalIgnoreCase))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ground", System.StringComparison.OrdinalIgnoreCase))
        {
            grounded = false;
        }
    }
}
