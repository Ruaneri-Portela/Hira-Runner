using UnityEngine;

public class Coletable : MonoBehaviour
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
            if (GameManger.AudioStatus != 4){ 
            Player.ColectSoundPlay = true;
            }
            Destroy(gameObject);
        };
    }
}
