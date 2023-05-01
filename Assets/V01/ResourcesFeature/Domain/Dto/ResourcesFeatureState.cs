using System.Collections.Generic;

namespace Assets.V01.Domain.Resources.Dto
{
    public class ResourcesFeatureState
    {
        public Dictionary<string, (object resource, int amount)> Resources { get; set; } = new Dictionary<string, (object resource, int amount)>();
    }
}
