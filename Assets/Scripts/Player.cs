﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;

    void Update() {
        setRotation();
        setMovement();
        checkFire();
    }

    private void setMovement() {
        float speed = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, speed));
    }

    private void setRotation() {
        float rotValue = Input.GetAxisRaw("Horizontal");

        if (rotValue < 0) {
            float nextAngle = transform.eulerAngles.z + (RotSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, nextAngle);
        }
        else if (rotValue > 0) {
            float nextAngle = transform.eulerAngles.z - (RotSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, nextAngle);
        }
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    private void checkFire() {
        if (Input.GetButtonDown("Fire")) {
            GameObject bullet = ObjectPooler.instance.GetPooledObject(ObjectPooler.ObjectTypes.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}