using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private double _reloadTime = 3;
    [SerializeField]
    private double _fireTime = 1;
    private bool _firing = true;
    private double deltaTime=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (_firing && deltaTime>=_fireTime)
        {
            _firing = false;
            deltaTime = 0;
            _laser.SetActive(false);
        }else if(!_firing && deltaTime>= _reloadTime)
        {
            _firing = true;
            deltaTime = 0;
            _laser.SetActive(true);
        }
    }
}
