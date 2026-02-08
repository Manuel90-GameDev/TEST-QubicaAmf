using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesWeatherFXLoader : MonoBehaviour
{
    private GameObject currentFX;
    private AsyncOperationHandle<GameObject> currentHandle;

    public void LoadFX(string key)
    {
        ClearCurrentFX();

        Addressables.LoadAssetAsync<GameObject>(key).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                currentHandle = handle;
                currentFX = Instantiate(handle.Result, transform);
            }
            else
            {
                Debug.LogError($"Failed to load FX: {key}");
            }
        };
    }

    public void ClearCurrentFX()
    {
        if (currentFX != null)
        {
            Destroy(currentFX);
            currentFX = null;
        }

        if (currentHandle.IsValid())
        {
            Addressables.Release(currentHandle);
        }
    }
}