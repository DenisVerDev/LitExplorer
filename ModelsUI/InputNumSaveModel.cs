namespace LitExplorer.ModelsUI
{
    public class InputNumSaveModel
    {
        public string Name { get; set; } = "Default input";
        public int MinLimit { get; set; } = 0;
        public int MaxLimit { get; set; } = int.MaxValue;

        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                // Clamp the value within [MinLimit, MaxLimit]
                _value = Math.Clamp(value, MinLimit, MaxLimit);
            }
        }
    }
}
