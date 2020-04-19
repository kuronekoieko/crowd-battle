using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCState
{
    Wandering,
    Following,
}

public class NPCController : MonoBehaviour
{
    Rigidbody rb;
    float timer;
    Vector3 walkVec;
    float walkSpeed = 1f;
    float timeLimit;
    public NPCState nPCState { get; private set; }

    Transform targetTF;
    Charactor charactor;
    public void OnStart()
    {
        rb = GetComponent<Rigidbody>();
        int x = Random.Range(-10, 10);
        int z = Random.Range(-10, 10);
        walkVec = new Vector3(x, 0, z);
        timeLimit = Random.Range(1, 6);

        nPCState = NPCState.Wandering;
        charactor = GetComponent<Charactor>();
        charactor.OnStart();
        charactor.skinnedMeshRenderer.material.color = Color.white;
        //charactor.agent.speed = 10;
    }

    public void OnUpdate()
    {
        switch (nPCState)
        {
            case NPCState.Wandering:
                Wandering();
                break;
            case NPCState.Following:
                Following();
                break;
            default:
                break;
        }
    }

    void Following()
    {
        if (targetTF == null) { return; }
        charactor.agent.SetDestination(targetTF.position);
    }

    void Wandering()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            timer = 0;
            timeLimit = Random.Range(1, 6);
            int x = Random.Range(-10, 10);
            int z = Random.Range(-10, 10);
            walkVec = new Vector3(x, 0, z);
        }
        float degree = Vector2ToDegree(new Vector2(walkVec.z, walkVec.x));
        transform.eulerAngles = new Vector3(0, degree, 0);
        Vector3 vel = walkVec.normalized * walkSpeed;
        //落下しなくなるため、上に飛ばないようにする
        if (rb.velocity.y < 0) vel.y = rb.velocity.y;
        rb.velocity = vel;
    }

    float Vector2ToDegree(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }

    public void SetTarget(Transform targetTF)
    {
        if (nPCState == NPCState.Following) { return; }
        this.targetTF = targetTF;
        nPCState = NPCState.Following;
        rb.isKinematic = true;
    }
}
