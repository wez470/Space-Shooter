using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
    public enum ObjectTypes {
        Bullet,
        Enemy
    };
    public static ObjectPooler instance;

    public int initialBulletCount = 20;
    public int initialEnemyCount = 20;
    public GameObject bullet;
    public GameObject enemy;

    private Dictionary<ObjectTypes, List<GameObject>> gameObjects = new Dictionary<ObjectTypes, List<GameObject>>();

    void Awake() {
        instance = this;
    }

    void Start() {
        gameObjects.Add(ObjectTypes.Bullet, new List<GameObject>());
        gameObjects.Add(ObjectTypes.Enemy, new List<GameObject>());

        //TODO : initialize gameObjects with enemies and bullets
        for (int i = 0; i < initialBulletCount; i++) {
            GameObject newBullet = (GameObject)Instantiate(bullet);
            newBullet.SetActive(false);
            gameObjects[ObjectTypes.Bullet].Add(newBullet);
        }
        for (int i = 0; i < initialEnemyCount; i++) {
            GameObject newEnemy = (GameObject)Instantiate(enemy);
            newEnemy.SetActive(false);
            gameObjects[ObjectTypes.Enemy].Add(newEnemy);
        }
    }

    public GameObject GetPooledObject(ObjectTypes type) {
        foreach (GameObject obj in gameObjects[type]) {
            if (!obj.activeInHierarchy) {
                return obj;
            }
        }
        // TODO : Create proper type!
        GameObject newObj = (GameObject)Instantiate(bullet);
        gameObjects[type].Add(newObj);
        return newObj;
    }
}
