using UnityEngine;
using UnityEngine.UI;
public class WavePanelController : MonoBehaviour
{
    GameController gc;
    public Text actualWave, actualSubWave, time;
    public GameObject startBTN;
    int maxSubWave;
    void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        maxSubWave = gc.maxSubWave;
    }
    void Update()
    {
        actualWave.text = "Wave: " + gc.wave;

        if(gc.waving)
        {
            startBTN.SetActive(false);
            time.gameObject.SetActive(true);
            time.text = ((int)gc.timer).ToString();
            actualSubWave.text = "Sub wave: " + gc.subWave + "/" + maxSubWave;
        }
        else
        {
            actualSubWave.text = "None";
            startBTN.SetActive(true);
            time.gameObject.SetActive(false);
        }
    }
    public void StartNewWave()
    {
        if(gc.isAlive)
            gc.StartNewWave();
    }
}
