using log4net.ObjectRenderer;
using Newtonsoft.Json;
using System;
using System.IO;

namespace PlacementManagement.API.Logger
{
    public class Log4NetObjectLogger : IObjectRenderer
    {
        public Log4NetObjectLogger() { }

        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            if (obj is Exception)
            {
                rendererMap.DefaultRenderer.RenderObject(rendererMap, obj, writer);
            }
            else
            {
                writer.Write(JsonConvert.SerializeObject(obj));
            }
        }
    }
}