using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerController : MonoBehaviour
{
    Charactor charactor;
    public void OnStart()
    {
        charactor = GetComponent<Charactor>();
        charactor.skinnedMeshRenderer.material.color = Color.red;
    }

    public void OnUpdate()
    {

    }
}
