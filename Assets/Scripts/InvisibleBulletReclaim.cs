using UnityEngine;
using System.Collections;

public class InvisibleBulletReclaim : MonoBehaviour {
    void OnBecameInvisible() {
        transform.parent.gameObject.SetActive(false);
    }
}
