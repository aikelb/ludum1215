using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarManager : MonoBehaviour {
    public GameObject healthBar;


    void OnEnable() {
        Ship.OnHealUp += updateHealthBar;
        Ship.OnHit += updateHealthBar;
        Ship.OnDestroyed += updateHealthDeath;
    }

    private void updateHealthDeath(Vector3 position){
        updateHealthBar(0, position);
    }

    void updateHealthBar(int currentHealth, Vector3 shipPosition) {
        healthBar.GetComponent<Image>().fillAmount = getFillAmountForHealth(currentHealth);
    }

    private float getFillAmountForHealth(int currentHealth) {
        return currentHealth/3f;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
