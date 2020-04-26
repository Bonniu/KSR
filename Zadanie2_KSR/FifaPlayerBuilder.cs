namespace Zadanie2_KSR
{
    public class FifaPlayerBuilder
    {
        private int age;
        private int height;
        private int weight;
        private int overall;
        private int value;
        private int finishing;
        private int dribbling;
        private int curve;
        private int passing;
        private int sprintSpeed;
        private int shotPower;

        public void addAge(int age)
        {
            this.age = age;
        }

        public void addHeight(int height)
        {
            this.height = height;
        }

        public void addWeight(int weight)
        {
            this.weight = weight;
        }

        public void addOverall(int overall)
        {
            this.overall = overall;
        }

        public void addValue(int value)
        {
            this.value = value;
        }

        public void addFinishing(int finishing)
        {
            this.finishing = finishing;
        }

        public void addDribbling(int dribbling)
        {
            this.finishing = dribbling;
        }

        public void addCurve(int curve)
        {
            this.curve = curve;
        }

        public void addPassing(int passing)
        {
            this.passing = passing;
        }

        public void addSprintSpeed(int sprintSpeed)
        {
            this.sprintSpeed = sprintSpeed;
        }

        public void addShotPower(int shotPower)
        {
            this.shotPower = shotPower;
        }


        public FifaPlayer build()
        {
            return new FifaPlayer(age, height, weight, overall, value, finishing, dribbling,
                curve, passing, sprintSpeed, shotPower);
        }

        public string ToString()
        {
            return "{age: " + age + ", height: " + height + ", weight: " + weight + ", overall: " + overall + ", value: " +
                   value + ", finishing: " + finishing + ", dribbling: " +
                   dribbling + ", curve: " + curve + ", passing: " + passing + ", sprintSpeed: " + sprintSpeed +
                   ", shotPower: " + shotPower + "}";
        }
    }
}