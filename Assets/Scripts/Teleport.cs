using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Teleport _otherTP;
    public bool isTping = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTping)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _otherTP.isTping = true;
                collision.gameObject.transform.position = _otherTP.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTping = false;
        }

    }
}
