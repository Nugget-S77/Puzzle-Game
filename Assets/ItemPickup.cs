using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemID = "Key";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inv = other.GetComponent<Inventory>();

        if (inv != null)
        {
            inv.AddItem(itemID);
            Destroy(gameObject);
        }
    }
}