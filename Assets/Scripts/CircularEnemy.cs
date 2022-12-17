using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularEnemy : Enemy
{

    private float angle = 0;


    // Update is called once per frame
    void Update()
    {

        float x = _steps * Mathf.Cos(angle);
        float y = _steps * Mathf.Sin(angle);
        transform.position = new Vector2(x, y);

        angle += _velocity * Mathf.Deg2Rad * Time.deltaTime;
    }
}
