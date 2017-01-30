using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private LevelManager levelManager;

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	public int defaultMoveSpeed;
	public int defaultJumpHeight;
	public float defaultShotDelay;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	public GameObject jumpParticleEffect;
	public GameObject speedParticleEffect;
	public GameObject fireParticleEffect;
	public GameObject rapidfireParticleEffect;
	public GameObject shootingObjet;
	public GameObject defaultBeam;
	public Transform firePoint;
	public float shotDelay;
	private float shotDelayCounter;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	public bool invinsible;
	public float invinsibleRespawnTime;
	public float invinsibleHurtTime;
	private bool enableShooting;
	private bool enableMoving;

	private Rigidbody2D rb;
	private Animator anim;

	public InfinityBuff infinityBuff;
	public SpeedBuff speedBuff;
	public JumpBuff jumpBuff;
	public RapidfireBuff rapidfireBuff;
	private BuffableEntity buffable;

	void Awake () {
		invinsible = false;
		enableShooting = true;
		enableMoving = true;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () {
		buffable = FindObjectOfType<BuffableEntity> ();
		levelManager = FindObjectOfType<LevelManager> ();
		fireParticleEffect.SetActive (false);
		speedParticleEffect.SetActive (false);
		jumpParticleEffect.SetActive (false);
		rapidfireParticleEffect.SetActive (false);
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1f) {
			anim.SetBool ("Grounded", grounded);

			if (Input.GetKeyDown (KeyCode.Alpha4))
			{
				TimedInfinityBuff infBuff = (TimedInfinityBuff)infinityBuff.InitializeBuff (this);
				buffable.AddBuff (infBuff);
			}

			if (Input.GetKeyDown (KeyCode.Alpha1))
			{
				TimedSpeedBuff spdBuff = (TimedSpeedBuff)speedBuff.InitializeBuff (this);
				buffable.AddBuff (spdBuff);
			}

			if (Input.GetKeyDown (KeyCode.Alpha2))
			{
				TimedJumpBuff jmpBuff = (TimedJumpBuff)jumpBuff.InitializeBuff (this);
				buffable.AddBuff (jmpBuff);
			}

			if (Input.GetKeyDown (KeyCode.Alpha3))
			{
				TimedRapidfireBuff rpfbuff = (TimedRapidfireBuff)rapidfireBuff.InitializeBuff (this);
				buffable.AddBuff (rpfbuff);
			}

			if (Input.GetKeyDown (KeyCode.Space) && grounded)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpHeight); 
				anim.SetBool ("Hurt", false);
			}

			moveVelocity = 0f;

			if (Input.GetKey(KeyCode.D))
			{
				//rb.velocity = new Vector2(moveSpeed, rb.velocity.y); 
				anim.SetBool ("Hurt", false);
				moveVelocity = moveSpeed;
			}

			if (Input.GetKey(KeyCode.A))
			{
				//rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); 
				anim.SetBool ("Hurt", false);
				moveVelocity = -moveSpeed;
			}

			if (knockbackCount <= 0) {
				rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);
			} else {
				if (knockFromRight) {
					rb.velocity = new Vector2 (-knockback, rb.velocity.y);
				}
				if (!knockFromRight) {
					rb.velocity = new Vector2 (knockback, rb.velocity.y);
				}
				knockbackCount -= Time.deltaTime;
			}

			anim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x)); 

			if (rb.velocity.x > 0) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (rb.velocity.x < 0) {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			if ((Input.GetKeyDown (KeyCode.Return) || Input.GetMouseButtonDown (0)) && enableShooting) {
				anim.SetBool ("Hurt", false);
				anim.SetBool ("Shooting", true);
				Instantiate (shootingObjet, firePoint.position, firePoint.rotation);
				shotDelayCounter = shotDelay;
			} else if ((Input.GetKey (KeyCode.Return) || Input.GetMouseButton (0)) && enableShooting) {
				anim.SetBool ("Hurt", false);
				anim.SetBool ("Shooting", true);
				shotDelayCounter -= Time.deltaTime;
				if (shotDelayCounter <= 0) {
					shotDelayCounter = shotDelay;
					Instantiate (shootingObjet, firePoint.position, firePoint.rotation);
				}
			} else {
				anim.SetBool ("Shooting", false);
			}
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Enemy") {
			var enemy = other.GetComponent<HurtPlayerOnContact> ();
			if (!invinsible) {
				anim.SetBool ("Hurt", true);
				AudioManager.Main.PlayNewSound ("player_hurt");
				HealthManager.InflictDamage (enemy.damageInflicted);
				knockbackCount = knockbackLength;

				if (transform.position.x < other.transform.position.x) {
					knockFromRight = true;
				} else {
					knockFromRight = false;
				}
				invinsible = true;
				enableShooting = false;
				float time = Time.time;
				StartCoroutine (DoBlinks(0.1f));
				StartCoroutine (EnableShooting());
				StartCoroutine (ResetInvulnerability());
			}
		}
	}

	IEnumerator EnableShooting () {
		yield return new WaitForSeconds(invinsibleHurtTime/2);
		enableShooting = true;
	}

	IEnumerator DoBlinks (float blinkDuration) {
		float blinks = 0;
		while (blinks < invinsibleHurtTime) {
			if (blinks >= invinsibleHurtTime / 2) {
				anim.SetBool ("Hurt", false);
			}
			if (!invinsible) {
				Debug.Log ("Blinking invinsibility while vulnerable!");
			}
			transform.GetComponent<Renderer> ().enabled = !transform.GetComponent<Renderer> ().enabled;
			if (HealthManager.playerHealth <= 0) {
				transform.GetComponent<Renderer> ().enabled = false;
				anim.SetBool ("Hurt", false);
				return true;
			}
			yield return new WaitForSeconds(blinkDuration);
			if (HealthManager.playerHealth <= 0) {
				transform.GetComponent<Renderer> ().enabled = false;
				anim.SetBool ("Hurt", false);
				return true;
			}
			blinks += invinsibleHurtTime/8;
		}
		anim.SetBool ("Hurt", false);
		transform.GetComponent<Renderer> ().enabled = true;
		if (HealthManager.playerHealth <= 0) {
			transform.GetComponent<Renderer> ().enabled = false;
			anim.SetBool ("Hurt", false);
			return true;
		}
	}

	IEnumerator ResetInvulnerability () {
		yield return new WaitForSeconds(invinsibleHurtTime);
		invinsible = false;
	}

}
