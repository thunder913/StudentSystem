using System.ComponentModel.DataAnnotations;
namespace StudentSystem.MVVM.Model.DB
{
    public class Settings
    {
        [Key]
        public int SettingsId { get; set; }
        public int SuggestionsCount { get; set; } = 5;
        public bool AutoComplete { get; set; } = false;
        public int InputLengthThreshold { get; set; } = 3;
        public Settings()
        {
            InputLengthThreshold = 3;
        }
    }
}
