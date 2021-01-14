﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2 : MonoBehaviour
{
    float speed;
    float corner;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(15, new Vector3(0, 0, -15));
        transform.rotation *= rotationZ;
        corner = 15f;
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 position = transform.position;

        position = new Vector2(position.x + (corner / 5) * Time.deltaTime, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "AsteroidTag"))
        {
            Destroy(gameObject);
        }
    }
}
