using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb_Player;
    private Animator animator;
    private AudioSource thisAudioSource;

    [HideInInspector]
    public int jumpAmmout;

    [Header("Healthbar")]
    public Image healthBar;
    public Image fuelBar;

    [Header("Shooting")]
    public float cooldown;
    public GameObject bullet;

    [Header("Stats")]
    public float health = 100;
    public float jumpPower = 5f;
    public float speed = 2f;

    private bool isFalling = false;
    private bool isJumping = false;
    private bool canShoot = true;
	private bool falling = false;
    private Vector2 offset;
    private bool lookingLeft;


    void Start()
    {
        rb_Player = this.GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        thisAudioSource = this.gameObject.GetComponent<AudioSource>();
        offset = new Vector2(-2f, 0.1f);
    }

    void FixedUpdate()
    {
        // Move Character
        if (Input.GetKey(KeyCode.A))
        {
            float horizontal = Input.GetAxis("Horizontal");
            offset = new Vector2(-2.3f, 0.1f);
            lookingLeft = true;
            HandleMovement(horizontal);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float horizontal = Input.GetAxis("Horizontal");
            offset = new Vector2(-2f, 0.1f);
            lookingLeft = false;
            HandleMovement(horizontal);
        }

        //Jump
        if (Input.GetButtonDown("Submit") && jumpAmmout > 0 && !isJumping)
        {
            StartCoroutine(Jump());
        }

        //Fire
        if (Input.GetMouseButton(0) && canShoot)
        {
            animator.SetBool("fire", true);
            GameObject go = Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            go.GetComponent<ElectroBullet>().SetDirection(lookingLeft ? ElectroBullet.Direction.LEFT : ElectroBullet.Direction.RIGHT);
            StartCoroutine(CanShoot());
        }

        //Animate
        if (Input.GetKey(KeyCode.A))
        { this.GetComponentInChildren<SpriteRenderer>().flipX = true; animator.SetBool("isWalking", true); }
        else if (Input.GetKey(KeyCode.D))
        { this.GetComponentInChildren<SpriteRenderer>().flipX = false; animator.SetBool("isWalking", true); }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        { animator.SetBool("isWalking", false); }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("isCrouching", true);
            
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("isCrouching", false);
            
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.C))
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
            animator.SetBool("isCwalking", true);
        }
        else if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.C))
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = false;
            animator.SetBool("isCwalking", true);
        }

        if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.C))
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
            animator.SetBool("isCwalking", false);
        }
        else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.C))
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = false;
            animator.SetBool("isCwalking", false);
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		if (coll.transform.tag == "Ground") {
			if (isJumping) {
				StopAllCoroutines ();
				falling = false;
				isJumping = false;
			}
            
			animator.SetBool ("grounded", true);
			jumpAmmout = 2;
		} 
		else if (coll.transform.tag != "Ground") 
		{
			animator.SetBool ("isFalling", falling);
			falling = true;
		}
    }

    private void HandleMovement(float horizontal)
    {
        Vector2 v = rb_Player.velocity;
        v.x = horizontal * speed;
        rb_Player.velocity = v;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        float filler = health / 100;
        healthBar.fillAmount = filler;
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        animator.SetBool("fire", false);
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    IEnumerator Jump()
    {
        isJumping = true;

        rb_Player.AddForce(Vector2.up * jumpPower * 100);

        jumpAmmout--;
        animator.SetBool("grounded", false);
        yield return new WaitForSeconds(0.10f);
        isJumping = false;
    }


}
