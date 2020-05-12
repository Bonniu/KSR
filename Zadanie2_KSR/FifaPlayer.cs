namespace Zadanie2_KSR
{
    public class FifaPlayer
    {
        private readonly int _age;
        private readonly int _height;
        private readonly int _weight;
        private readonly int _overall;
        private readonly int _finishing;
        private readonly int _dribbling;
        private readonly int _curve;
        private readonly int _passing;
        private readonly int _sprintSpeed;
        private readonly int _shotPower;

        public FifaPlayer()
        {
        }

        public FifaPlayer(int age, int height, int weight, int overall, int finishing, int dribbling,
            int curve, int passing, int sprintSpeed, int shotPower)
        {
            this._age = age;
            this._height = height;
            this._weight = weight;
            this._overall = overall;
            this._finishing = finishing;
            this._dribbling = dribbling;
            this._curve = curve;
            this._passing = passing;
            this._sprintSpeed = sprintSpeed;
            this._shotPower = shotPower;
        }

        public int GetAge()
        {
            return _age;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWeight()
        {
            return _weight;
        }

        public int GetOverall()
        {
            return _overall;
        }

        public int GetFinishing()
        {
            return _finishing;
        }

        public int GetDribbling()
        {
            return _dribbling;
        }

        public int GetCurve()
        {
            return _curve;
        }

        public int GetPassing()
        {
            return _passing;
        }

        public int GetSprintSpeed()
        {
            return _sprintSpeed;
        }

        public int GetShotPower()
        {
            return _shotPower;
        }

        public override string ToString()
        {
            return "{age: " + _age + ", height: " + _height + ", weight: " + _weight + ", overall: " + _overall +
                   ", finishing: " + _finishing + ", dribbling: " +
                   _dribbling + ", curve: " + _curve + ", passing: " + _passing + ", sprintSpeed: " + _sprintSpeed +
                   ", shotPower: " + _shotPower + "}";
        }
    }
}