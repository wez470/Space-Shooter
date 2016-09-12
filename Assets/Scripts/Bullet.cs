using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float Speed;
    public AudioClip ExplosionClip;

    void Awake() {
        int bulletLayer = gameObject.layer;
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(bulletLayer, playerLayer, true);
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            Camera.main.GetComponent<CameraShake>().Shake();
            coll.gameObject.SetActive(false);
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(ExplosionClip, Camera.main.transform.position);
            createExplosion();
            Score.Instance.UpdateScore();
        }
    }

    private void createExplosion() {
        GameObject explosion = ObjectPooler.Instance.GetPooledObject(ObjectPooler.ObjectTypes.Explosion);
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);
    }
}
