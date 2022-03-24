using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{
    public const string NewColorUnlockedKey = "NewColorUnlocked";
    private const string NewColorId = "com.aigames.asteroidavoider.newcolor";

    private void Awake()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            return;
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == NewColorId)
        {
            PlayerPrefs.SetInt(NewColorUnlockedKey, 1);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning($"Failed to purchase product {product.definition.id} because {reason}");
    }
}
