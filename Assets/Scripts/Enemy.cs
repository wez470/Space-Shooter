using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float Speed;
    public Transform Player;
	
	void Update() {
        transform.up = Player.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed * Time.deltaTime;
    }
}
