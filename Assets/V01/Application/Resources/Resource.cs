using UnityEngine;

namespace Assets.V01.Application.Resources
{
    [CreateAssetMenu(fileName = "empty_resource", menuName = "Resources/New Resource...")]
    public class Resource : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public Resource(string name, Sprite icon)
        {
            Name = name;
            Icon = icon;
        }

        public string Name { get => _name; private set => _name = value; }
        public Sprite Icon { get => _icon; private set => _icon = value; }
    }
}
