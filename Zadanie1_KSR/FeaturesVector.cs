using System.Collections.Generic;

namespace Zadanie1_KSR
{
    public class FeaturesVector
    {
        private List<Features.Feature> features;

        public FeaturesVector(int size)
        {
            this.features = new List<Features.Feature>(size);
        }

        public void AddFeature(string fun, Article article, KeyWords keyWords)
        {
            
        }
    }
}