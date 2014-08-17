using Orchard.UI.Resources;

namespace Orchard.Alias.Redirects
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {
            builder
                .Add()
                .DefineStyle("Styles.Admin.Orchard.Alias.Redirects")
                .SetUrl("admin.redirects.css");
        }
    }
}