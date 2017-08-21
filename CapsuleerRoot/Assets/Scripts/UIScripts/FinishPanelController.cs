using UnityEngine;
using UnityEngine.UI;
public class FinishPanelController : EndpanelController
{
    public Text txt;
    void OnEnable()
    {
        int x = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().wave;
        txt.text = string.Format("Survived {0} waves", (x + 1));
    }
}
