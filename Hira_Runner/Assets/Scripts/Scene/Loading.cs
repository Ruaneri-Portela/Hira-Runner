

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private MindwaveDataModel m_MindwaveData;
    private MindwaveDataModel _Data;
    public TextMeshProUGUI TMPText;
    public GameObject TMPButton;
    public bool Control;
    // Start is called before the first frame update
    void Start()
    {
        TMPButton.SetActive(false);
        MindwaveManager.Instance.Controller.OnUpdateMindwaveData += OnUpdateMindwaveData;
        TMPText.SetText("Tentando conectar com o MindWave");
        StartCoroutine(Started());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            Reconnect();
            Control = false;
        }
    }
    IEnumerator Started()
    {
        yield return new WaitForSeconds(5);
        if (m_MindwaveData.eegPower.delta > 0)
        {
            TMPButton.SetActive(false);
            TMPText.SetText("Connected");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(3);
            SceneManager.UnloadScene(2);
        }
        if (m_MindwaveData.eegPower.delta == 0)
        {
            TMPButton.SetActive(true);
            TMPText.SetText("Can't connect");
        }
    }
    public void OnUpdateMindwaveData(MindwaveDataModel _Data)
    {
        m_MindwaveData = _Data;
    }
    public void Reconnect()
    {
        TMPText.SetText("Tentando novamene conectar com o MindWave");
        StartCoroutine(Started());
    }
}
