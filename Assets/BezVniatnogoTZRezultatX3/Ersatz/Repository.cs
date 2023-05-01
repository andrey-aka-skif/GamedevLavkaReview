using Assets.BezVniatnogoTZRezultatX3.Dto;
using Assets.BezVniatnogoTZRezultatX3.Resources;

namespace Assets.BezVniatnogoTZRezultatX3.Ersatz
{
    public static class Repository
    {
        public static ResourcesFeatureState GetResourcesState()
        {
            var resources = new ResourcesFeatureState();

            var gold = new Gold(3);
            resources.Resources.Add(gold);

            var silver = new Silver(7);
            resources.Resources.Add(silver);

            return resources;
        }
    }
}
