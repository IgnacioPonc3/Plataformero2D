using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public int enemiesKilled = 0;
    public Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Enemigos Abatidos: " + enemiesKilled.ToString();
    }

    public void AddKill()
    {
        enemiesKilled++;
        text.text = "Enemigos Abatidos: " + enemiesKilled.ToString();
    }
}
