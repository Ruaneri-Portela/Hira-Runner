using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrack : MonoBehaviour
{
    private float DestroyControl;
    void Update()
    {
        DestroyControl = transform.position.z-Player.PlayerLocationZ;
        if (-260.0f > DestroyControl)
        {
            Destroy(gameObject);
        }
    }
}
