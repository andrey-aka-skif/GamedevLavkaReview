using Assets.BezVniatnogoTZRezultatX3.Abstract;
using Assets.BezVniatnogoTZRezultatX3.Dto;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.BezVniatnogoTZRezultatX3.ResourcesKeeper
{
    public class ResourcesFeature
    {
        private readonly List<Resource> _resources;
        public IReadOnlyList<Resource> Resources => _resources;

        public event Action<Resource> ResourceCountChangedTo;

        public ResourcesFeature(ResourcesFeatureState state)
        {
            _resources = state.Resources;
        }

        public void Add(Resource resource)
        {
            int findedIndex = _resources.FindIndex(r => r.GetType() == resource.GetType());

            if (findedIndex < 0)
            {
                _resources.Add(resource);
                ResourceCountChangedTo?.Invoke(resource);
            }
            else
            {
                int newAmount = _resources[findedIndex].Amount + resource.Amount;
                var res = CreateResource(resource, newAmount);
                _resources[findedIndex] = CreateResource(resource, newAmount);
                ResourceCountChangedTo?.Invoke(_resources[findedIndex]);
            }
        }

        public void Remove(Resource resource)
        {
            if (resource.Amount < 0)
                throw new ArgumentOutOfRangeException(nameof(resource));

            int findedIndex = _resources.FindIndex(r => r.GetType() == resource.GetType());

            if (findedIndex < 0)
                throw new ArgumentException("Ресурс не был добавлен ранее", nameof(resource));

            int newAmount = _resources[findedIndex].Amount - resource.Amount;

            if (newAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(resource));

            _resources[findedIndex] = CreateResource(resource, newAmount);
            ResourceCountChangedTo?.Invoke(_resources[findedIndex]);
        }

        public bool IsResourceEnough(Resource resource)
        {
            if (resource.Amount < 0)
                throw new ArgumentOutOfRangeException(nameof(resource));

            int findedIndex = _resources.FindIndex(r => r.GetType() == resource.GetType());

            if (findedIndex < 0)
                throw new ArgumentException("Ресурс не был добавлен ранее", nameof(resource));

            return resource.Amount >= _resources[findedIndex].Amount;
        }

        private static Resource CreateResource(Resource resource, int newAmount)
        {
            Type type = resource.GetType();
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int) });
            var res = (Resource)ctor.Invoke(new object[] { newAmount });
            return res;
        }
    }
}
