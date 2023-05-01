using Assets.V01.Application.Resources;
using Assets.V01.Domain.Resources.Dto;
using UnityEngine;

namespace Assets.V01.Application.Ersatz
{
    public class Repository : MonoBehaviour
    {
        [SerializeField] private Resource _gold;
        [SerializeField] private int _goldCount;

        [SerializeField] private Resource _silver;
        [SerializeField] private int _silverCount;

        public ResourcesFeatureState GetResourcesState()
        {
            var resources = new ResourcesFeatureState();

            resources.Resources.Add(_gold.Name, new(_gold, _goldCount));
            resources.Resources.Add(_silver.Name, new(_silver, _silverCount));

            return resources;
        }
    }
}
