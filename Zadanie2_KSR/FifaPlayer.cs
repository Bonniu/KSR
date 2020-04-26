namespace Zadanie2_KSR
{
    public class FifaPlayer
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

        public FifaPlayer()
        {
        }

        public FifaPlayer(int age, int height, int weight, int overall, int value, int finishing, int dribbling,
            int curve, int passing, int sprintSpeed, int shotPower)
        {
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.overall = overall;
            this.value = value;
            this.finishing = finishing;
            this.dribbling = dribbling;
            this.curve = curve;
            this.passing = passing;
            this.sprintSpeed = sprintSpeed;
            this.shotPower = shotPower;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        public int Overall
        {
            get => overall;
            set => overall = value;
        }

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public int Finishing
        {
            get => finishing;
            set => finishing = value;
        }

        public int Dribbling
        {
            get => dribbling;
            set => dribbling = value;
        }

        public int Curve
        {
            get => curve;
            set => curve = value;
        }

        public int Passing
        {
            get => passing;
            set => passing = value;
        }

        public int SprintSpeed
        {
            get => sprintSpeed;
            set => sprintSpeed = value;
        }

        public int ShotPower
        {
            get => shotPower;
            set => shotPower = value;
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