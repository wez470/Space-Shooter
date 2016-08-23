using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public static Score Instance;
    public int FontIncreaseSize;

    private int score = 0;
    private int originalFontSize;
    private int scoreUpdateFontSize;
    private float timeBetweenFontUpdates = 1 / 60f;
    private float timeOfLastFontUpdate;

    void Awake() {
        Instance = this;
        originalFontSize = GetComponent<Text>().fontSize;
        scoreUpdateFontSize = originalFontSize;
    }

    void Update() {
        if (scoreUpdateFontSize > originalFontSize
                && Time.timeSinceLevelLoad - timeOfLastFontUpdate > timeBetweenFontUpdates) {
            timeOfLastFontUpdate = Time.timeSinceLevelLoad;
            Text txt = GetComponent<Text>();
            txt.fontSize = scoreUpdateFontSize;
            scoreUpdateFontSize--;
        }
    }

    public void UpdateScore() {
        score++;
        Text txt = GetComponent<Text>();
        txt.text = "Score: " + score;
        scoreUpdateFontSize = originalFontSize + FontIncreaseSize;
        timeOfLastFontUpdate = Time.timeSinceLevelLoad;
    }
}
