﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb_Player;
    private Animator animator;
	private SpriteRenderer sprite;
    private AudioSource thisAudioSource;
	private LayerMask groundLayer;
	private PointSystem pSystem;

	[SerializeField]private Transform ground;
	[SerializeField]private Transform spawnPoint;
	[SerializeField]private Transform handle;

    [Header("Healthbar")]
    public Image healthBar;
    public Image fuelBar;

    [Header("Shooting")]
    public float cooldown;
    public GameObject bullet;
	public GameObject grenade;

    [Header("Stats")]
    public float health = 100;
    public float jumpPower = 5f;
    public float speed = 2f;

    private bool canShoot = true;
	private bool canThrow = true;
	private bool falling = false;
    private Vector2 offset;
    private bool lookingLeft;


    void Start()
    {
        rb_Player = this.GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        thisAudioSource = this.gameObject.GetComponent<AudioSource>();
        offset = new Vector2(-2f, 0.1f);
		sprite = this.GetComponentInChildren<SpriteRenderer>();
		groundLayer = LayerMask.GetMask ("Ground");
		pSystem = GetComponent<PointSystem> ();
    }

    void FixedUpdate()
    {
        // Move Character
        float input = Input.GetAxis("Horizontal");
        HandleMovement(input);

		if (input != 0) {
			lookingLeft = (input < 0);
			offset = lookingLeft? new Vector2 (-2.3f, 0.1f):offset = new Vector2 (-2f, 0.1f);;
		}
			
        //Jump
		if (Input.GetButtonDown("Jump") && !falling)
        {
			Jump ();
        }

		//Fire
		if ((Input.GetKeyDown (KeyCode.Backslash) || Input.GetMouseButtonDown (0)) && canShoot) {
			animator.SetTrigger ("fire");
			GameObject go = Instantiate (bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
			go.GetComponent<ElectroBullet> ().SetDirection (lookingLeft ? ElectroBullet.Direction.LEFT : ElectroBullet.Direction.RIGHT);
			StartCoroutine (CanShoot ());
		}
		
		if (Input.GetMouseButtonUp(1) && canThrow) {
			Vector2 tarPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			animator.SetTrigger ("throw");
			handle.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 ((tarPos.y - handle.position.y), (tarPos.x - handle.position.x)) * Mathf.Rad2Deg);
			lookingLeft = (handle.rotation.eulerAngles.z > 90 && handle.rotation.eulerAngles.z < 270);
			offset = lookingLeft? new Vector2 (-2.3f, 0.1f):offset = new Vector2 (-2f, 0.1f);
			GameObject go = Instantiate (grenade, (Vector2)spawnPoint.transform.position, Quaternion.identity);
			go.GetComponent<Rigidbody2D> ().AddForce ((tarPos - (Vector2)go.transform.position),ForceMode2D.Impulse);
			StartCoroutine(CanThrow ());
		}
	        
		if (Physics2D.OverlapCircle (ground.position, 0.01f,groundLayer)) {
			falling = false;
			animator.SetBool ("grounded", true);
		} else {
			falling = true;
			animator.SetBool ("grounded", false);
		}

		//Animate
		sprite.flipX = lookingLeft;
		if (input!=0)
        {
			animator.SetBool("isWalking", true);
		}else{
			animator.SetBool("isWalking", false);
		}

		animator.SetBool("isCrouching", Input.GetKey(KeyCode.C));   
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
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

	IEnumerator CanThrow()
	{
		canThrow = false;
		yield return new WaitForSeconds(cooldown);
		canThrow = true;
	}

    private void Jump()
    {
		if (falling)
			return;
//		rb_Player.AddForce(Vector2.up * jumpPower*100f,ForceMode2D.Force);
		rb_Player.velocity = new Vector2(rb_Player.velocity.x,jumpPower);
		falling = true;
		animator.SetTrigger ("jumping");
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Coin")) {
			Destroy (other.gameObject);
			pSystem.points += 1;
		}
	}

}
