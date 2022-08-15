using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject model;
    public Transform PlayerTranform;
    public Rigidbody rb;
    public float ForwardSpeed;
    public float MaxForwardSpeed;
    public float MinForwardSpeed;
    public static float PlayerLocationZ;
    public AudioSource ColectSound;
    public static bool ColectSoundPlay;
    public AudioSource Obstacule;
    public static bool ObstaculePlay;
    public static bool Impact;
    public TextMeshProUGUI TMPText;
    public TextMeshProUGUI TMPText2;
    public int Score = 0;
    public int Distance;
    public static int LifeCount;
    public Image Life1;
    public Image Life2;
    public Image Life3;
    public static bool Clean;
    public bool CanLife;
    public bool CanWalk;
    public char[] Hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
    public string FileName = @"";
    public static string PlayerTrack;
    public string pPlayerTrack;
    public int Speed;
    public string Sound, Luminense;
    public static string Track;
    public static bool Touched = false;
    public System.Random random = new();
    void Start()
    {
        LifeCount = 3;
        Track = Sound = Luminense = null;
        Impact = false;
        Clean = true;
        CanLife = true;
        StartCoroutine(WaitClean());
        StartCoroutine(MakeData(CreateFle()));
    }
    void Update()
    {
        pPlayerTrack = PlayerTrack;
        transform.position = new Vector3(0, 0, PlayerTranform.position.z);
        SpeedControl();
        Distance = Convert.ToInt32(transform.position.z / 2.0f);
        TMPText2.SetText((Distance-10).ToString());
        if (ColectSoundPlay)
        {
            Score++;
            TMPText.SetText(Score.ToString());
            ColectSound.Play();
            ColectSoundPlay = false;
        }
        if (ObstaculePlay && CanLife)
        {
            LifeCount--;
            Life();
            Obstacule.Play();
            ObstaculePlay = false;
            CanLife = false;
            StartCoroutine(Can());

        }
        PlayerLocationZ = transform.position.z;
        if (Impact)
        {
            ForwardSpeed = 0f;
            StartCoroutine(WaitWalk());
            CanWalk = false;
        }
        else
        {
            CanWalk = true;
        }
    }
    private void FixedUpdate()
    {
        if (CanWalk)
        {
            rb.velocity = Vector3.forward * ForwardSpeed;
        }
    }
    IEnumerator WaitWalk()
    {
        yield return new WaitForSeconds(2);
        Impact = false;
    }
    IEnumerator WaitClean()
    {
        yield return new WaitForSeconds(0.5f);
        Clean = false;
    }
    IEnumerator Can()
    {
        yield return new WaitForSeconds(5);
        ObstaculePlay = false;
        Impact = false;
        CanLife = true;
    }
    public void Life()
    {
        switch (LifeCount)
        {
            case 1:
                Life1.enabled = true;
                Life2.enabled = false;
                Life3.enabled = false;
                break;
            case 2:
                Life1.enabled = true;
                Life2.enabled = true;
                Life3.enabled = false;
                break;
            case 3:
                Life1.enabled = true;
                Life2.enabled = true;
                Life3.enabled = true;
                break;
            default:
                Life1.enabled = false;
                Life2.enabled = false;
                Life3.enabled = false;
                break;
        }
    }
    public void SpeedControl()
    {
        if (ForwardSpeed >= MaxForwardSpeed) ForwardSpeed = MaxForwardSpeed;
        if (ForwardSpeed <= MinForwardSpeed) ForwardSpeed = MinForwardSpeed;
        if (NeuroData.sAttention > 80)
        {
            ForwardSpeed += 0.05f;
        }
        else if (NeuroData.sAttention > 60 && NeuroData.sAttention <= 80)
        {
            ForwardSpeed += 0.02f;
        }
        else if (NeuroData.sAttention >= 40 && NeuroData.sAttention <= 60)
        {
            ForwardSpeed += 0.01f;
        }
        else
        {
            ForwardSpeed -= 0.01f;
        }
    }
    public string CreateFle()
    {
        FileName += @"C:\Users\ruane";
        FileName += @"\";
        for (int FileNameSize = 0; FileNameSize < 9; FileNameSize++)
        {
            FileName += Hex[random.Next(0, 15)];
        }
        FileName += ".csv";
        string file = Headers(FileName);
        return file;
    }
    public string Headers(string FileName)
    {
        string file = FileName;
        string[] HeaderText = { "Atencion Level, Meditation Level, Track Type, Sound Status, Touched Obstacule, Distance, Speed" };
        File.WriteAllLines(file, HeaderText);
        return file;
    }
    IEnumerator MakeData(string file)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (Time.timeScale != 0)
            {
                Sound = "Enable";
                DataRecord(file, NeuroData.sAttention, NeuroData.sMeditation, LaneChange.Track, GameManger.AudioStatus, Touched, Luminense,Distance-10,Convert.ToInt32((ForwardSpeed-4)));
                if (Touched)
                {
                    Touched = false;
                }
            }
        }
    }
    public void DataRecord(string file, float AT, float ML, string LT, int ST, bool TO, string LM,int Distance,int Speed)
    {
        string SoundContext="";
        if (ST == 0)
        {
            SoundContext = "Sound Track";
        }
        else if (ST == 1) {
            SoundContext = "Ambiente";
        }
        else if (ST ==4)
        {
            SoundContext = "Only Effects";
        }
        else
        {
            SoundContext = "Mute";
        }
        string DataForWrite = Convert.ToString(AT) + "," + Convert.ToString(ML) + "," + LT + "," + SoundContext + "," + Convert.ToString(TO) + "," + Convert.ToString(Distance) + "," +Convert.ToString(Speed)+"\n";
        File.AppendAllText(file, DataForWrite);
    }
}