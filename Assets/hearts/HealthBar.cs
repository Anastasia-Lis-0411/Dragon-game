
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public health playerHealth;
    public Image TotalHeart;
    public Image currentHeart;
    // Start is called before the first frame update
    void Start()
    {
        TotalHeart.fillAmount = playerHealth.currentHealth/10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHeart.fillAmount = playerHealth.currentHealth / 10;
    }
}
