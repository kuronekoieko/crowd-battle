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

    [SerializeField] Transform fieldCornerUR;
    [SerializeField] Transform fieldCornerLL;
    [SerializeField] PlayerController wanderingPlayerPrefab;
    PlayerController[] wanderingPlayers;

    void Start()
    {
        _playerController.OnStart();
        _cameraController.OnStart(_playerController.transform.position);
        WanderingGenerator();
    }

    void FixedUpdate()
    {

        _cameraController.FollowTarget(_playerController.transform.position);
    }

    void WanderingGenerator()
    {
        wanderingPlayers = new PlayerController[100];
        for (int i = 0; i < wanderingPlayers.Length; i++)
        {
            Vector3 pos = GetRandomPos();
            wanderingPlayers[i] = Instantiate(wanderingPlayerPrefab, pos, Quaternion.identity, transform);
            wanderingPlayers[i].OnStart();
        }
    }

    public Vector3 GetRandomPos()
    {
        //座標をランダムに取得
        float x = Random.Range(fieldCornerLL.position.x, fieldCornerUR.position.x);
        float z = Random.Range(fieldCornerLL.position.z, fieldCornerUR.position.z);
        return new Vector3(x, 0, z);
    }
}
