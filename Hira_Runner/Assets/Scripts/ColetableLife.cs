using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetableLife : MonoBehaviour
{
    public AudioSource ColectAudio;
    private float DestroyControl;
    void Update()
    {
        DestroyControl = transform.position.z - Player.PlayerLocationZ;
        if (-10f > DestroyControl)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.LifeCount <= 3) { 
                Player.LifeCount++;
            }if (Player.LifeCount < 0) {
                Player.LifeCount = 0; ;
            }
            Player.ColectSoundPlay = true;
            Destroy(gameObject);
        };
    }
}
