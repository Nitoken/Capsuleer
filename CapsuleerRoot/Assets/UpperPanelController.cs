using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UpperPanelController : MonoBehaviour
{
    public Health ph;
    public Attack pa;
    GameController gc;
    public Image playerHealth, enemyHealth;
    public TextMeshProUGUI playerHPStatus, enemyName;
    public GameObject enemyPanel; //Shows targets HP and name

    public GameObject enemytoShow; 
    public bool showingByPlayerAttack = false; //If showing actual attacking target then true. 
    void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ph = player.GetComponent<Health>();
        pa = player.GetComponent<Attack>();
    }
    void Update()
    {
        if (gc.isAlive)
        {
            playerHealth.fillAmount = ph.hp / ph.maxHP;
            playerHPStatus.text = (playerHealth.fillAmount * 100f).ToString("F2") + " %";
        }
        else
        {
            playerHPStatus.text = "Dead";
        }

        if (enemytoShow != null)
        {
            enemyPanel.SetActive(true);
            enemyName.text = enemytoShow.name;
            enemyHealth.fillAmount = enemytoShow.GetComponent<Health>().hp / enemytoShow.GetComponent<Health>().maxHP;
        }
        else
            enemyPanel.SetActive(false);
    }
}
