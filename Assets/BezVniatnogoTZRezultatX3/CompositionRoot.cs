using Assets.BezVniatnogoTZRezultatX3.Dto;
using Assets.BezVniatnogoTZRezultatX3.Ersatz;
using Assets.BezVniatnogoTZRezultatX3.Resources;
using Assets.BezVniatnogoTZRezultatX3.ResourcesKeeper;
using UnityEngine;

namespace Assets.BezVniatnogoTZRezultatX3
{
    public class CompositionRoot : MonoBehaviour
    {
        private ResourcesFeatureState _initResources;

        private ResourcesFeature _resources;

        void Start()
        {
            _initResources = Repository.GetResourcesState();
            _resources = new ResourcesKeeper.ResourcesFeature(_initResources);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.G))
            {
                _resources.Add(new Gold(2));
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                _resources.Add(new Silver(1));
            }

            if (Input.GetKeyUp(KeyCode.C))
            {
                _resources.Add(new Copper(8));
            }
        }
    }
}
