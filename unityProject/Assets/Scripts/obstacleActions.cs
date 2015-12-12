using UnityEngine;
using System.Collections;

public class obstacleActions : MonoBehaviour {
    
    
    public delegate void _GotShot (Vector3 position);
    public static event _GotShot OnGotShot;
    public delegate void _Destroyed (Vector3 position, int score);
    public static event _Destroyed OnDestroyed;
    
    public GameObject player;
    public float randomPositionMultiplier;
    public float movementSpeed = 25f;
    public int hp = 5;
    public int score = 100;
    
	void Update () {
        transform.position += Vector3.back * movementSpeed * Time.deltaTime;
    }

    private void didHitPlayer() {
        
    }

    private void GotShot() {
        hp--;
        if (hp > 0) {
           if (OnGotShot != null)
                OnGotShot(transform.position); 
        } else {
            if (OnDestroyed != null)
                OnDestroyed(transform.position, score);
            Destroy(gameObject);
        }        
    }
}
