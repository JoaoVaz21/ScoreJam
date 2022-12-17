using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    private GameObject _player;
    private void Start()
    {
        GameManager.Instance.AttachSpawner(this);
       _player = Instantiate(_playerPrefab, this.transform.position, this.transform.rotation);
    }

    public void InstantiatePlayerOnLevel()
    {
        _player.transform.position = this.transform.position;
    }
}
