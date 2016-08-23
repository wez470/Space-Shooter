using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    void OnEnable() {
        Invoke("deactivate", 0.3f);
    }

    private void deactivate() {
        gameObject.SetActive(false);
    }
}
