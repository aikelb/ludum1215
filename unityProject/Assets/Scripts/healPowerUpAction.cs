using UnityEngine;
using System.Collections;

public class healPowerUpAction : MonoBehaviour {
    public float movementSpeed = 10f;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.back * movementSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            other.SendMessage("HealUp");
            Destroy(gameObject);
        }
    }
}
