using System;

namespace HomeDish.Challenge.DataAccess
{
    public partial class Repository : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
