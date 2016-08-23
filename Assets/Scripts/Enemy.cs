using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float Speed;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update() {
        transform.up = player.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            GameController.Instance.GameOver();
            Time.timeScale = 0;
        }
    }
}
