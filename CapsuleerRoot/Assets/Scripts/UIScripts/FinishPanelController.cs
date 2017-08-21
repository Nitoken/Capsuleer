using UnityEngine;
using UnityEngine.UI;
public class FinishPanelController : EndpanelController
{
    public Text txt;
    void OnEnable()
    {
        int x = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().wave;
        txt.text = "Survived" + (x - 1) + "waves";
    }
}
