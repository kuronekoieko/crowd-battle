using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3D空間の処理の管理
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] CameraController _cameraController;
    void Start()
    {
        _playerController.OnStart();
        _cameraController.OnStart(_playerController.transform.position);
    }

    void FixedUpdate()
    {

        _cameraController.FollowTarget(_playerController.transform.position);
    }
}
