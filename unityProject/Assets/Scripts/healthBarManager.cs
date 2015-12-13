﻿using UnityEngine;
using System.Collections;

public class healthBarManager : MonoBehaviour {
    public GameObject healthBarSprite;
    public SpriteRenderer[] healthBarSprites = new SpriteRenderer[3];


    void OnEnabled() {
        Ship.OnHealUp += updateHealthBar;
    }

    void updateHealthBar(int currentHealth, Vector3 shipPosition) {

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeHealthSprite(int currentHealth)
    {
        if (currentHealth < healthBarSprites.Length && currentHealth >= 0)
        {
            switchSprite(healthBarSprites[currentHealth]);
        }
    }

    private void switchSprite(SpriteRenderer healthSprite)
    {
        //healthBarSpriteRenderer. = healthSprite;
    }
}
