using Newtonsoft.Json;

namespace DrinkWaterWeb.Services
{
    public class QuestionHandler
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int Answer { get; set; }
        public string Explanation { get; set; }


        /// <summary>
        /// Handling Json file and getting the questions.
        /// </summary>
        /// <returns></returns>
        public List<QuestionHandler> GetQuestions()
        {
            //Name of json-file into variable
            string jsonFilePath = "QuestionAndAnswers.json";
            string json;

            try
            {
                // Read JSON-data from file and add to the variable json
                json = File.ReadAllText(jsonFilePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Fejl: Filen '{jsonFilePath}' blev ikke fundet.");
                return null;
            }
            catch (Exception ex)
            {
                //TODO use logging instead of console
                Console.WriteLine($"Fejl under læsning af filen: {ex.Message}");
                return null;
            }
            List<QuestionHandler> allQuestions;

            // Deserialise JSON-data to a list of QuestionData-objects
            allQuestions = JsonConvert.DeserializeObject<List<QuestionHandler>>(json);

            //Shuffle questions - especially for json with a large amount of questions
            Shuffle(allQuestions);

            return allQuestions;
        }


        // Fisher-Yates shuffle algorithm
        public void Shuffle<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
