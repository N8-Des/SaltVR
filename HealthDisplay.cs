using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {
	public int maxHealth = 20;
	public int health;
	public Text healthDisplay;


	public void Start(){
		health = maxHealth;
		UpdateHealthDisplay ();
		healthDisplay = GetComponent<Text> ();
	}

	public int TakeDamage(int damage){
		health -= damage;
		if (health < 0) {
			Die ();
		}
		if (health > maxHealth) {
			health = maxHealth;
		}
		UpdateHealthDisplay ();
		return health;
	}
	public void Die() {
		Debug.Log ("I AM DEAD -- HAL");
	}
	public void UpdateHealthDisplay(){
		healthDisplay.text =  health.ToString();
	}

}