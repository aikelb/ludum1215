using UnityEngine;
using System.Collections;

public class obstacleActions : MonoBehaviour {
    public GameObject player;
    public float randomPositionMultiplier;
    public float movementSpeed = 25f;

	// Use this for initialization
	/*void Start () { 
        endPosition = (Random.insideUnitSphere * randomPositionMultiplier) + player.transform.position;
        endPosition.z = player.transform.position.z;
        endPosition.x = this.transform.position.x;
        endPosition.y = this.transform.position.y;
    }*/
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.back * movementSpeed * Time.deltaTime;
    }

    private void didHitPlayer() {

    }

    private void gotShot()
    {

    }
}
