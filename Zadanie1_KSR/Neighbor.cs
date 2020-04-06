namespace Zadanie1_KSR
{
    public class Neighbor
    {
        private string place;
        private double knnValue;

        public Neighbor(string place, double knnValue)
        {
            this.place = place;
            this.knnValue = knnValue;
        }

        public string GetPlace()
        {
            return place;
        }

        public double GetKnnValue()
        {
            return knnValue;
        }

        public void SetPlace(string place)
        {
            this.place = place;
        }

        public void SetKnnValue(double knnValue)
        {
            this.knnValue = knnValue;
        }
    }
}