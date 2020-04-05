namespace Zadanie1_KSR
{
    public class Neighbor
    {
        private string _place;
        private double _knnValue;

        public Neighbor(string place, double knnValue)
        {
            _place = place;
            _knnValue = knnValue;
        }

        public string GetPlace()
        {
            return _place;
        }

        public double GetKnnValue()
        {
            return _knnValue;
        }

        public void SetPlace(string place)
        {
            _place = place;
        }

        public void SetKnnValue(double knnValue)
        {
            _knnValue = knnValue;
        }
    }
}