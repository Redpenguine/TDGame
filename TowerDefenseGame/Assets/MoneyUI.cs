using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text money;
    public Text lives;

    // Update is called once per frame
    void Update()
    {
        money.text = "$" + PlayerStats.Money.ToString();
        lives.text = "Lives " + PlayerStats.Lives.ToString();
    }
}
