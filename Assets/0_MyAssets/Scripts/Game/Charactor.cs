using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Charactor : MonoBehaviour
{
    [SerializeField] Animator animator;
    public CapsuleCollider capsuleCollider;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    public NavMeshAgent agent { get; set; }
    public void OnStart()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
