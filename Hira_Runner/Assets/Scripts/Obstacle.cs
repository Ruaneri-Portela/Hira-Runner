using UnityEngine;
public class Obstacle : MonoBehaviour
{
    private float DestroyControl;
    void Update()
    {
        DestroyControl = transform.position.z - Player.PlayerLocationZ;
        if (-10f > DestroyControl || ((transform.position.z - Player.PlayerLocationZ) < 50 && Player.Clean))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.tag == "Player") && !(collision.gameObject.tag == "Ground"))
        {
            Destroy(gameObject);
        };
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if (GameManger.AudioStatus != 4)
            {
                Player.ObstaculePlay = true;
            }
            Player.Impact = true;
            Player.Touched = true;
        };

    }
}
