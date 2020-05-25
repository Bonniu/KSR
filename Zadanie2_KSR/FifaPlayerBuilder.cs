namespace Zadanie2_KSR
{
    public class FifaPlayerBuilder
    {
        private int _age;
        private int _height;
        private int _weight;
        private int _overall;
        private int _finishing;
        private int _dribbling;
        private int _curve;
        private int _passing;
        private int _sprintSpeed;
        private int _shotPower;
        private string _position;

        public FifaPlayerBuilder AddAge(int age)
        {
            _age = age;
            return this;
        }

        public FifaPlayerBuilder AddHeight(int height)
        {
            _height = height;
            return this;
        }

        public FifaPlayerBuilder AddWeight(int weight)
        {
            _weight = weight;
            return this;
        }

        public FifaPlayerBuilder AddOverall(int overall)
        {
            _overall = overall;
            return this;
        }

        public FifaPlayerBuilder AddFinishing(int finishing)
        {
            _finishing = finishing;
            return this;
        }

        public FifaPlayerBuilder AddDribbling(int dribbling)
        {
            _dribbling = dribbling;
            return this;
        }

        public FifaPlayerBuilder AddCurve(int curve)
        {
            _curve = curve;
            return this;
        }

        public FifaPlayerBuilder AddPassing(int passing)
        {
            _passing = passing;
            return this;
        }

        public FifaPlayerBuilder AddSprintSpeed(int sprintSpeed)
        {
            _sprintSpeed = sprintSpeed;
            return this;
        }

        public FifaPlayerBuilder AddShotPower(int shotPower)
        {
            _shotPower = shotPower;
            return this;
        }

        public FifaPlayerBuilder AddPosition(string position)
        {
            _position = position;
            return this;
        }


        public FifaPlayer Build()
        {
            return new FifaPlayer(_age, _height, _weight, _overall, _finishing, _dribbling,
                _curve, _passing, _sprintSpeed, _shotPower, _position);
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