using Newtonsoft.Json;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.Helper
{
    public class JsonValidator
    {
        public static bool ValidateJson<T>(string jsonString)
        {
            try
			{
               var parsed= JsonConvert.DeserializeObject<T>(jsonString);
                return true;
            }
			catch (Exception)
			{
				return false;
			}
        }
    }
}
