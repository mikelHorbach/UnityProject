using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabit : MonoBehaviour {

    public static HeroRabit lastRabit = null;
    public bool IsBig_rabbit;
    public float speed = 1;
    bool isGrounded = false;
    bool JumpActive = false;
    bool isDeath = false;
    float JumpTime = 0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
    Vector3 start;

    Rigidbody2D myBody = null;



    void Awake()
    {
        lastRabit = this;
    }


    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
        LevelController.current.setStartPosition(transform.position);
        start = transform.position;
    }
	
	
    // Update is called once per frame
    void FixedUpdate()
    {
        //[-1, 1]
        float value = Input.GetAxis("Horizontal");

        Animator animator = GetComponent<Animator>();

        if (animator.GetBool("death"))
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Rabit_Die") || animator.GetCurrentAnimatorStateInfo(0).normalizedTime < animator.GetCurrentAnimatorStateInfo(0).length+1)
            {
                return;
            }
            IsBig_rabbit = false;
            animator.SetBool("death", false);
            transform.position = start;

        }

        if (Mathf.Abs(value) > 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }


        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }
        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //Намалювати лінію (для розробника)
        Debug.DrawLine(from, to, Color.red);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
            //Якщо кнопку ще тримають
            if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }

        if (this.isGrounded)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }

     
    }

    public void  doBig()
    {
        if(IsBig_rabbit)
        {
            return;
        }
        IsBig_rabbit = true;
        transform.localScale *= 2;
    }

    public void   doSmall()
    {
        if (!IsBig_rabbit)
        {
            revive();
        }
        else
        {
            transform.localScale /= 2;
            IsBig_rabbit = false;
        }

        
    }

    public void death()
    {
        if (isGrounded)
        {
            var animator = GetComponent<Animator>();
            animator.SetBool("death", true);
            
        }
        else transform.position = start;

        IsBig_rabbit = false;
    }

    public void revive()
    {
       // isDeath = true;
        death();
        // transform.position = start;
    }
}
