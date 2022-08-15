using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectControler : MonoBehaviour
{
    public Transform GameControler;
    public int MaxObstacleControler, MaxObstacleControlerRange;
    public int ObstacleControler, ObstacleControlerRange;
    public int MinObstacleControler, MinObstacleControlerRange;
    private int ObsCtl1, ObsCtl2;
    public int ColetableControler, ColetableControlerRange;
    private int CltCtl1, CltCtl2;
    public Transform Vector;
    private int Range;
    public bool OnMindWaveGeneration;
    void Update()
    {
        ObstacleInstantiateControle();
        if (GameControler.position.z > (transform.position.z)+1750)
        {
            transform.Translate(0, 0, 6);
            ObsCtl1 = Random.Range(0, ObstacleControlerRange);
            ObsCtl2 = Random.Range(0, ObstacleControler);
            CltCtl1 = Random.Range(0, ColetableControler);
            CltCtl2 = Random.Range(0, ColetableControlerRange);
            if (ObsCtl1 == 1)
            {
                switch (ObsCtl2)
                {
                    case 0:
                        Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        break;
                    case 1:
                        Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        break;
                    case 2:
                        Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        break;
                    case 3:
                        Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        break;
                    case 4:
                        Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        break;
                    case 5:
                        Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                        ObstacleInstantiate(Vector);
                        break;
                }
                if (CltCtl1 == 1)
                {
                    switch (CltCtl2)
                    {
                        case 0:
                            Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                        case 1:
                            Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                        case 2:
                            Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                        case 3:
                            Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                        case 4:
                            Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                        case 5:
                            Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                        case 6:
                            Vector.position = new Vector3(-6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            Vector.position = new Vector3(6, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            Vector.position = new Vector3(0, transform.position.y, transform.position.z);
                            ColetableInstantiate(Vector);
                            break;
                    }
                }
            }
        }
    }
    void ObstacleInstantiate(Transform ObstacleTransform)
    {
        Range = Random.Range(0,4);
        switch (Range) {
            case 0:
                Instantiate(Resources.Load("Prefabs/Obstacle"), new Vector3(ObstacleTransform.position.x, ObstacleTransform.position.y, ObstacleTransform.position.z), Quaternion.identity);
                break;
            case 1:
                Instantiate(Resources.Load("Prefabs/Obstacle2"), new Vector3(ObstacleTransform.position.x, ObstacleTransform.position.y, ObstacleTransform.position.z), Quaternion.identity);
                break;
            case 2:
                Instantiate(Resources.Load("Prefabs/Obstacle3"), new Vector3(ObstacleTransform.position.x, ObstacleTransform.position.y, ObstacleTransform.position.z), Quaternion.identity);
                break;
            case 3:
                Instantiate(Resources.Load("Prefabs/Obstacle4"), new Vector3(ObstacleTransform.position.x, ObstacleTransform.position.y, ObstacleTransform.position.z), Quaternion.identity);
                break;
        }   
    }
    void ColetableInstantiate(Transform ColetableTransform)
    {
        Range = Random.Range(0,21);
        switch (Range) {
            case 0:
                 Instantiate(Resources.Load("Prefabs/Coletable2"), new Vector3(ColetableTransform.position.x, ColetableTransform.position.y+2, ColetableTransform.position.z), Quaternion.identity);
                break;
            default:
                 Instantiate(Resources.Load("Prefabs/Coletable"), new Vector3(ColetableTransform.position.x, ColetableTransform.position.y+2, ColetableTransform.position.z), Quaternion.identity);
                 break;
        }   
    }
    void ObstacleInstantiateControle(){
            if (ObstacleControlerRange >= MaxObstacleControler) ObstacleControlerRange = MaxObstacleControler;
            if (ObstacleControlerRange <= MinObstacleControlerRange) ObstacleControlerRange = MinObstacleControler;
            if (ObstacleControler >= MaxObstacleControler) ObstacleControler = MaxObstacleControler;
            if (ObstacleControler <= MinObstacleControler) ObstacleControler = MinObstacleControler;
            if (NeuroData.sAttention > 80)
            {
                ObstacleControlerRange -= 1;
                ObstacleControler -= 4;
            }
            else if (NeuroData.sAttention > 60 && NeuroData.sAttention <= 80)
            {
                ObstacleControlerRange -= 1;
                ObstacleControler -= 2;
            }
            else if (NeuroData.sAttention >= 40 && NeuroData.sAttention <= 60)
            {
                ObstacleControlerRange -= 1;
                ObstacleControler -= 1;
            }
    }
}
