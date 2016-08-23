using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public float shakeAmt = 0.1f;

    private Vector3 originalPosition;

    public void Shake() {
        originalPosition = transform.position;
        InvokeRepeating("shake", 0, .01f);
        Invoke("stopShaking", 0.3f);
    }

    private void shake() {
        float quakeAmtX = Random.value * shakeAmt * 2 - shakeAmt;
        float quakeAmtY = Random.value * shakeAmt * 2 - shakeAmt;
        Vector3 pp = transform.position;
        pp.x += quakeAmtX;
        pp.y += quakeAmtY;
        transform.position = pp;
    }

    private void stopShaking() {
        CancelInvoke("shake");
        transform.position = originalPosition;
    }
}