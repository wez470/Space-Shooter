using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float Speed;
    public AudioClip Explosion;

    void Awake() {
        int bulletLayer = gameObject.layer;
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(bulletLayer, playerLayer, true);
    }

    void Update() {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            Camera.main.GetComponent<CameraShake>().Shake();
            coll.gameObject.SetActive(false);
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(Explosion, Camera.main.transform.position);
        }
    }
}
