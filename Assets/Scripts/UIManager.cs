using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] healthbar;
    public static UIManager uIManager;
    public GameObject pnlGameOver;


    private void Awake()
    {
        uIManager = this;
    }
    public void HeartDamage(float damage)
    {
        foreach(Image health in healthbar)
        {
            if (health.gameObject.activeInHierarchy && damage>0)
            {
                health.gameObject.SetActive(false);
                damage--;
            }
        }
        if (!healthbar[4].gameObject.activeInHierarchy)
        {
            pnlGameOver.SetActive(true);
            
        }
    }

    public void ResetLife()
    {
        foreach(Image health in healthbar)
        {
            health.gameObject.SetActive(true);
        }
    }
}
