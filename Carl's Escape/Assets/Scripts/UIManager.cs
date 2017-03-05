using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;
	private static bool UIExists;
	private Image fillImg;
	private GameObject pauseScreen;
	private PlayerController player;
	private NPlayerController nPlayer;
	private ZombieController[] enemies;

	// Use this for initialization
	void Start () {
		fillImg = healthBar.fillRect.GetComponent<Image> ();
		pauseScreen = transform.FindChild("Pause").gameObject;

		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (!pauseScreen.activeSelf) {
				pauseScreen.SetActive (true);

				player = FindObjectOfType<PlayerController> ();
				if(player){
					player.canMove = false;
				}

				nPlayer = FindObjectOfType<NPlayerController> ();
				if (nPlayer) {
					nPlayer.canMove = false;
				}

				enemies = FindObjectsOfType<ZombieController> ();
				if(enemies.Length > 0){
					foreach(ZombieController enemy in enemies){
						enemy.canMove = false;
					}
				}

			} else {
				pauseScreen.SetActive (false);

				if(player){
					player.canMove = true;
				}
				if (nPlayer) {
					nPlayer.canMove = true;
				}
				if(enemies.Length > 0){
					foreach(ZombieController enemy in enemies){
						enemy.canMove = true;
					}
				}
			}
		} 

		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = playerHealth.playerCurrentHealth+" / "+playerHealth.playerMaxHealth;

		if (playerHealth.playerCurrentHealth >= (0.5f * playerHealth.playerMaxHealth)) {
			fillImg.color = new Color (0f, 0.75f, 0f);
		} 
		else if (playerHealth.playerCurrentHealth >= (0.25f * playerHealth.playerMaxHealth)) {
			fillImg.color = new Color (1f, 0.8f, 0f);
		} 
		else {
			fillImg.color = new Color (1f, 0f, 0f);
		}
	}
}
