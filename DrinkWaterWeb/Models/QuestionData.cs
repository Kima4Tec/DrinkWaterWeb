namespace DrinkWaterWeb.Models
{
    public class QuestionData
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int Answer { get; set; }
        public string Explanation { get; set; }
    }
}
