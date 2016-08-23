using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
    public enum ObjectTypes {
        Bullet,
        Enemy,
        Explosion
    };
    public static ObjectPooler Instance;

    public int InitialBulletCount = 20;
    public int InitialEnemyCount = 20;
    public int InitialExplosionCount = 5;
    public GameObject Bullet;
    public GameObject Enemy;
    public GameObject Explosion;

    private Dictionary<ObjectTypes, List<GameObject>> gameObjects = new Dictionary<ObjectTypes, List<GameObject>>();
    private Dictionary<ObjectTypes, GameObject> prefabs = new Dictionary<ObjectTypes, GameObject>();

    void Awake() {
        Instance = this;
    }

    void Start() {
        gameObjects.Add(ObjectTypes.Bullet, new List<GameObject>());
        gameObjects.Add(ObjectTypes.Enemy, new List<GameObject>());
        gameObjects.Add(ObjectTypes.Explosion, new List<GameObject>());
        prefabs.Add(ObjectTypes.Bullet, Bullet);
        prefabs.Add(ObjectTypes.Enemy, Enemy);
        prefabs.Add(ObjectTypes.Explosion, Explosion);

        for (int i = 0; i < InitialBulletCount; i++) {
            GameObject newBullet = (GameObject)Instantiate(Bullet);
            newBullet.SetActive(false);
            gameObjects[ObjectTypes.Bullet].Add(newBullet);
        }
        for (int i = 0; i < InitialEnemyCount; i++) {
            GameObject newEnemy = (GameObject)Instantiate(Enemy);
            newEnemy.SetActive(false);
            gameObjects[ObjectTypes.Enemy].Add(newEnemy);
        }
        for (int i = 0; i < InitialExplosionCount; i++) {
            GameObject newExplosion = (GameObject)Instantiate(Explosion);
            newExplosion.SetActive(false);
            gameObjects[ObjectTypes.Explosion].Add(newExplosion);
        }
    }

    public GameObject GetPooledObject(ObjectTypes type) {
        foreach (GameObject obj in gameObjects[type]) {
            if (!obj.activeInHierarchy) {
                return obj;
            }
        }
        GameObject newObj = (GameObject)Instantiate(prefabs[type]);
        gameObjects[type].Add(newObj);
        return newObj;
    }
}
