using LitExplorer.LitExplorerDTO;

namespace LitExplorer.ModelsUI
{
    public class LibraryStatusPanelModel
    {
        public bool Visibility { get; set; } = false;

        public LibraryStatusOptions LO { get; set; } = LibraryStatusOptions.Reading;
    }
}
