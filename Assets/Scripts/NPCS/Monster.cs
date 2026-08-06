using UnityEngine;

public class Monster : MonoBehaviour
{
    public Torch torch;

    public float killTime = 60f;

    float timer;

    void Update()
    {
        if (!DayNightManager.Instance.IsNight())
        {
            timer = 0;
            return;
        }

        if (!TownArea.Instance.isOutsideTown)
        {
            timer = 0;
            return;
        }

        if (torch.torchEquipped)
        {
            timer = 0;
            return;
        }

        timer += Time.deltaTime;

        if (timer >= killTime)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        Debug.Log("Te mate porque soy un leniador, no tengo ennie");

        
    }
}
