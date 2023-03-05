using UnityEngine;

public class RepairArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TankMoverPlayer>() != null)
        {
           other.gameObject.GetComponent<StatisticHP>().SetHeal(1000);
        }
    }
}
