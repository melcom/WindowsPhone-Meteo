using System.IO.IsolatedStorage;

namespace MeteoWP.Service.SettingsService
{
    public class Setting<T> where T : class
    {
        private readonly bool autoSave;
        private readonly T defaultValue;
        private readonly string key;
        private readonly IsolatedStorageSettings settings;

        public Setting(IsolatedStorageSettings settings, string key, T defaultValue, bool autoSave)
        {
            this.settings = settings;
            this.key = key;
            this.defaultValue = defaultValue;
            this.autoSave = autoSave;
        }

        public Setting(IsolatedStorageSettings settings, string key, T defaultValue)
            : this(settings, key, defaultValue, true)
        {
        }

        public T Value
        {
            get
            {
                if (settings.Contains(key))
                    return settings[key] as T;
                return defaultValue;
            }
            set
            {
                if (settings.Contains(key))
                    settings[key] = value;
                else
                {
                    settings.Add(key, value);
                }

                if (autoSave)
                    settings.Save();
            }
        }
    }
}