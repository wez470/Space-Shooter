using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float Speed;

    void Awake() {
        int bulletLayer = gameObject.layer;
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
    }

    void Update() {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed * Time.deltaTime;
    }
}
