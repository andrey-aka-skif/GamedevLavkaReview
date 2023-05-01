using Assets.V01.Application.Resources;
using Assets.V01.Domain.Resources;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private ResourcesListUI _resourcesListUI;

    public void SetResources(ResourcesFeature resources)
    {
        _resourcesListUI.SetResources(resources);
    }
}
