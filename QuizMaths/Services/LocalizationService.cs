using System.Globalization;
using System.Resources;

namespace QuizMaths.Services;

  public interface ILocalizationService
    {
        string GetString(string key);
        string GetString(string key, params object[] args);
        void SetLanguage(string languageCode);
        IEnumerable<string> GetAvailableLanguages();
    }

    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public LocalizationService()
        {
            _resourceManager = new ResourceManager("QuizMaths.Resources.Strings", typeof(LocalizationService).Assembly);
            _currentCulture = CultureInfo.GetCultureInfo("en"); // Default to English
        }

        public string GetString(string key)
        {
            try
            {
                var value = _resourceManager.GetString(key, _currentCulture);
                return value ?? $"[Missing: {key}]";
            }
            catch
            {
                return $"[Error: {key}]";
            }
        }

        public string GetString(string key, params object[] args)
        {
            var format = GetString(key);
            try
            {
                return string.Format(_currentCulture, format, args);
            }
            catch
            {
                return format; // Return unformatted string if formatting fails
            }
        }

        public void SetLanguage(string languageCode)
        {
            try
            {
                _currentCulture = CultureInfo.GetCultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = _currentCulture;
                Thread.CurrentThread.CurrentUICulture = _currentCulture;
            }
            catch (CultureNotFoundException)
            {
                // Fallback to English if culture not found
                _currentCulture = CultureInfo.GetCultureInfo("en");
            }
        }

        public IEnumerable<string> GetAvailableLanguages()
        {
            return new[] { "en", "fr" };
        }
    }
