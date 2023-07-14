using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public DynamicJoystick variableJoystick;
    public LayerMask layerGround;
    public Rigidbody rb;

    Animator animator;

    string currentAnim = "idle";
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        variableJoystick = FindObjectOfType<DynamicJoystick>();
        

        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Move();
            ChangeAnimation("run");

        }
        else
        {
            rb.velocity = Vector3.zero;
            ChangeAnimation("idle");
        }
    }

    void Move()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        transform.localRotation = Quaternion.LookRotation(direction * 5f);
    }

    public void ChangeAnimation(string newAnim)
    {
        if (currentAnim != newAnim)
        {
            animator.ResetTrigger(newAnim);
            currentAnim = newAnim;
            animator.SetTrigger(currentAnim);
        }
    }
}
