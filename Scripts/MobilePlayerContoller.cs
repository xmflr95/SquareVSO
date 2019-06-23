using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePlayerContoller : MonoBehaviour
{

    public float speed;
    public int health = 3;
    public int numOfHearts = 3;
    private int healHealth = 1;
    bool isHeal = false;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private float moveInput;
    public GameObject particle;
    public GameObject effect;
    public ScoreManager scm;
    new SpriteRenderer renderer;

    public AudioClip hitSound1;
    public AudioClip hitSound2;
    public AudioClip hitSound3;
    public AudioClip heal1;
    public AudioClip heal2;
    public AudioClip gameOverSound;

    public GameManager gm;

    //public GameObject player;
    //private float screenWidth;

    bool isUnBeatTime = false;
    bool isDie = false;

    private Rigidbody2D rb;
    private Animator animator;
    private ParticleSystem ps;

    private bool facingRight = true;//방향

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ps = GetComponentInChildren<ParticleSystem>();
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        //GameManager gm = gameObject.GetComponent<GameManager>();
        //ScoreManager scm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {   //right
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
                {//right
                    //Debug.Log("Right");
                    transform.Translate(Vector3.right * speed * Time.smoothDeltaTime);
                    //rb.velocity = transform.right * speed * Time.fixedDeltaTime;
                    moveInput = Input.GetAxisRaw("Horizontal");
                    if (facingRight == false)
                    {
                        animator.SetBool("isMoving", true);
                        Flip();
                        ps.Play();
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {//stop
                    animator.SetBool("isMoving", false);
                    ps.Stop();
                    ps.Clear();
                }

            }
            //left
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
                {   //left
                    //Debug.Log("left");
                    transform.Translate(Vector3.left * speed * Time.smoothDeltaTime);
                    //rb.velocity = -(transform.right) * speed * Time.fixedDeltaTime;
                    moveInput = Input.GetAxisRaw("Horizontal");
                    if (facingRight == true)
                    {
                        animator.SetBool("isMoving", true);
                        Flip();
                        ps.Play();
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {//stop
                    animator.SetBool("isMoving", false);
                    ps.Stop();
                    ps.Clear();
                }
            }
        }
        else if (Input.touchCount == 0 || (!(Input.GetTouch(0).position.x >= Screen.width / 2) && !(Input.GetTouch(0).position.x <= Screen.width / 2)))
        {
            animator.SetBool("isMoving", false);
            ps.Stop();
            ps.Clear();
        }

        /*if (Input.touchCount == 1)
        {   //right
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
                {//right
                    //Debug.Log("Right");
                    rb.velocity = Vector2.right * speed * Time.deltaTime;
                    //rb.velocity = transform.right * speed * Time.fixedDeltaTime;
                    moveInput = Input.GetAxisRaw("Horizontal");
                    if (facingRight == false)
                    {
                        animator.SetBool("isMoving", true);
                        Flip();
                        ps.Play();
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {//stop
                    animator.SetBool("isMoving", false);
                    ps.Stop();
                    ps.Clear();
                }

            }
            //left
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
                {   //left
                    //Debug.Log("left");
                    rb.velocity = (-Vector2.right) * speed * Time.deltaTime;
                    //rb.velocity = -(transform.right) * speed * Time.fixedDeltaTime;
                    moveInput = Input.GetAxisRaw("Horizontal");
                    if (facingRight == true)
                    {
                        animator.SetBool("isMoving", true);
                        Flip();
                        ps.Play();
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {//stop
                    animator.SetBool("isMoving", false);
                    ps.Stop();
                    ps.Clear();
                }
            }
    }
    else if (Input.touchCount == 0 || (!(Input.GetTouch(0).position.x >= Screen.width / 2) && !(Input.GetTouch(0).position.x <= Screen.width / 2)))
    {
        animator.SetBool("isMoving", false);
        ps.Stop();
        ps.Clear();
    }*/

        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

    void FixedUpdate()
    {
        //플레이어 카메라 안에 고정
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        //moveInput = Input.GetAxisRaw("Horizontal");//right moveInput = 1/ left = -1
        // rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //Move();
        //#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Move()
    {
        if (ps != null)
        {
            if (facingRight == false && moveInput > 0)
            {
                animator.SetBool("isMoving", true);
                Flip();
                ps.Play();
            }
            else if (facingRight == true && moveInput < 0)
            {
                animator.SetBool("isMoving", true);
                Flip();
                ps.Play();
            }
            else if (moveInput == 0)
            {
                animator.SetBool("isMoving", false);
                ps.Stop();
                ps.Clear();
            }
        }
    }

    void Heal()
    {
        if (!isHeal)
        {
            isHeal = true;
            if (health < 3 && health > 0)
            {
                health = health + healHealth;
            }

            scm.score = scm.score + 20;
        }

        isHeal = !isHeal;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //힐박스
        if (collision.gameObject.tag == "HealBox")
        {
            AudioManager.adm.RandomizeSfx(heal1, heal2);
            //랜덤 사운드
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0f);

            Heal();
        }

        //적충돌
        if (collision.gameObject.tag == "Enemy" && !isUnBeatTime)
        {
            AudioManager.adm.RandomizeSfx(hitSound1, hitSound2, hitSound3);
            collision.enabled = false;
            Destroy(collision.gameObject);

            animator.SetBool("isHit", true);
            //체력감소

            health--;

            //unbeatTime
            if (health > 0) //4개에서부터 줄어들때마다 무적 2초씩
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
            //죽었을때
            else if (health == 0)
            {
                Die();
            }
        }
    }

    //죽음
    void Die()
    {
        if (!isDie)
        {
            //Debug.Log("게임종료");
            AudioManager.adm.PlaySingle(gameOverSound);
            gm.GameOver();
        }

        isDie = !isDie;
    }

    //무적
    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                renderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                renderer.color = new Color32(255, 255, 255, 180);
            }

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        //alpha effect end
        renderer.color = new Color32(255, 255, 255, 255);
        //unbeatTime off
        isUnBeatTime = false;

        yield return null;
    }
}
