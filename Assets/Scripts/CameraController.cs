using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //назначаем переменной вектора3 координаты
    private Vector3 _offset = new Vector3(0, 4, -10);
    //находим игрока
    [SerializeField] private Transform _player;
    //следуем за игроком
    void LateUpdate ()
    {
        transform.position = _player.transform.position + _offset;
	}
}
