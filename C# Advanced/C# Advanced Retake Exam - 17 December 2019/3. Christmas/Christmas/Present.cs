namespace Christmas
{
    public class Present
    {
        public Present(string name, double weight, string gender)
        {
            Name = name;
            Weight = weight;
            Gender = gender;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public string Gender { get; set; }

        public override string ToString()
        {
            string output = $"Present {Name} ({Weight}) for a {Gender}";
            return output.ToString();
        }
    }
}
