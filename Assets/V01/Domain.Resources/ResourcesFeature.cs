using Assets.V01.Domain.Resources.Dto;
using System;
using System.Collections.Generic;

namespace Assets.V01.Domain.Resources
{
    public class ResourcesFeature
    {
        public event Action<string, object, int> ResourceAmountChangedTo;

        public IReadOnlyDictionary<string, (object resource, int amount)> Resources => _resources;

        private readonly Dictionary<string, (object resource, int amount)> _resources = new Dictionary<string, (object resource, int amount)>();

        public ResourcesFeature(ResourcesFeatureState state)
        {
            _resources = state.Resources;
        }

        public void Add(string key, object resource, int amount)
        {
            ValidateParams(key, amount, resource);

            if (_resources.ContainsKey(key))
                _resources[key] = (resource, _resources[key].amount + amount);
            else
                _resources.Add(key, (resource, amount));

            RiseEvent(key);
        }

        public void Add(string key, int amount)
        {
            ValidateParams(key, amount);

            if (!_resources.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            _resources[key] = (_resources[key].resource, _resources[key].amount + amount);

            RiseEvent(key);
        }

        public void Remove(string key, int amount)
        {
            ValidateParams(key, amount);

            if (!_resources.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            int newAmount = _resources[key].amount - amount;

            if (newAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _resources[key] = (_resources[key].resource, newAmount);

            RiseEvent(key);
        }

        private void RiseEvent(string key)
        {
            ResourceAmountChangedTo?.Invoke(key, _resources[key].resource, _resources[key].amount);
        }

        public bool IsResourceEnough(string key, int amount)
        {
            ValidateParams(key, amount);

            if (!_resources.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            return _resources[key].amount >= amount;
        }

        private static void ValidateParams(string key, int amount, object resource)
        {
            ValidateParams(key, amount);

            if (resource == null)
                throw new ArgumentNullException(nameof(resource));
        }

        private static void ValidateParams(string key, int amount)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
        }
    }
}
