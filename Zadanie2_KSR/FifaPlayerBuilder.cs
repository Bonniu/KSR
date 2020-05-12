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

        public FifaPlayerBuilder AddAge(int age)
        {
            _age = age;
            return this;
        }

        public FifaPlayerBuilder AddHeight(int height)
        {
            this._height = height;
            return this;
        }

        public FifaPlayerBuilder AddWeight(int weight)
        {
            this._weight = weight;
            return this;
        }

        public FifaPlayerBuilder AddOverall(int overall)
        {
            this._overall = overall;
            return this;
        }

        public FifaPlayerBuilder AddFinishing(int finishing)
        {
            this._finishing = finishing;
            return this;
        }

        public FifaPlayerBuilder AddDribbling(int dribbling)
        {
            this._dribbling = dribbling;
            return this;
        }

        public FifaPlayerBuilder AddCurve(int curve)
        {
            this._curve = curve;
            return this;
        }

        public FifaPlayerBuilder AddPassing(int passing)
        {
            this._passing = passing;
            return this;
        }

        public FifaPlayerBuilder AddSprintSpeed(int sprintSpeed)
        {
            this._sprintSpeed = sprintSpeed;
            return this;
        }

        public FifaPlayerBuilder AddShotPower(int shotPower)
        {
            this._shotPower = shotPower;
            return this;
        }


        public FifaPlayer Build()
        {
            return new FifaPlayer(_age, _height, _weight, _overall, _finishing, _dribbling,
                _curve, _passing, _sprintSpeed, _shotPower);
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