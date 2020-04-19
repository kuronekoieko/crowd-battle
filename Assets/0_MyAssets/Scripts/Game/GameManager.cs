using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 3D空間の処理の管理
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] Charactor player;
    [SerializeField] CameraController _cameraController;
    [SerializeField] Transform fieldCornerUR;
    [SerializeField] Transform fieldCornerLL;
    [SerializeField] Charactor charactorPrefab;
    NPCController[] nPCControllers;
    EnemyPlayerController[] enemyPlayerControllers;
    PlayerController _playerController;
    public static GameManager i;
    void Start()
    {
        i = this;
        _playerController = player.gameObject.AddComponent<PlayerController>();
        _playerController.OnStart();
        _cameraController.OnStart(_playerController.transform.position);
        NPCGenerator();
        EnemyGenerator();
    }

    void FixedUpdate()
    {
        _playerController.OnUpdate();
        _cameraController.FollowTarget(_playerController.transform.position);
        for (int i = 0; i < nPCControllers.Length; i++)
        {
            nPCControllers[i].OnUpdate();
        }

        for (int i = 0; i < enemyPlayerControllers.Length; i++)
        {
            enemyPlayerControllers[i].OnUpdate();
        }
    }

    void EnemyGenerator()
    {
        enemyPlayerControllers = new EnemyPlayerController[8];
        for (int i = 0; i < enemyPlayerControllers.Length; i++)
        {
            Vector3 pos = GetRandomPos();
            var charactor = Instantiate(charactorPrefab, pos, Quaternion.identity, transform);
            enemyPlayerControllers[i] = charactor.gameObject.AddComponent<EnemyPlayerController>();
            enemyPlayerControllers[i].OnStart();
        }
    }

    void NPCGenerator()
    {
        nPCControllers = new NPCController[100];
        for (int i = 0; i < nPCControllers.Length; i++)
        {
            Vector3 pos = GetRandomPos();
            var charactor = Instantiate(charactorPrefab, pos, Quaternion.identity, transform);
            nPCControllers[i] = charactor.gameObject.AddComponent<NPCController>();
            nPCControllers[i].OnStart();
        }
    }

    public Vector3 GetRandomPos()
    {
        //座標をランダムに取得
        float x = Random.Range(fieldCornerLL.position.x, fieldCornerUR.position.x);
        float z = Random.Range(fieldCornerLL.position.z, fieldCornerUR.position.z);
        return new Vector3(x, 0, z);
    }

    public NPCController GetClosestNPC(Vector3 pos)
    {
        return nPCControllers
        .Where(n => n.nPCState == NPCState.Wandering)
        .OrderBy(n => (pos - n.transform.position).sqrMagnitude)
        .FirstOrDefault();
    }
}
