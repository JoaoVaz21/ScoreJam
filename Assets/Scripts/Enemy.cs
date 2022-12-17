using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{   
    Up,
    Down,
    Right,
    Left,
    UpRight,
    UpLeft,
    DownRight,
    DownLeft
}
public class Enemy : MonoBehaviour
{
    protected Vector2[] directions =
    {
       new Vector2(0,1),
       new Vector2(0,-1),
       new Vector2(1,0),
       new Vector2(-1,0),
       new Vector2(1,1),
       new Vector2(-1,1),
       new Vector2(1,-1),
       new Vector2(-1,-1),

    };
    [SerializeField]
    private Directions _moveDirection;
    [SerializeField]
    protected int _steps;
    [SerializeField]
    protected float _velocity = 1f;
    private Rigidbody2D _rigidBody2D;
    private bool _reverse = false;
    private int _stepCount=0;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_reverse)
        {
            if (_stepCount <= _steps)
            {
                _rigidBody2D.velocity = new Vector2(_velocity * directions[(int)_moveDirection].x, _velocity * directions[(int)_moveDirection].y);
                _stepCount++;
            }
            else
            {
                _reverse = true;
            }
        }
        else
        {
            if (_stepCount >= 0)
            {
                _rigidBody2D.velocity = new Vector2(-_velocity * directions[(int)_moveDirection].x, -_velocity * directions[(int)_moveDirection].y);
                _stepCount--;
            }
            else
            {
                _reverse = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.KillPlayer();
        }
    }


}
