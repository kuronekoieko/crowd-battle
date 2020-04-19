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
}
