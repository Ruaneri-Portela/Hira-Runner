using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LaneChange : MonoBehaviour
{
    public float TimeDelay;
    private bool MoveControlRight=true, MoveControlLeft = true, Move= true;
    private bool isGrounded;
    public float jumpForce;
    public AudioSource JumpAudio;
    public static string Track;
    public Rigidbody rb;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.UnloadScene(1);
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.O))
        {
            SceneManager.UnloadScene(1);
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.P) & Time.timeScale != 0) {
            Time.timeScale = 0;
        }
        else if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKey("right") && MoveControlRight && transform.position.x < 4)
        {
            transform.Translate(6, 0, 0);
            MoveControlRight = false;
            if (GameManger.AudioStatus != 4)
            {
                JumpAudio.Play();
            }
            StartCoroutine(MoveRight());
        }
        if (Input.GetKey("left") && MoveControlLeft && transform.position.x > -4)
        {
            transform.Translate(-6, 0, 0);
            MoveControlLeft = false;
            if (GameManger.AudioStatus != 4)
            {
                JumpAudio.Play();
            }
            StartCoroutine(MoveLeft());
        }
        if (Input.GetKey("up") && isGrounded)
        {
            rb.AddForce(
            Vector3.up * jumpForce,
            ForceMode.Impulse
            );
            isGrounded = false;
            if (GameManger.AudioStatus != 4)
            {
                JumpAudio.Play();
            }
        }
        if (Input.GetKey(KeyCode.E) && Move)
        {
            transform.Translate(0, 0, 6);
            Move = false;
            if (GameManger.AudioStatus != 4)
            {
                JumpAudio.Play();
            }
            StartCoroutine(MoveF());
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Florest")
        {
            isGrounded = true;
            Track = "Florest";
        }
        else if (collision.gameObject.tag == "City")
        {
            isGrounded = true;
            Track = "City";
        }
        else
        {
            isGrounded = false;
        };
    }
    IEnumerator MoveRight()
    {
        yield return new WaitForSeconds(TimeDelay);
        MoveControlRight = true;
    }
    IEnumerator MoveLeft()
    {
        yield return new WaitForSeconds(TimeDelay);
        MoveControlLeft = true;
    }
    IEnumerator MoveF()
    {
        yield return new WaitForSeconds(TimeDelay);
        Move = true;
    }
}
