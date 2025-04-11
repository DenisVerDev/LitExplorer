namespace LitExplorer.ModelsUI
{
    public class InputRangeModel
    {
        public string Name { get; set; } = "Default input range";

        public double MinLimit { get; set; } = 0;
        public double MaxLimit { get; set; } = double.MaxValue;

        public double? MinValue 
        { 
            get => minValue;
            set
            {
                if (value.HasValue)
                    minValue = Math.Clamp(value.Value, MinLimit, MaxLimit - 1);
                else minValue = null;
            }
        }
        public double? MaxValue 
        { 
            get => maxValue;
            set
            {
                if (value.HasValue)
                    maxValue = Math.Clamp(value.Value, MinLimit + 1, MaxLimit);
                else maxValue = null;
            }
        }

        private double? minValue;
        private double? maxValue;
    }
}
