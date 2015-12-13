using UnityEngine;
using System.Collections;

public class obstacleActions : MonoBehaviour {
    
    enum state {
        Generate,
        Move,
        Boom
    }
    
    state currentState;
    
    public delegate void _GotShot (Vector3 position);
    public static event _GotShot OnGotShot;
    public delegate void _Destroyed (Vector3 position, int score);
    public static event _Destroyed OnDestroyed;
    
    public AnimationCurve generationCurve;
    
    public GameObject player;
    public float randomPositionMultiplier;
    public float movementSpeed = 25f;
    public int hp = 5;
    public int score = 100;
    
    void Start () {
        StartCoroutine(FSM());
    }
    
    IEnumerator FSM () {
        while (true) {
            yield return StartCoroutine(currentState.ToString());
        }
    }
    
    void ChangeState (state nextState) {
        if (currentState == state.Boom)
            return;
        currentState = nextState;
    }
    
    IEnumerator Generate () {
        float elapsedTime = 0;
        float animationTime = 0.5f;
        while (currentState == state.Generate && elapsedTime < animationTime) {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, generationCurve.Evaluate(elapsedTime/animationTime));
            elapsedTime += Time.deltaTime;
            yield return 0;
        }
        transform.localScale = Vector3.one;
        ChangeState(state.Move);
    }
    
    IEnumerator Move () {
        while (currentState == state.Move) {
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;
            yield return 0;
        }
    }
    
    IEnumerator Boom () {
        GetComponent<Collider>().enabled = false;
        float elapsedTime = 0;
        float animationTime = 0.5f;
        while (currentState == state.Boom) {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, elapsedTime/animationTime);
            elapsedTime += Time.deltaTime;
            yield return 0;
        }
        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }

    private void GotShot() {
        hp--;
        if (hp > 0) {
           if (OnGotShot != null)
                OnGotShot(transform.position); 
        } else {
            if (OnDestroyed != null)
                OnDestroyed(transform.position, score);
            ChangeState(state.Boom);
        }        
    }
    
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            other.SendMessage("Hit");
            ChangeState(state.Boom);
        }
    }
    
    
}
