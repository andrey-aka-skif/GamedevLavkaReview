using Assets.V01.Domain.Resources;
using Assets.V01.UI;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ResourceItemUI : MonoBehaviour
{
    private const int CHANGE_STEP = 1;

    [SerializeField] private Image _imageComponent;
    [SerializeField] private TextMeshProUGUI _nameComponent;
    [SerializeField] private TextMeshProUGUI _amountComponeny;
    [SerializeField] private MyButton _removeButton;
    [SerializeField] private MyButton _addButton;

    private string _name;
    private ResourcesFeature _resources;

    private void OnEnable()
    {
        _removeButton.ButtonClicked += OnDecButtonClick;
        _addButton.ButtonClicked += OnIncButtonClick;
    }

    private void OnDisable()
    {
        _removeButton.ButtonClicked -= OnDecButtonClick;
        _addButton.ButtonClicked -= OnIncButtonClick;
    }

    private void OnDecButtonClick()
    {
        if (_resources.IsResourceEnough(_name, CHANGE_STEP))
        {
            _resources.Remove(_name, CHANGE_STEP);
        }
    }

    private void OnIncButtonClick()
    {
        _resources.Add(_name, CHANGE_STEP);
    }

    public void Set(Sprite sprite, string name, int amount, ResourcesFeature resources)
    {
        _imageComponent.sprite = sprite;

        _name = name;
        _nameComponent.text = name;

        _amountComponeny.text = amount.ToString();

        _resources = resources;
    }

    public void SetAmount(int amount)
    {
        _amountComponeny.text = amount.ToString();

        CheckRemoveButtonEnabled(amount);
    }

    private void CheckRemoveButtonEnabled(int amount)
    {
        if (amount <= 0)
            _removeButton.IsEnabled = false;

        if (!_removeButton.IsEnabled && amount > 0)
            _removeButton.IsEnabled = true;
    }
}
