using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrackControler : MonoBehaviour
{
    public Transform Controler;
    private int ChoiceTrack;
    private float BuildControl;
    private int Control=0;
    public int TrackLong;
    private int CityTrack, FlorestTrack;
    void Update()
    {
        BuildControl = transform.position.z - Player.PlayerLocationZ;
        if (2000.0f > BuildControl)
        {
            if (Control == 0) 
            { 
                ChoiceTrack = Random.Range(0, 2);
                Control = TrackLong;

            }
            switch (ChoiceTrack)
            {
                case 0:
                    City();
                    break;
                case 1:
                    Florest();
                    break;
            }
            Control = Control - 1;
            transform.Translate(0, 0, (250));
        }
    }
    private void Yellow()
    {
        Instantiate(Resources.Load("Prefabs/YellowTrack"), new Vector3(0, 0, transform.position.z), Quaternion.identity);
    }
    private void Red()
    {
        Instantiate(Resources.Load("Prefabs/RedTrack"), new Vector3(0, 0, transform.position.z), Quaternion.identity);
    }
    private void Blue()
    {
        Instantiate(Resources.Load("Prefabs/BlueTrack"), new Vector3(0, 0, transform.position.z), Quaternion.identity);
    }
    private void Black()
    {
        Instantiate(Resources.Load("Prefabs/BlackTrack"), new Vector3(0, 0, transform.position.z), Quaternion.identity);
    }
    private void White()
    {
        Instantiate(Resources.Load("Prefabs/WhiteTrack"), new Vector3(0, 0, transform.position.z), Quaternion.identity);
    }
    private void City()
    {
        CityTrack = Random.Range(0, 3);
        switch (CityTrack)
        {
            case 0:
                Blue();
                break;
            case 1:
                Red();
                break;
            case 2:
                White();
                break;
        }
    }
    private void Florest()
    {
        FlorestTrack = Random.Range(0, 2);
        switch (FlorestTrack)
        {
            case 0:
                Yellow();
                break;
            case 1:
                Black();
                break;
        } 
    }
}