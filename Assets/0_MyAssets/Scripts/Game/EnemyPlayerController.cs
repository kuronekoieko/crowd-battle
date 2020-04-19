using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerController : MonoBehaviour
{
    float walkSpeed = 5f;
    Charactor charactor;
    Vector3 walkVec;
    Rigidbody rb;
    public void OnStart()
    {
        rb = GetComponent<Rigidbody>();
        charactor = GetComponent<Charactor>();
        charactor.skinnedMeshRenderer.material.color = Color.red;
    }

    public void OnUpdate()
    {
        var npc = GameManager.i.GetClosestNPC(transform.position);
        if (npc)
        {
            walkVec = npc.transform.position - transform.position;
        }
        SetVelocityFromWalkVec();
    }

    void SetVelocityFromWalkVec()
    {
        float degree = Vector2ToDegree(new Vector2(walkVec.z, walkVec.x));
        transform.eulerAngles = new Vector3(0, degree, 0);
        Vector3 vel = walkVec.normalized * walkSpeed;
        //落下しなくなるため、上に飛ばないようにする
        //if (rb.velocity.y < 0) vel.y = rb.velocity.y;
        rb.velocity = vel;
    }

    float Vector2ToDegree(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }

}
