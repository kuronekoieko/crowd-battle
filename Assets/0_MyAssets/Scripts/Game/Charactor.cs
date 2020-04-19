using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharactorType
{
    Player,
    EnemyPlayer,
    Wandering,
    Following,
}

public class Charactor : MonoBehaviour
{
    [SerializeField] Animator animator;
    public CharactorType charactorType { set; get; }
    PlayerController playerController;
    NPCController nPCController;

    public void OnStart(CharactorType charactorType)
    {
        playerController = GetComponent<PlayerController>();
        nPCController = GetComponent<NPCController>();

        switch (charactorType)
        {
            case CharactorType.Player:
                playerController.OnStart();
                break;
            case CharactorType.EnemyPlayer:
                break;
            case CharactorType.Wandering:
                nPCController.OnStart();
                break;
            case CharactorType.Following:
                break;
            default:
                break;
        }
    }

    public void OnUpdate()
    {
        switch (charactorType)
        {
            case CharactorType.Player:
                playerController.OnUpdate();
                break;
            case CharactorType.EnemyPlayer:
                break;
            case CharactorType.Wandering:
                nPCController.OnUpdate();
                break;
            case CharactorType.Following:
                break;
            default:
                break;
        }
    }
}
