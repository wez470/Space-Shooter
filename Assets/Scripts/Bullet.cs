using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float Speed;

    void Awake() {
        int bulletLayer = gameObject.layer;
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(bulletLayer, playerLayer, true);

    }

    void Update() {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed * Time.deltaTime;
    }
}
