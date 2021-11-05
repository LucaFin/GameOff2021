using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] healthbar;
    private float[] healthBarNumber;
    public static UIManager uIManager;

    private void Start()
    {
        uIManager = this;
        healthBarNumber = new float[healthbar.Length*2];
        float life = PlayerStat.playerStat.GetLife();
        for(int i = 0; i < life; i++)
        {
            healthBarNumber[i] = 1;
        }

    }

    public void HeartDamage(float damage)
    {
        float life = PlayerStat.playerStat.GetLife();
        int i = 0;
        while (damage > 0 && healthBarNumber[0]!=0)
        {
            if (healthBarNumber[(int)life - i - 1] == 0)
            {
                i++;
            }
            else {
                healthBarNumber[(int)life - i - 1] = 0;
                healthbar[((int)life - 1 - i)/ 2].fillAmount -= 0.5f;
                damage--;
            }
        }
    }
}
