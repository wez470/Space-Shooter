using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public float shakeAmt = 0.1f;

    private Vector3 originalPosition;

    public void Shake() {
        originalPosition = transform.position;
        InvokeRepeating("shake", 0, .01f);
        Invoke("stopShaking", 0.5f);
    }

    private void shake() {
        float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
        Vector3 pp = transform.position;
        pp.y += quakeAmt; // can also add to x and/or z
        transform.position = pp;
    }

    private void stopShaking() {
        CancelInvoke("shake");
        transform.position = originalPosition;
    }
}