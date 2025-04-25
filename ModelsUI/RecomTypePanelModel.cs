using LitExplorer.LitExplorerDTO;

namespace LitExplorer.ModelsUI
{
    public class RecomTypePanelModel
    {
        public bool Visibility { get; set; } = false;

        public RecommendationsOptions RO { get; set; } = RecommendationsOptions.BestOfMonth;
    }
}
