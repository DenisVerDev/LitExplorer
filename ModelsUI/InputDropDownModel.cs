namespace LitExplorer.ModelsUI
{
    public class InputDropDownModel
    {
        // The list of options for the dropdown (key => display value)
        public Dictionary<int, string> Options { get; set; } = new Dictionary<int, string>();

        // Optional initial key to pre-select
        public int? InitialValue { get; set; }

        // The currently selected key (can be read externally)
        public int SelectedKey { get; set; }
    }
}
