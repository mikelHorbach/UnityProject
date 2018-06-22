using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Orc : MonoBehaviour {

    public Vector3 MoveBy;
    public float walkSpeed = 0.5f;
    public float Timeout = 1f;
    public float speed;

    private Vector3 _pointA;
    private Vector3 _pointB;
    private float _timeToWait;
    

    protected Rigidbody2D myBody = null;
    protected Animator animator;

    public enum Mode
    {
        GoToA,
        GoToB,
        Attack,
        Death,
        Stay
    }
    public Mode mode = Mode.GoToA;

    protected abstract float attackDirection();
    protected abstract void checkAttack();
    protected abstract bool isDieAnimation();


    protected virtual void attack()
    {
    }

    // Use this for initialization
    protected void Start () {
        _pointA = transform.position;
        _pointB = transform.position + MoveBy;
        if(_pointA.x > _pointB.x)
        {
            Vector3 vec = _pointA;
            _pointA = _pointB;
            _pointB = vec;
        }
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _timeToWait = Timeout;
        speed = walkSpeed;  
    }

    // Update is called once per frame
    protected void FixedUpdate () {
        if (animator.GetBool("isDie"))
        {
            if (!isDieAnimation() || animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
                return;
            animator.SetBool("isDie", false);

            Destroy(this.gameObject);
            return;
        }

        checkAttack();
        float value = this.getDirection();

        if (mode == Mode.Stay)
        {
            myBody.velocity = new Vector2();
            animator.SetBool("isWalk", false);
            if (_timeToWait > 0)
            {
                _timeToWait -= Time.deltaTime;
                return;
            }
            else
            {
                if (Mathf.Abs(transform.position.x- _pointA.x) < Mathf.Abs(transform.position.x- _pointB.x)) mode = Mode.GoToB;
                else mode = Mode.GoToA;
                animator.SetBool("isWalk", true);
            }
        }

        if (Mathf.Abs(value) > 0)
        {
            animator.SetBool("isRun", mode == Mode.Attack);
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
                                                    
        }
        animator.SetBool("isRun", mode == Mode.Attack);
                                      
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)               
        {                 
            sr.flipX = false;
        }                
        else if (value > 0)
        {
            sr.flipX = true;
        }
    }

    private bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.05f;
    }
   
    
    public float getDirection()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
        if (rabit_pos.x > Mathf.Min(_pointA.x, _pointB.x) && rabit_pos.x < Mathf.Max(_pointA.x, _pointB.x))
        {
            mode = Mode.Attack;
        }
        else if (mode == Mode.Attack)
        {
            mode = Mode.GoToA;
            speed = walkSpeed;
        }
        if (mode == Mode.Attack)
        {
            return attackDirection();
        }
        if (mode == Mode.GoToB)
        {
            if (isArrived(my_pos, _pointB))
            {
                mode = Mode.Stay;
                _timeToWait = Timeout;
                animator.SetBool("isWalk", false);
            }
            else return 1;
        }

        else if (mode == Mode.GoToA)
        {
            if (isArrived(my_pos, _pointA))
            {
                mode = Mode.Stay;
                _timeToWait = Timeout;
                animator.SetBool("isWalk", false);
            }
            else return -1;
        }

        return 0;
    }



    public void destroy()
    {
        Destroy(this.gameObject);
    }

    

}
