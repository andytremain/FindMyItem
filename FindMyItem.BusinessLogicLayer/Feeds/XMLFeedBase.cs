using System;

namespace FindMyItem.BusinessLogicLayer.Feeds
{
    public abstract class XMLFeedBaseBLL : IDisposable
    {
        public string CleanInnerXML(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                return value.Replace("<![CDATA[", "").Replace("]]>", "");
            }
            else
            {
                return String.Empty;
            } 
        }

        // Flag: Has Dispose already been called? 
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }
    }
}
