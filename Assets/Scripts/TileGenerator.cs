using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _tilePrefabs;
    [SerializeField] private Transform _player;
    
    private float spawnPosition = 0;
    private float _tilelength = 100;
    private int TileOnStart = 5;
    private List<GameObject> _activeTiles = new List<GameObject>();
    
    
    //�������� ������� 2 ������� ��������
    void Start()
    {
        for (int i = 0; i < TileOnStart; i++)
        {
            SpawnTile(Random.Range(0, _tilePrefabs.Length));
        }
        
        
    }

    //��������� ������� ������
    void Update()
    {
        if (_player.position.z -85 > spawnPosition - (TileOnStart * _tilelength))
        {
            SpawnTile(Random.Range(0, _tilePrefabs.Length));
            DeleteTiles();
        }
        
    }
    //����� ��������
    private void SpawnTile(int index)
    {
        GameObject _nextTile =  Instantiate(_tilePrefabs[index], transform.forward * spawnPosition, transform.rotation);
        _activeTiles.Add(_nextTile);    
        spawnPosition += _tilelength;
    }
    //�������� ��������
    private void DeleteTiles()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}
