using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] healthbar;
    public static UIManager uIManager;


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
    }
}
