using Assets.V01.Application.Resources;
using Assets.V01.Domain.Resources;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesListUI : MonoBehaviour
{
    [SerializeField] private ResourceItemUI _itemPrefab;

    private ResourcesFeature _resources;

    private Dictionary<string, ResourceItemUI> _resourcesListUI;

    public void SetResources(ResourcesFeature resources)
    {
        _resources = resources;
        AddItems();
        _resources.ResourceAmountChangedTo += OnResourceChange;
    }

    private void OnResourceChange(string key, object resource, int amount)
    {
        if (_resourcesListUI.ContainsKey(key))
            _resourcesListUI[key].SetAmount(amount);
    }

    private void AddItems()
    {
        ClearChilds();
        _resourcesListUI = new Dictionary<string, ResourceItemUI>();

        foreach (var itemRes in _resources.Resources)
        {
            var creationResult = CreateItem(itemRes);
            _resourcesListUI.Add(creationResult.name, creationResult.itemUi);
        }
    }

    private (string name, ResourceItemUI itemUi) CreateItem(KeyValuePair<string, (object resource, int amount)> itemRes)
    {
        var itemUi = Instantiate(_itemPrefab, transform);
        var res = itemRes.Value.resource as Resource;
        itemUi.transform.name = res.Name;
        itemUi.Set(res.Icon, res.Name, itemRes.Value.amount, _resources);
        return (res.Name, itemUi);
    }

    private void ClearChilds()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
