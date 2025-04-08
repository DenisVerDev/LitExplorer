namespace LitExplorer.ModelsUI
{
    public class InputRangeModel
    {
        public string Name { get; set; } = "Default input range";

        public int MinLimit { get; set; } = 0;
        public int MaxLimit { get; set; } = int.MaxValue;

        public int? MinValue 
        { 
            get => minValue;
            set
            {
                if (value.HasValue)
                    minValue = Math.Clamp(value.Value, MinLimit, MaxLimit - 1);
                else minValue = null;
            }
        }
        public int? MaxValue 
        { 
            get => maxValue;
            set
            {
                if (value.HasValue)
                    maxValue = Math.Clamp(value.Value, MinLimit + 1, MaxLimit);
                else maxValue = null;
            }
        }

        private int? minValue;
        private int? maxValue;
    }
}
