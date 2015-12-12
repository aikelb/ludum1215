﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public AudioClip hit;
	public AudioClip explosion;
	public AudioClip shoot;
	
	Dictionary<AudioClip, int> priority;

	AudioSource aSource;
	
	float[] stamps;
	
	void Awake () {
		aSource = GetComponent<AudioSource>();
		stamps = new float[] {0,0,0};
		priority = new Dictionary<AudioClip, int>();
		priority.Add(hit, 0);
		priority.Add(explosion, 1);
		priority.Add(shoot, 2);
	}
	
	void OnEnable () {
		Gun.OnShoot += HandleOnShoot;	
	}
	
	void OnDisable () {
		Gun.OnShoot -= HandleOnShoot;
	}
	
	void HandleOnShoot () {
		Play(shoot);
	}
	
	void Play (AudioClip a) {
		if (a != null)
			return;
		if (Time.time - stamps[priority[a]] < 0.25f) {
			stamps[priority[a]] = Time.time;
			aSource.PlayOneShot(a);
		}
	}
	
}
