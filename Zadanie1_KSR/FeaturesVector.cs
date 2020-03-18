using System.Collections.Generic;
using Zadanie1_KSR.Features;

namespace Zadanie1_KSR
{
    public class FeaturesVector
    {
        private List<Feature> features;

        public FeaturesVector()
        {
            this.features = new List<Feature>();
        }

        public void AddFeature(Feature feature)
        {
            features.Add(feature);
        }

        public List<Feature> GetFeatures()
        {
            return features;
        }
    }
}