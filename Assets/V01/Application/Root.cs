using Assets.V01.Application.Ersatz;
using Assets.V01.Application.Resources;
using Assets.V01.Domain.Resources;
using Assets.V01.Domain.Resources.Dto;
using UnityEngine;

namespace Assets.V01.Application
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Repository _repository;
        [SerializeField] private ResourcesUI _resourcesUI;

        private ResourcesFeatureState _initData;
        private ResourcesFeature _resources;

        [SerializeField] private Resource _copper;

        private void Awake()
        {
            _initData = _repository.GetResourcesState();
            _resources = new ResourcesFeature(_initData);
            _resourcesUI.SetResources(_resources);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.G))
            {
                _resources.Add("Золото", 2);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                _resources.Add("Серебро", 2);
            }

            if (Input.GetKeyUp(KeyCode.C))
            {
                _resources.Add("Медяки", _copper, 8);
            }
        }
    }
}
