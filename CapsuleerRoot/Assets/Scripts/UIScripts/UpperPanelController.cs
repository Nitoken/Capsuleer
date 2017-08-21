using UnityEngine.UI;
using UnityEngine;

public class UpperPanelController : MonoBehaviour
{
    public PlayerHealth ph; 
    public PlayerAttack pa; 
    GameController gc;
    public Image playerHealth, enemyHealth;
    public Text playerHPStatus, enemyName;
    public GameObject enemyPanel; //Shows targets HP and name



    public GameObject enemytoShow;  //Show that object
    public bool showingByPlayerAttack = false; //If showing actual attacking target then true. 
    void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        GameObject playerTemp = GameObject.FindGameObjectWithTag("Player");
        ph = playerTemp.GetComponent<PlayerHealth>();
        pa = playerTemp.GetComponent<PlayerAttack>();
    }
    void Update()
    {
        //when player alive
        if (gc.isAlive)
        {
            playerHealth.fillAmount = ph.hp / ph.maxHP;
            playerHPStatus.text = (playerHealth.fillAmount * 100f).ToString("F2") + " %";
        }
        else
        {
            playerHPStatus.text = "Dead";
            playerHealth.fillAmount = 0f;
        }

        //Shows enemy name and health
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
