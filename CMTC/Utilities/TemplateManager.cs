using Antlr4.StringTemplate;
using System.IO;
using System.Reflection;

namespace CMTC.Utilities
{
    class TemplateManager
    {
        private TemplateGroup _templates;

        private static TemplateManager _instance = new TemplateManager();

        public static Template GetTemplate(string template) => _instance._templates.GetInstanceOf(template);

        private TemplateManager()
        {
            var assembly = typeof(Core.CMTCompiler).GetTypeInfo().Assembly;

            string content = string.Empty;
            foreach (string file in Properties.Resources.Templates.Split(";"))
            {
                using (var stream = assembly.GetManifestResourceStream(string.Format("{0}{1}", Properties.Resources.TemplateNamespace, file)))
                {
                    if (stream == null) continue;
                    using (var reader = new StreamReader(stream))
                    {
                        content += reader.ReadToEnd();
                    }
                }
            }

            _templates = new TemplateGroupString(content);
        }
    }
}
