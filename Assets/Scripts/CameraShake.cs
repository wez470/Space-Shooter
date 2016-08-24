using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public readonly Vector3 StartPosition = new Vector3(0, 0, -1);
    public float shakeAmt;
    public float shakeLength;

    public void Shake() {
        InvokeRepeating("shake", 0, .01f);
        Invoke("stopShaking", shakeLength);
    }

    private void shake() {
        float quakeAmtX = Random.value * shakeAmt * 2 - shakeAmt;
        float quakeAmtY = Random.value * shakeAmt * 2 - shakeAmt;
        Vector3 position = transform.position;
        position.x += quakeAmtX;
        position.y += quakeAmtY;
        transform.position = position;
    }

    private void stopShaking() {
        CancelInvoke("shake");
        transform.position = StartPosition;
    }
}